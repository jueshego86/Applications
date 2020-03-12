namespace Facade.Facades
{
    using DataAccess.Contrats;
    using Models;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class FacadeProducts
    {
        private IProductsDAO ProductsDAO;

        public FacadeProducts(IProductsDAO productsDAO)
        {
            this.ProductsDAO = productsDAO;
        }

        public List<Product> GetProductsList()
        {
            return this.ProductsDAO.GetProductsList();
        }

        public Product GetProduct(int productId)
        {
            return this.ProductsDAO.GetProduct(productId);
        }


        public void UpdateStockFromRequest(int productId, int quantity)
        {
            this.ProductsDAO.UpdateProduct(productId, quantity);
        }

        /// <summary>
        /// Updates Stock From Admin Action via Api
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public async Task<bool> UpdateStockFromAdmin(int productId, int quantity)
        {
            using (var client = new HttpClient())
            {
                var url = "http://localhost:57691/Products/Edit";
                var parameters = new Dictionary<string, string> { { "productId", productId.ToString() }, { "stock", quantity.ToString() } };
                var encodedContent = new FormUrlEncodedContent(parameters);

                var response = await client.PostAsync(url, encodedContent).ConfigureAwait(false);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new System.Exception("Request Error: " + response.StatusCode);
                }

                return true;
            }
        }
    }
}
