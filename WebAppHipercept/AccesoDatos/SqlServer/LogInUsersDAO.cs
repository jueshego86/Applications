namespace DataAccess.SqlServer
{
    using DataAccess.Contrats;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class LogInUsersDAO : ILogInUsersDAO
    {
        private Context context;

        public LogInUsersDAO(Context context)
        {
            this.context = context;
        }

        public List<LogInUsers> GetAllLoginUsers()
        {
            return this.context.LoginUsers.ToList();
        }

        public void SaveLoginUser(LogInUsers logInUsers)
        {
            this.context.LoginUsers.Add(logInUsers);
            this.context.SaveChanges();
        }
    }
}
