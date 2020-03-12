using Facade.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
namespace WebAppProducts.Controllers
{
    using Facade;
    using Facade.Loging;
    using global::Models;
    using System.Web;
    using System.Web.Mvc;
    using WebAppProducts.ViewModels;

    public class ProductsController : Controller
    {
        FacadeProducts FacadeProducts;
        Logger Logger;

        public ProductsController(FacadeProducts facadeProducts, Logger logger)
        {
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

        [Authorize(Roles = "Administrator")]
        public ActionResult ViewStock()
        {
            ViewBag.ProductId = this.GetProducts();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> SaveStock([Bind(Include = "ProductId,Stock")] ProductViewModel product)
        {
            try
            {
                ViewBag.ProductId = this.GetProducts();

                if (!ModelState.IsValid)
                {
                    ViewBag.Message = "Invalid Data";

                    return View("ViewStock", new ProductViewModel { ProductId = product.ProductId, Stock = product.Stock });
                }

                await this.FacadeProducts.UpdateStockFromAdmin(product.ProductId, product.Stock);
           
                ViewBag.MessageSuccess = "Stock Updated";

                return View("ViewStock", new ProductViewModel());
            }
            catch (Exception e)
            {
                this.Logger.LogMessage(e.Message + " - " + e.InnerException, true, EnumMessageType.ERROR);
                ViewBag.Exception = "An unexpected event has occurred";
                return View("ViewStock", new ProductViewModel { ProductId = product.ProductId, Stock = product.Stock });
            }
        }

        //[Authorize(Roles = "Administrator")]
        //public ActionResult GetStock([Bind(Include = "ProductId,Stock,Quantity")] ProductViewModel product)
        //{
        //    product.Stock = FacadeProducts.GetProduct(product.ProductId).Stock;

        //    ViewBag.ProductId = this.GetProducts();

        //    return View("ViewStock", product);
        //}

        private static string ConfigureExcepcion(Exception ex)
        {
            return ex.Message + " \n " + ex.StackTrace;
        }
    }
}