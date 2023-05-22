using Microsoft.EntityFrameworkCore;

namespace dm_ef_api.Models
{
    public class AssignamentContext : DbContext
    {
        public AssignamentContext(DbContextOptions<AssignamentContext> options)
           : base(options)
        {

        }

        public virtual DbSet<Assignament> Assignament { get; set; } = null!;
    }
}
