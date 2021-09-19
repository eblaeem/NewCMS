using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CMSContext: DbContext
    {
        public CMSContext(DbContextOptions<CMSContext> options) : base(options)
        {

        }

        public DbSet<PageGroup> PageGroups { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<PageComment> PageComments { get; set; }

    }

}
