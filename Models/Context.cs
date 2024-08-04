using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_commrec.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context()
        {

        }


        public Context(DbContextOptions<Context> options)
           : base(options)
        {

        }
        
        public DbSet<Order> orders { get; set; }
        public DbSet<Prouduct> prouducts { get; set; }
        public DbSet<CarPurshase> carPurshases { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }



            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {

            optionsBuilder.UseSqlServer(@"Data source=.;Initial catalog=ECommrec;Integrated security=true");
            base.OnConfiguring(optionsBuilder);
            }
    }
}
