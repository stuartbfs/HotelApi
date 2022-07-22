using HotelDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelDomain.Data.EntityTypeConfigurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.HasOne(x => x.RoomType)
                   .WithMany()
                   .IsRequired();

            builder.HasOne(x => x.Hotel)
                   .WithMany(x => x.Rooms)
                   .IsRequired();
        }
    }
}
