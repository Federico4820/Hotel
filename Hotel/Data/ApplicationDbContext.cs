using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;

namespace Hotel.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(aur => aur.User) 
                .WithMany(au => au.ApplicationUserRole) 
                .HasForeignKey(aur => aur.UserId); 


            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(ur => ur.Role) 
                .WithMany(u => u.ApplicationUserRole) 
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(p => p.CustumerId);

            modelBuilder.Entity<Reservation>()
                .HasOne(re => re.room)
                .WithMany(ro => ro.Reservations)
                .HasForeignKey(re => re.RoomId);
        }
    }
}
