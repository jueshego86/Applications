namespace WebAppProducts
{
    using DataAccess.Contrats;
    using DataAccess.SqlServer;
    using Facade.Loging;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web.Mvc;
    using Unity;
    using Unity.AspNet.Mvc;
    using Unity.Injection;
    using WebAppProducts.Controllers;
    using WebAppProducts.Models;

    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            container.RegisterType<Context, ContextSQLServer>();
            container.RegisterType<ILoggerToFile, LoggerToFile>();
            container.RegisterType<ILogInUsersDAO, LogInUsersDAO>();
            container.RegisterType<IProductsDAO, ProductsDAO>();
            container.RegisterType<IRequestsDAO, RequestsDAO>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}