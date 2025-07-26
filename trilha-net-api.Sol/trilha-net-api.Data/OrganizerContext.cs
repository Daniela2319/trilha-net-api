using Microsoft.EntityFrameworkCore;
using trilha_net_api.Models;


namespace trilha_net_api.Data
{
    public class OrganizerContext : DbContext
    {
        public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options)
        {}
        public DbSet<TaskA> Tasks { get; set; }
    }
       

        
}
