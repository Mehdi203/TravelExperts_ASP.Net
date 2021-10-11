using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

#nullable disable

namespace TravelExpertTeam2.Models
{
    public partial class TravelExpertsContext : IdentityDbContext<User>
    {

        public TravelExpertsContext(DbContextOptions<TravelExpertsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Affiliation> Affiliations { get; set; }
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomersReward> CustomersRewards { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackagesProductsSupplier> PackagesProductsSuppliers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsSupplier> ProductsSuppliers { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierContact> SupplierContacts { get; set; }
        public virtual DbSet<TripType> TripTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");



            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("aaaaaCustomers_PK")
                    .IsClustered(false);

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK_Customers_Agents");
            });

            modelBuilder.Entity<CustomersReward>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.RewardId })
                    .HasName("aaaaaCustomers_Rewards_PK")
                    .IsClustered(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomersRewards)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customers_Rewards_FK00");

                entity.HasOne(d => d.Reward)
                    .WithMany(p => p.CustomersRewards)
                    .HasForeignKey(d => d.RewardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customers_Rewards_FK01");
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.HasKey(e => e.FeeId)
                    .HasName("aaaaaFees_PK")
                    .IsClustered(false);
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasKey(e => e.PackageId)
                    .HasName("aaaaaPackages_PK")
                    .IsClustered(false);

                entity.Property(e => e.PkgAgencyCommission).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PackagesProductsSupplier>(entity =>
            {
                entity.HasKey(e => new { e.PackageId, e.ProductSupplierId })
                    .HasName("aaaaaPackages_Products_Suppliers_PK")
                    .IsClustered(false);

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackagesProductsSuppliers)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Packages_Products_Supplie_FK00");

                entity.HasOne(d => d.ProductSupplier)
                    .WithMany(p => p.PackagesProductsSuppliers)
                    .HasForeignKey(d => d.ProductSupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Packages_Products_Supplie_FK01");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("aaaaaProducts_PK")
                    .IsClustered(false);
            });

            modelBuilder.Entity<ProductsSupplier>(entity =>
            {
                entity.HasKey(e => e.ProductSupplierId)
                    .HasName("aaaaaProducts_Suppliers_PK")
                    .IsClustered(false);

                entity.Property(e => e.ProductId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsSuppliers)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("Products_Suppliers_FK00");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ProductsSuppliers)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("Products_Suppliers_FK01");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .HasName("aaaaaRegions_PK")
                    .IsClustered(false);
            });

            modelBuilder.Entity<Reward>(entity =>
            {
                entity.HasKey(e => e.RewardId)
                    .HasName("aaaaaRewards_PK")
                    .IsClustered(false);

                entity.Property(e => e.RewardId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("aaaaaSuppliers_PK")
                    .IsClustered(false);
            });

            modelBuilder.Entity<SupplierContact>(entity =>
            {
                entity.HasKey(e => e.SupplierContactId)
                    .HasName("aaaaaSupplierContacts_PK")
                    .IsClustered(false);

                entity.Property(e => e.SupplierContactId).ValueGeneratedNever();

                entity.Property(e => e.SupplierId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Affiliation)
                    .WithMany(p => p.SupplierContacts)
                    .HasForeignKey(d => d.AffiliationId)
                    .HasConstraintName("SupplierContacts_FK00");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierContacts)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("SupplierContacts_FK01");
            });

            modelBuilder.Entity<TripType>(entity =>
            {
                entity.HasKey(e => e.TripTypeId)
                    .HasName("aaaaaTripTypes_PK")
                    .IsClustered(false);
            });

            //Configuration

            modelBuilder.ApplyConfiguration(new AffiliationConfig());
            modelBuilder.ApplyConfiguration(new AgentConfig());
            modelBuilder.ApplyConfiguration(new BookingConfig());
            modelBuilder.ApplyConfiguration(new BookingDetailConfig());
            modelBuilder.ApplyConfiguration(new ClassConfig());
            modelBuilder.ApplyConfiguration(new CreditCardConfig());
            modelBuilder.ApplyConfiguration(new PackageCustomerConfig());

            OnModelCreatingPartial(modelBuilder);
        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                //Resolve ASP .NET Core Identity with DI help
                UserManager<User> userManager = (UserManager<User>)
                    scope.ServiceProvider.GetService(typeof(UserManager<User>));
                RoleManager<IdentityRole> roleManager = (RoleManager<IdentityRole>)
                    scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>));

                string username = "admin";
                string password = "admin";
                string roleName = "Admin";
                await CreateUser_Role(userManager, roleManager, username, password, roleName);

                username = "customer";
                password = "customer";
                roleName = "Customer";
                await CreateUser_Role(userManager, roleManager, username, password, roleName);

                username = "agent";
                password = "agent";
                roleName = "Agent";
                await CreateUser_Role(userManager, roleManager, username, password, roleName);
            }
        }

        private static async Task CreateUser_Role(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, string username, string password, string roleName)
        {
            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // if username doesn't exist, create it and add to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
