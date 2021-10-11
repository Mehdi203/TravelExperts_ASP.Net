using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelExpertTeam2.Models
{
    internal class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> entity)
        {


                entity.HasKey(e => e.BookingId)
                    .HasName("aaaaaBookings_PK")
                    .IsClustered(false);

                entity.Property(e => e.PackageId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Bookings_FK00");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("Bookings_FK01");

                entity.HasOne(d => d.TripType)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TripTypeId)
                    .HasConstraintName("Bookings_FK02");
           

        }
    }

}