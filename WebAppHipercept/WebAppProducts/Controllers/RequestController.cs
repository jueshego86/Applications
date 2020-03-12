namespace WebAppProducts.Controllers
{
    using Facade;
    using Facade.Facades;
    using Facade.Loging;
    using global::Models;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using WebAppProducts.ViewModels;

    [Authorize]
    public class RequestController : Controller
    {
        FacadeRequest FacadeRequest;
        FacadeProducts FacadeProducts;
        Logger Logger;

        public RequestController(FacadeRequest facadeRequest, FacadeProducts facadeProducts, Logger logger)
        {
            this.FacadeRequest = facadeRequest;
            this.FacadeProducts = facadeProducts;
            this.Logger = logger;
        }

        private SelectList GetProducts()
        {
            List<ProductViewModel> productsViewModel = new List<ProductViewModel>();

            List<Product> products = this.FacadeProducts.GetProductsList();

            foreach (var item in products)
            {
                productsViewModel.Add(new ProductViewModel
                {
                    ProductId = item.ProductId,
                    Name = item.Name,
                });
            }

            return new SelectList(productsViewModel, "ProductId", "Name");
        }

        [Authorize(Roles = "User")]
        public ActionResult NewRequest()
        {
            ViewBag.ProductId = this.GetProducts();

            return View();
        }

        [Authorize(Roles = "User")]
        public ActionResult GetStock([Bind(Include = "ProductId,Stock,Quantity")] RequestViewModel request)
        {
            request.Stock = FacadeProducts.GetProduct(request.ProductId).Stock;

            ViewBag.ProductId = this.GetProducts();

            return View("NewRequest", request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public ActionResult SaveRequest([Bind(Include = "ProductId,Stock,Quantity")] RequestViewModel request)
        {
            try
            {
                ViewBag.ProductId = this.GetProducts();

                if (!ModelState.IsValid)
                {
                    ViewBag.Message = "Invalid Data";

                    return View("NewRequest", new RequestViewModel { ProductId = request.ProductId, Quantity = request.Quantity, Stock = request.Stock });
                }

                int stock = this.FacadeProducts.GetProduct(request.ProductId).Stock;

                if (stock == 0 || request.Quantity > stock)
                {
                    ViewBag.Message = "Insufficient Stock";

                    return View("NewRequest", new RequestViewModel { ProductId = request.ProductId, Quantity = request.Quantity, Stock = stock });
                }

                this.FacadeRequest.SaveRequest(new ProductRequest
                {
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    UserName = User.Identity.Name
                });

                this.FacadeProducts.UpdateStockFromRequest(request.ProductId, request.Quantity);

                ViewBag.MessageSuccess = "Request Saved";

                return View("NewRequest", new RequestViewModel());
            }
            catch (Exception e)
            {
                this.Logger.LogMessage(e.Message + " - " + e.InnerException, true, EnumMessageType.ERROR);
                ViewBag.Exception = "An unexpected event has occurred";
                return View("NewRequest", new RequestViewModel { ProductId = request.ProductId, Quantity = request.Quantity, Stock = request.Stock });
            }
        }

        [Authorize]
        public ActionResult RequestList(string order, int? page)
        {
            ViewBag.ActualOrderBy = order;

            ViewBag.NameOrder = string.IsNullOrEmpty(order) ? "product_desc" : "";
            order = ViewBag.NameOrder;

            List<ProductRequest> request;

            if (User.IsInRole("User"))
            {
                request = this.FacadeRequest.GetRequestsByUser(User.Identity.Name);
            }
            else
            {
                request = this.FacadeRequest.GetRequests();
            }

            List<RequestViewModel> requestViewModel = new List<RequestViewModel>();

            foreach(var item in request)
            {
                requestViewModel.Add(new RequestViewModel
                {
                    RequestId = item.ProductRequestId,
                    ProductName = this.FacadeProducts.GetProduct(item.ProductId).Name,
                    UserName = item.UserName,
                    Quantity = item.Quantity
                });
            }

            switch (order)
            {
                case "product_desc":
                    requestViewModel = requestViewModel.OrderByDescending(r => r.ProductName).ToList();
                    break;

                default:
                    requestViewModel = requestViewModel.OrderBy(r => r.UserName).ToList();
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(requestViewModel.ToPagedList(pageNumber, pageSize));
        }
    }
}