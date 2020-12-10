using System;
using System.Collections.Generic;
using System.Text;

namespace RentalAgency.Models
{
    public class CarRent
    {
        
        public int ID { get; set; }
        public string LesseeName { get; set; }
        public int NumberOfDays { get; set; }
        public double PricePerDay { get; set; }
        public Car Car { get; set; }
        public DateTime EntryDate { get; set; }
        public double FullPrice()
        {
            if (Car.HorsePowers>140)
            {
                return (PricePerDay * NumberOfDays) + 20.0;
            }
            else
            {
                return PricePerDay * NumberOfDays;
            }
        }
        public void Print()
        {
            Console.WriteLine($" {EntryDate}: {LesseeName} - {NumberOfDays}X{PricePerDay}= ${FullPrice()} ");
        }
    }
}
