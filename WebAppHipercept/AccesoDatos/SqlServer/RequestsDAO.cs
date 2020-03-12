namespace DataAccess.SqlServer
{
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Contrats;
    using Models;

    public class RequestsDAO : IRequestsDAO
    {
        private Context Context;

        public RequestsDAO(Context context)
        {
            this.Context = context;
        }

        public List<ProductRequest> GetRequests()
        {
            return this.Context.Requests.ToList();
        }

        public List<ProductRequest> GetRequestsByUser(string userName)
        {
            return this.Context.Requests.Where(r => r.UserName == userName).ToList();
        }

        public void SaveRequest(ProductRequest request)
        {
            this.Context.Requests.Add(request);
            this.Context.SaveChanges();
        }
    }
}
