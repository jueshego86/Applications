namespace Facade.Contracts
{
    using Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStudentFacade
    {
        Task<IList<Student>> GetAll();

        Task<Student> GetStudent(int id);

        Task<int> Insert(Student student);

        Task Update(Student student);

        Task Delete(int id);
    }
}
