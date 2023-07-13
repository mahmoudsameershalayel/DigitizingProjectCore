using DigitizingProjectCore.Data.Constrains;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitizingProjectCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            //Applay constrains
            Builder.ApplyConfiguration(new SolutionProductsConstrains());
            Builder.ApplyConfiguration(new AdminLinksConstrains());


            //GUID
            string Admin_Role_Id = "9a00de05-ab2c-4692-82b2-d33f0f50eb7e";
            string Admin_User_Id = "f1446937-109c-4e1a-97ce-0560442484f5";


            //Add Role
            Builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Admin_Role_Id,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = Admin_Role_Id

            });

            //Add Admin User
            var adminUser = new ApplicationUser
            {
                Id = Admin_User_Id,
                FullName = "System Administrator",
                Email = "Administrator@admin.com",
                NormalizedEmail = "ADMINISTRATOR@ADMIN.COM",
                UserName = "System_Administrator",
                Phone = "97259000000"
            };

            //Password Hasher
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "123456");
            Builder.Entity<ApplicationUser>().HasData(adminUser);
            //Add Role To AdminUser
            Builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = Admin_Role_Id,
                    UserId = Admin_User_Id
                }
                );

            base.OnModelCreating(Builder);
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryForProduct> CategoryForProducts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<CategoryForNews> CategoryForNews { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<CategoryForService> CategoryForServices { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<AdminLinks> AdminLinks { get; set; }
        public DbSet<SolutionProducts> SolutionProducts { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}