namespace DataAccess.Contracts
{
    using Microsoft.EntityFrameworkCore;
    using Model;

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)  :base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
    }
}
