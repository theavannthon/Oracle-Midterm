using Microsoft.EntityFrameworkCore;
using OracleProjectMiedterm.Models;

namespace OracleProjectMiedterm.Data
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options) 
        {
 
        }
       
        public DbSet<Customer> Customsers { get; set; }
    }
}
