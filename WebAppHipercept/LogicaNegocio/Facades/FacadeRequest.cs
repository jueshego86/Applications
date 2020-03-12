namespace Facade.Facades
{
    using DataAccess.Contrats;
    using Models;
    using System.Collections.Generic;

    public class FacadeRequest
    {
        private IRequestsDAO RequestsDAO;

        public FacadeRequest(IRequestsDAO requestsDAO)
        {
            this.RequestsDAO = requestsDAO;
        }

        public List<ProductRequest> GetRequests()
        {
            return RequestsDAO.GetRequests();
        }

        public List<ProductRequest> GetRequestsByUser(string userName)
        {
            return RequestsDAO.GetRequestsByUser(userName);
        }

        public void SaveRequest(ProductRequest request)
        {
            RequestsDAO.SaveRequest(request);
        }
    }
}
