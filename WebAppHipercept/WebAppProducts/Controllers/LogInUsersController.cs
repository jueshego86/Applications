using Facade.Facades;
using Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppProducts.Controllers
{
    [Authorize]
    public class LogInUsersController : Controller
    {
        private FacadeLoginUsers Facade;

        public LogInUsersController(FacadeLoginUsers facade)
        {
            this.Facade = facade;
        }

        [Authorize(Roles = "Administrator")]
        // GET: LogInUsers
        public ActionResult Index(string order, int? page)
        {
            ViewBag.ActualOrderBy = order;

            ViewBag.NameOrder = string.IsNullOrEmpty(order) ? "date_desc" : "";
            order = ViewBag.NameOrder;

            List<LogInUsers> logIns = this.Facade.GetAllLoginUsers();

            switch (order)
            {
                case "date_desc":
                    logIns = logIns.OrderByDescending(l => l.LoginDate).ToList();
                    break;

                default:
                    logIns = logIns.OrderBy(l => l.UserName).ToList();
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(logIns.ToPagedList(pageNumber, pageSize));
        }
    }
}