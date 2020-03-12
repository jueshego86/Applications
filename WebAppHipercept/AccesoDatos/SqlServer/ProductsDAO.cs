namespace DataAccess.SqlServer
{
    using DataAccess.Contrats;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsDAO : IProductsDAO
    {
        private Context Context;

        public ProductsDAO(Context context)
        {
            this.Context = context;
        }

        public Product GetProduct(int productId)
        {
            return this.Context.Products.Find(productId);
        }

        public List<Product> GetProductsList()
        {
            return this.Context.Products.ToList();
        }

        public void UpdateProduct(int productId, int quantity)
        {
            Product product = this.Context.Products.Find(productId);
            product.Stock = product.Stock - quantity;

            if (product.Stock < 0)
            {
                throw new Exception("Insufficient Stock");
            }

            this.Context.SaveChanges();
        }
    }
}
