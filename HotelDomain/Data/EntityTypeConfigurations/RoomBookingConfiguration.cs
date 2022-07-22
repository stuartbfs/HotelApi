using HotelDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelDomain.Data.EntityTypeConfigurations
{
    public class RoomBookingConfiguration : IEntityTypeConfiguration<RoomBooking>
    {
        public void Configure(EntityTypeBuilder<RoomBooking> builder)
        {
            builder.HasOne(x => x.Room)
                   .WithMany()
                   .IsRequired();
        }
    }
}
