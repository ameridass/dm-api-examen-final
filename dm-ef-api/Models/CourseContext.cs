using Microsoft.EntityFrameworkCore;

namespace dm_ef_api.Models
{
    public class CourseContext: DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Course> Course { get; set; } = null!;
    }
}
