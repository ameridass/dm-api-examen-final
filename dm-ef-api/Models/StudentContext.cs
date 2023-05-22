using Microsoft.EntityFrameworkCore;

namespace dm_ef_api.Models
{
    public class StudentContext: DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) 
            : base(options)
        {

        }

        public virtual DbSet<Student> Students { get; set; } = null!;
    }
}
