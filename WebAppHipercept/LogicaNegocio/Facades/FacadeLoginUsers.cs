namespace Facade.Facades
{
    using DataAccess.Contrats;
    using Models;
    using System.Collections.Generic;

    public class FacadeLoginUsers
    {
        private ILogInUsersDAO LogInUsersDAO;

        public FacadeLoginUsers(ILogInUsersDAO logInUsersDAO)
        {
            this.LogInUsersDAO = logInUsersDAO;
        }

        public List<LogInUsers> GetAllLoginUsers()
        {
            return this.LogInUsersDAO.GetAllLoginUsers();
        }

        public void SaveLoginUser(LogInUsers logInUsers)
        {
            this.LogInUsersDAO.SaveLoginUser(logInUsers);
        }
    }
}
