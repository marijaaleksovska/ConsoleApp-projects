using System;
using System.Collections.Generic;
using System.Text;

namespace RentalAgency.Models
{
    public class Agency
    {
        public Agency()
        {
            CarRents = new List<CarRent>();
            ApartmentRents = new List<ApartmentRent>();
            CarsForRent = new List<Car>();
            ApartmentsForRent = new List<Apartment>();
        }
        public string Name { get; set; }
        public List<CarRent> CarRents { get; set; }
        public List<ApartmentRent> ApartmentRents { get; set; }
        public List<Car> CarsForRent { get; set; }
        public List<Apartment> ApartmentsForRent { get; set; }

        public void CreateRent()
        {
            Console.WriteLine("What would you line to rent? Car or Apartment?");
            string rent = Console.ReadLine().ToLower();

            if (rent == "car")
            {
                RentCar();

            }
            else if (rent == "apartment")
            {
                RentApartment();

            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        private void RentApartment()
        {
            Console.WriteLine("Available apartments for rent: ");
            foreach (var apartment in ApartmentsForRent)
            {
                apartment.Print();
            }
            Console.WriteLine("Choose by typing the id of the apartment! ");
            int apartmentID = int.Parse(Console.ReadLine());
            Console.WriteLine("Write you name:");
            string name = Console.ReadLine();
            Console.WriteLine("NumberO of Days:");
            int days = int.Parse(Console.ReadLine());
            var tempApartment = new Apartment();
            foreach (var apartment1 in ApartmentsForRent)
            {
                if (apartment1.ID == apartmentID)
                {
                    tempApartment = apartment1;
                }
            }
            var apartmentRent = new ApartmentRent
            {
                ID = apartmentID,
                LesseeName = name,
                NumberOfDays = days,
                PricePerDay = 20.0,
                Apartment = tempApartment,
                EntryDate = DateTime.Now
            };

            ApartmentRents.Add(apartmentRent);
            ApartmentsForRent.Remove(tempApartment);
        }

        public void ViewAllRevenue()
        {
            CarRentsRevenue();
            ApartmentRentsRevenue();
        }

        public void CarRentsRevenue()
        {
           
            double sum = 0.0;
            foreach (var carRent in CarRents)
            {
                sum += carRent.FullPrice();

            }
            Console.WriteLine($"Car Rent Revenue: {sum}");
        }

        public void CarRentWith140HorsePowersAndAbove()
        {
            Console.WriteLine("Car rents for cars above 140 horsepowers:");
            foreach (var car in CarRents)
            {
                if (car.Car.HorsePowers > 140)
                {
                    car.Print();
                }

            }
        }

        public void ApartmentRentsWith100SquareMetersAndAbove()
        {
            Console.WriteLine("Apartment rents for apartments above 100 square meters:");
            foreach (var apartmentRent in ApartmentRents)
            {
                if (apartmentRent.Apartment.SquareMeters > 100)
                {
                    apartmentRent.Print();
                }

            }
        }

        public void RemoveRentByID()
        {
            Console.Write("Rent ID: ");
            int id = int.Parse(Console.ReadLine());
            var carRent = new CarRent();
            var apartmentRent = new ApartmentRent();
            foreach (var car in CarRents)
            {
                if (car.ID == id)
                {
                    carRent = car;
                }

            }
            foreach (var apartment in ApartmentRents)
            {
                if (apartment.ID == id)
                {
                    apartmentRent = apartment;
                }

            }
            if (carRent != null)
            {
                CarRents.Remove(carRent);
                CarsForRent.Add(carRent.Car);
            }
            else if (apartmentRent != null)
            {
                ApartmentRents.Remove(apartmentRent);
                ApartmentsForRent.Add(apartmentRent.Apartment);

            }
            else
            {
                Console.WriteLine("Rent with this ID does not exist!");
            }
        }

        public void AddApartmentForRent()
        {
            Console.Write("Apartment ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("SquareMeters: ");
            int sm = int.Parse(Console.ReadLine());
            Console.Write("NumberOfRooms");
            int num = int.Parse(Console.ReadLine());
            var apartment = new Apartment
            {
                ID = id,
                Address=address,
                SquareMeters=sm,
                NumberOfRooms=num
            };
            ApartmentsForRent.Add(apartment);
        }

        public void AddCarForRent()
        {
            Console.Write("Car ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("HorsePowers: ");
            int hp = int.Parse(Console.ReadLine());
            Console.Write("Color: ");
            string color = Console.ReadLine();
            var car = new Car
            {
                ID=id,
                Model=model,
                HorsePowers=hp,
                Color=color
            };
            CarsForRent.Add(car);

        }

        public void ViewAllAvailableRents()
        {
            Console.WriteLine("Available Car Rents: ");
            foreach (var car in CarsForRent)
            {
                car.Print();

            }
            Console.WriteLine("Available Apartment Rents: ");
            foreach (var apartment in ApartmentsForRent)
            {
                apartment.Print();

            }
        }

        public void ViewRentByID()
        {
            Console.Write("Rent ID: ");
            int id = int.Parse(Console.ReadLine());
            var carRent = new CarRent();
            var apartmentRent = new ApartmentRent();
            foreach (var car in CarRents)
            {
                if (car.ID == id)
                {
                    carRent = car;
                }

            }
            foreach (var apartment in ApartmentRents)
            {
                if (apartment.ID == id)
                {
                    apartmentRent = apartment;
                }

            }
            if (carRent!=null)
            {
                carRent.Print();
            }
            else if(apartmentRent!=null){
                apartmentRent.Print();

            }
            else
            {
                Console.WriteLine("Rent with this ID does not exist!");
            }
            
        }

        public void ApartmentRentsRevenue()
        {
            double sum = 0.0;
            foreach (var apartmentRent in ApartmentRents)
            {
                sum += apartmentRent.FullPrice();

            }
            Console.WriteLine($"Apartment Rents Revenue: {sum}");
        }

        public void ViewAllApartmentRents()
        {
            Console.WriteLine("Apartment Rents: ");
            foreach (var apartmentRent in ApartmentRents)
            {
                apartmentRent.Print();

            }

        }

        public void ViewAllCarRents()
        {
            Console.WriteLine("Car Rents: ");
            foreach (var carRent in CarRents)
            {
                carRent.Print();
            }

        }

        private void RentCar()
        {

            Console.WriteLine("Available cars for rent: ");
            foreach (var car in CarsForRent)
            {
                car.Print();
            }
            Console.WriteLine("Choose by typing the id of the car! ");
            int carID = int.Parse(Console.ReadLine());
            Console.WriteLine("Write you name:");
            string name = Console.ReadLine();
            Console.WriteLine("NumberO of Days:");
            int days = int.Parse(Console.ReadLine());
            var tempCar = new Car();
            foreach (var car1 in CarsForRent)
            {
                if (car1.ID == carID)
                {
                    tempCar = car1;
                }
            }
            var carRent = new CarRent
            {
                ID = carID,
                LesseeName = name,
                NumberOfDays = days,
                PricePerDay = 20.0,
                Car = tempCar,
                EntryDate = DateTime.Now
            };

            CarRents.Add(carRent);
            CarsForRent.Remove(tempCar);
        }
        public void ViewAllRents()
        {
            ViewAllCarRents();
            ViewAllApartmentRents();
        }
    }
}
