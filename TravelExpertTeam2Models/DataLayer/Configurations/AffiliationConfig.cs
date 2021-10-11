using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelExpertTeam2.Models
{
    internal class AffiliationConfig : IEntityTypeConfiguration<Affiliation>
    {
        public void Configure(EntityTypeBuilder<Affiliation> entity)
        {

                entity.HasKey(e => e.AffilitationId)
                    .HasName("aaaaaAffiliations_PK")
                    .IsClustered(false);
 
        }
    }

}