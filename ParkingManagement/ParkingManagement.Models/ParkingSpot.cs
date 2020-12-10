using System;

namespace ParkingManagement.Models
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public string CarRegistrationNumber { get; set; }
        public DateTime? ParkingStarted{ get; set; }
        public bool IsAvailable { 
            get 
            { 
                return CarRegistrationNumber == null && ParkingStarted == null; 
            } 
        }
    }
}
