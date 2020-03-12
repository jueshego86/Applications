namespace DataAccess.Contrats
{
    using Models;
    using System.Collections.Generic;

    public interface IRequestsDAO
    {
        List<ProductRequest> GetRequests();

        List<ProductRequest> GetRequestsByUser(string userName);

        void SaveRequest(ProductRequest request);
    }
}
