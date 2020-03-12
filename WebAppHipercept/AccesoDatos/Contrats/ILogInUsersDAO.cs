namespace DataAccess.Contrats
{
    using Models;
    using System.Collections.Generic;

    public interface ILogInUsersDAO
    {
        List<LogInUsers> GetAllLoginUsers();

        void SaveLoginUser(LogInUsers logInUsers);     
    }
}
