using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDomain.Data.Entities
{
    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
