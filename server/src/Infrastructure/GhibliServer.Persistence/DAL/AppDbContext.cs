using GhibliServer.Domain.Entities;
using GhibliServer.Domain.Helper;
using GhibliServer.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Persistence.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketOrder> TicketOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AboutConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new SizeConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new TicketOrderConfiguration());
            modelBuilder.Entity<UserMovie>()
            .HasOne(um => um.AppUser)
            .WithMany(u => u.UserMovies)
            .HasForeignKey(um => um.AppUserId);


            base.OnModelCreating(modelBuilder);

            var roleIds = new Dictionary<RoleEnums, string>();

            foreach (var role in Enum.GetValues(typeof(RoleEnums)))
            {
                var roleName = role.ToString();
                var normalizedRoleName = roleName.ToUpperInvariant();
                var roleId = Guid.NewGuid().ToString();

                modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = roleId, Name = roleName, NormalizedName = normalizedRoleName });

                roleIds.Add((RoleEnums)role, roleId);
            }

            var adminUser = new AppUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                FullName = "Admin",
                OTP = "111114",
                PhoneNumber = "+1234567890",
                PhoneNumberConfirmed = true,
                VerificationRequestId = "ver2",
                ImageUrl = "admin.jpg"
            };

            var superAdminUser = new AppUser
            {
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                EmailConfirmed = true,
                FullName = "Super Admin",
                OTP = "111113",
                PhoneNumber = "+0987654321",
                PhoneNumberConfirmed = true,
                VerificationRequestId = "ver1",
                ImageUrl = "superadmin.jpg"
            };

            var salesManagerUser = new AppUser
            {
                UserName = "salesmanager",
                NormalizedUserName = "SALESMANAGER",
                Email = "salesmanager@gmail.com",
                NormalizedEmail = "SALESMANAGER@GMAIL.COM",
                EmailConfirmed = true,
                FullName = "Sales Manager",
                OTP = "111115",
                PhoneNumber = "+0987654323",
                PhoneNumberConfirmed = true,
                VerificationRequestId = "ver3",
                ImageUrl = "salesmanager.jpg"
            };

            var passwordHasher = new PasswordHasher<AppUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "12345@An");
            superAdminUser.PasswordHash = passwordHasher.HashPassword(superAdminUser, "12345@Sn");
            salesManagerUser.PasswordHash = passwordHasher.HashPassword(salesManagerUser, "12345@Sr");

            modelBuilder.Entity<AppUser>().HasData(adminUser);
            modelBuilder.Entity<AppUser>().HasData(superAdminUser);
            modelBuilder.Entity<AppUser>().HasData(salesManagerUser);

            var adminRoleId = roleIds[RoleEnums.Admin];
            var superAdminRoleId = roleIds[RoleEnums.SuperAdmin];
            var salesManagerRoleId = roleIds[RoleEnums.SalesManager];

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminUser.Id },
                new IdentityUserRole<string> { RoleId = superAdminRoleId, UserId = superAdminUser.Id },
                new IdentityUserRole<string> { RoleId = salesManagerRoleId, UserId = salesManagerUser.Id }
            );

        }
    }
}
