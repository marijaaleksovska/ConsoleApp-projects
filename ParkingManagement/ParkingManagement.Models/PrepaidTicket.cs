using System;

namespace ParkingManagement.Models
{
    public class PrepaidTicket
    {
        public int Id { get; set; }
        public string CarRegistrationNumber { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public double Price { get; set; }
    }
}
