# Hotel Room Booking Example
Api backend for a Hotel booking system.

## Assumptions
- Deluxe rooms can have 2 people in them

## Limitations:
- Hotels do not have any location data (e.g. Address, Post code)
- Rooms are all labelled Room 101 - 106
- Hotels have 6 rooms (based on seed data), for this example each hotel has 2 single rooms, 3 double rooms and 1 deluxe room
- Bookings can only be for 1 room at a time
- Bookings only capture the name of the person booking the room

## Libraries used:
- EF Core for querying / saving data to a SQL Server database
- FluentValidation for validation of incoming requests
- Mediatr library for enforcing message based architecture
- Swashbuckle for swagger UI (I haven't documented each of the api's in-code)

Hosted on Azure using Managed Identity for the database connection. Available at https://sm-hotelapi.azurewebsites.net/swagger/index.html

## API Endpoints

Find a hotel based on it's name
```
GET /api/hotel?name={name}
```

Find available rooms between two dates for a given number of people

All hotels version
```
GET /api/rooms/availability?checkIn={checkInDate}&checkOut={checkOutDate}&partySize={partySize}
```

Hotel specific version
```
GET /api/rooms/{hotelId}/availability?checkIn={checkInDate}&checkOut={checkOutDate}&partySize={partySize}
```


Book room
```
POST /api/booking/{hotelId}

Body: {
   firstName: string,
   lastName: string,
   checkIn: date,
   checkOut: date,
   partySize: number,
   roomType: [Single, Double or Deluxe]
}
```

Find booking details based on booking ref number
```
GET /api/booking?bookingRef={bookingRef}
```

Populating database with just enough data for testing (creates test hotels) is achieved through API endpoint
```
POST /api/admin/seed
```

Resetting the database (deleting all data)
```
POST /api/admin/reset
```
