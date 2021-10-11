using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelExpertTeam2.Models
{
    internal class PackageCustomerConfig : IEntityTypeConfiguration<PackageCustomer>
    {
        public void Configure(EntityTypeBuilder<PackageCustomer> entity)
        {
            entity.HasKey(e => new { e.PackageId, e.CustomerId });



            entity.HasOne(d => d.Customer)
                .WithMany(p => p.PackageCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PackageCustomer_Customer");

            entity.HasOne(d => d.Package)
                .WithMany(p => p.PackageCustomers)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_PackageCustomer_Package");
        }
    }

}