namespace WebAppProducts
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using WebAppProducts.Models;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ApplicationDbContext dBcontext = new ApplicationDbContext();
            CreateRoles(dBcontext);
            dBcontext.Dispose();
        }

        private void CreateRoles(ApplicationDbContext dBcontext)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(dBcontext));

            if (!roleManager.RoleExists("Administrator"))
            {
                roleManager.Create(new IdentityRole("Administrator"));
            }

            if (!roleManager.RoleExists("User"))
            {
                roleManager.Create(new IdentityRole("User"));
            }
        }
    }
}
