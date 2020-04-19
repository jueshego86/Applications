namespace DataAccess.Contracts
{
    using Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDAOStudent
    {
        Task<int> Insert(Student student);

        Task<IList<Student>> GetAll();

        Task<Student> GetStudent(int id);

        Task Update(Student student);

        Task Delete(int id);
    }
}
