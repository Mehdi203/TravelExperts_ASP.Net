using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelExpertTeam2.Models
{
    internal class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> entity)
        {

                entity.HasKey(e => e.ClassId)
                    .HasName("aaaaaClasses_PK")
                    .IsClustered(false);

        }
    }

}