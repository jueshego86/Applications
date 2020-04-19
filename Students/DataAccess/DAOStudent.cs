namespace DataAccess
{
    using DataAccess.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DAOStudent : IDAOStudent
    {
        /// <summary>
        /// Db Context object property
        /// </summary>
        private Context Context;

        /// <summary>
        /// Constructor
        /// </summary>
        public DAOStudent(Context context)
        {
            this.Context = context;
        }

        /// <summary>
        /// get all students entries from the db
        /// </summary>
        /// <returns>
        /// The list of all students.
        /// </returns>
        public async Task<IList<Student>> GetAll()
        {
            return await this.Context.Student.ToListAsync();
        }

        /// <summary>
        /// get a existing student from the db
        /// </summary>
        /// <returns>
        /// student
        /// </returns>
        public async Task<Student> GetStudent(int id)
        {
            return await this.Context.Student.FindAsync(id);
        }

        /// <summary>
        /// saves a new student
        /// </summary>
        /// <returns>
        /// new student Id
        /// </returns>
        public async Task<int> Insert(Student student)
        {
            this.Context.Student.Add(student);
            await this.Context.SaveChangesAsync();

            return student.Id;
        }

        /// <summary>
        /// updates a existing student
        /// </summary>
        public async Task Update(Student student)
        {
            this.Context.Entry(student).State = EntityState.Modified;
            await this.Context.SaveChangesAsync();
        }

        /// <summary>
        /// deletes a existing student at the db
        /// </summary>
        public async Task Delete(int id)
        {
            Student student = this.Context.Student.Find(id);

            this.Context.Entry(student).State = EntityState.Deleted;
            await this.Context.SaveChangesAsync();
        }
    }
}
