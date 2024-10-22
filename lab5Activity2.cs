using System;
using System.Collections.Generic;

namespace AirlineReservationSystem
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Relationships
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }

    public class RetailCustomer : Customer
    {
        public string CreditCardType { get; set; }
        public string CreditCardNo { get; set; }
    }

    public class CorporateCustomer : Customer
    {
        public string CompanyName { get; set; }
        public int FrequentFlyerPts { get; set; }
        public string BillingAccountNo { get; set; }
    }

    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }

        // Relationships
        public Customer Customer { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
    }

    public class Seat
    {
        public int RowNo { get; set; }
        public int SeatNo { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public Flight Flight { get; set; }
    }

    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime Date { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int SeatingCapacity { get; set; }

    }
        public List<Seat> Seats { get; set; } = new List<Seat