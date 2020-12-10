using ParkingManagement.Models;
using System;

namespace ParkingManagement.Repositories
{
    public class ParkingSpotRepository : BaseRepository<ParkingSpot>
    {
        protected override string GetFileName()
        {
            return "ParkingSpots.txt";
        }

        public void Seed()
        {
            for (int i = 1; i < 21; i++)
            {
                var current = new ParkingSpot();
                current.Id = i;

                if(i % 2 ==0)
                {
                    current.CarRegistrationNumber = $"asd{i}";
                    current.ParkingStarted = DateTime.Now;
                }

                Add(current);
            }

            SaveChanges();
        }
    }
}
