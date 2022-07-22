using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDomain.Queries.RoomAvailability
{
    public class RoomAvailabilityQueryHandler : IQueryHandler<RoomAvailabilityRequest, RoomAvailabilityResponse>
    {
        public Task<RoomAvailabilityResponse> Handle(RoomAvailabilityRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
