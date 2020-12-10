using System;
using System.Collections.Generic;
using System.Text;

namespace RentalAgency.Models
{
    public class ApartmentRent
    {
        public int ID { get; set; }
        public string LesseeName { get; set; }
        public int NumberOfDays { get; set; }
        public double PricePerDay { get; set; }
        public Apartment Apartment { get; set; }
        public DateTime EntryDate { get; set; }
        public double FullPrice()
        {
            if (Apartment.SquareMeters > 100)
            {
                var p = (PricePerDay * NumberOfDays) * 0.05;
                return (PricePerDay * NumberOfDays) - p;

            }
            else
            {
                return PricePerDay * NumberOfDays;
            }

            
        }
        public void Print()
        {
            Console.WriteLine($" {EntryDate}: {LesseeName} - {NumberOfDays}X{PricePerDay}=${FullPrice()} ");
        }

    }
}

