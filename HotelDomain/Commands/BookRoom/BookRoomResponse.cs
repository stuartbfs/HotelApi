﻿using HotelDomain.Data.Projections;

namespace HotelDomain.Commands.BookRoom
{
    public class BookRoomResponse
    {
        public BookingDetails[] Details { get; set; }
    }
}