﻿namespace HotelDomain.Data.Entities
{
    public class Room
    {
        public Guid RoomId { get; set; }

        public string Name { get; set; }

        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public Guid RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
    }
}