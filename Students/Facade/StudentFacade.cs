namespace Facade
{
    using DataAccess.Contracts;
    using Facade.Contracts;
    using Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class StudentFacade : IStudentFacade
    {
        /// <summary>
        /// student data access object property
        /// </summary>
        private IDAOStudent DAOStudent;

        /// <summary>
        /// Constructor
        /// </summary>     
        public StudentFacade(IDAOStudent dAOStudent)
        {
            this.DAOStudent = dAOStudent;
        }

        /// <summary>
        /// get all students entries from the db
        /// </summary>
        /// <returns>
        /// The list of all students.
        /// </returns>
        public async Task<IList<Student>> GetAll()
        {
            return await this.DAOStudent.GetAll();
        }

        /// <summary>
        /// get a existing student from the db
        /// </summary>
        /// <returns>
        /// student
        /// </returns>
        public async Task<Student> GetStudent(int id)
        {
            return await this.DAOStudent.GetStudent(id);
        }

        /// <summary>
        /// saves a new student
        /// </summary>
        /// <returns>
        /// new student Id
        /// </returns>
        public async Task<int> Insert(Student student)
        {
            return await this.DAOStudent.Insert(student);
        }

        /// <summary>
        /// updates a existing student
        /// </summary>
        public async Task Update(Student student)
        {
            await this.DAOStudent.Update(student);
        }

        /// <summary>
        /// deletes a existing student at the db
        /// </summary>
        public async Task Delete(int id)
        {
            await this.DAOStudent.Delete(id);
        }
    }
}
