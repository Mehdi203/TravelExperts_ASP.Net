using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelExpertTeam2.Models
{
    internal class BookingDetailConfig : IEntityTypeConfiguration<BookingDetail>
    {
        public void Configure(EntityTypeBuilder<BookingDetail> entity)
        {


                entity.HasKey(e => e.BookingDetailId)
                    .HasName("aaaaaBookingDetails_PK")
                    .IsClustered(false);

                entity.Property(e => e.BookingId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductSupplierId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_BookingDetails_Bookings");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_BookingDetails_Classes");

                entity.HasOne(d => d.Fee)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.FeeId)
                    .HasConstraintName("FK_BookingDetails_Fees");

                entity.HasOne(d => d.ProductSupplier)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.ProductSupplierId)
                    .HasConstraintName("FK_BookingDetails_Products_Suppliers");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_BookingDetails_Regions");



        }
    }

}