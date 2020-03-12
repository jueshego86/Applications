namespace DataAccess.Contrats
{
    using Models;
    using System;
    using System.Collections.Generic;

    public interface IProductsDAO
    {
        List<Product> GetProductsList();

        Product GetProduct(int productId);

        void UpdateProduct(int productId, int quantity);
    }
}
