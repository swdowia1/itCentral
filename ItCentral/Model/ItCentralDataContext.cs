using Microsoft.EntityFrameworkCore;

namespace ItCentral.Model
{
    public class ItCentralDataContext: DbContext
    {


        public ItCentralDataContext(DbContextOptions<ItCentralDataContext> options)
         : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}
