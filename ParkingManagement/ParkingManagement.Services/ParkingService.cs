using ParkingManagement.Common.Exceptions;
using ParkingManagement.Models;
using ParkingManagement.Repositories;
using System;
using System.Linq;

namespace ParkingManagement.Services
{
    public class ParkingService
    {
        private const double monthlyPrice = 1500;
        private const double hourlyPrice = 30;
        private PrepaidTicketRepository PrepaidTicketRepository { get; set; }
        private ParkingSpotRepository ParkingSpotRepository { get; set; }

        public ParkingService()
        {
            PrepaidTicketRepository = new PrepaidTicketRepository();
            ParkingSpotRepository = new ParkingSpotRepository();
        }

        public void Park()
        {
            Console.WriteLine("Please choose parking spot");
            ParkingSpotRepository
                .GetAllWhere(x => x.IsAvailable == true)
                .ForEach(x => Console.WriteLine(x.Id));

            int.TryParse(Console.ReadLine(), out int userSpotInput);


            var parkingSpot = ParkingSpotRepository.GetFirstWhere(x => x.IsAvailable && x.Id == userSpotInput);

            if (parkingSpot == null)
            {
                throw new FlowException("Invalid spot number");
            }

            Console.WriteLine("Enter 1 for prepaid or 2 for hourly");
            int.TryParse(Console.ReadLine(), out int userParkType);

            switch (userParkType)
            {
                case 1:
                    ParkPrepaid(parkingSpot);
                    break;
                case 2:
                    ParkHourly(parkingSpot);
                    break;
                default:
                    throw new FlowException("Invalid park type");
                    break;
            }
        }

        public void Leave()
        {
            Console.WriteLine("Please eneter registration number");
            var inputRegistrationNumber = Console.ReadLine();

            var parkingSpot = ParkingSpotRepository.GetFirstWhere(x => x.CarRegistrationNumber == inputRegistrationNumber);

            if(parkingSpot == null)
            {
                throw new FlowException("Invalid number");
            }

            var prepaidTicket = PrepaidTicketRepository.GetFirstWhere(x => x.CarRegistrationNumber == inputRegistrationNumber && x.ValidTo > DateTime.Now);

            var parkingDuration = DateTime.Now.Subtract(parkingSpot.ParkingStarted.Value).TotalHours;
            var roundedDuration = Math.Ceiling(parkingDuration);

            if (prepaidTicket != null)
            {
                Console.WriteLine($"You have been parked for {roundedDuration} hours");
            }
            else
            {
                Console.WriteLine($"You have been parked for {roundedDuration} hours. Price {roundedDuration * hourlyPrice}");
            }

            parkingSpot.CarRegistrationNumber = null;
            parkingSpot.ParkingStarted = null;
            ParkingSpotRepository.SaveChanges();
        }

        private void ParkHourly(ParkingSpot parkingSpot)
        {
            Console.WriteLine("Please eneter car registration");
            var inputCarRegistration = Console.ReadLine();

            var parkingSpotAvailable = ParkingSpotRepository.GetFirstWhere(x => x.CarRegistrationNumber == inputCarRegistration);

            if (parkingSpotAvailable != null)
            {
                throw new FlowException($"Car with registration {inputCarRegistration} is already parked");
            }

            parkingSpot.CarRegistrationNumber = inputCarRegistration;
            parkingSpot.ParkingStarted = DateTime.Now;
            ParkingSpotRepository.SaveChanges();
        }


        private void ParkPrepaid(ParkingSpot parkingSpot)
        {
            Console.WriteLine("Please eneter ticket id");
            int.TryParse(Console.ReadLine(), out int inputTicketId);

            Console.WriteLine("Please eneter car registration");
            var inputCarRegistration = Console.ReadLine();

            var parkingSpotAvailable = ParkingSpotRepository.GetFirstWhere(x => x.CarRegistrationNumber == inputCarRegistration);

            if(parkingSpotAvailable != null)
            {
                throw new FlowException($"Car with registration {inputCarRegistration} is already parked");
            }

            var dbTicket = PrepaidTicketRepository
                .GetFirstWhere(x => x.CarRegistrationNumber == inputCarRegistration && x.Id == inputTicketId && x.ValidTo > DateTime.Now);

            if (dbTicket == null)
            {
                throw new FlowException("Invalid prepaid ticket");
            }

            parkingSpot.CarRegistrationNumber = inputCarRegistration;
            parkingSpot.ParkingStarted = DateTime.Now;
            ParkingSpotRepository.SaveChanges();
        }

        public void BuyPrepaidTicket()
        {
            Console.WriteLine("Please enter your car registration nummber");
            var inputCarRegstration = Console.ReadLine().ToUpper();

            var prepaidTicketDB = PrepaidTicketRepository
                .GetFirstWhere(x => x.CarRegistrationNumber == inputCarRegstration && x.ValidTo > DateTime.Now);

            if (prepaidTicketDB != null)
            {
                throw new FlowException($"There is valid prepaid ticket with registration number {inputCarRegstration}");
            }

            Console.WriteLine("Please enter number of months you would like to park");
            int.TryParse(Console.ReadLine(), out int numberOfMonths);

            if (numberOfMonths == 0)
            {
                throw new FlowException("Invalid number of months");
            }

            var totalPrice = numberOfMonths * monthlyPrice;
            var newParkingTicket = new PrepaidTicket();
            int maxId = GemeratePrepaidTicketId();
            newParkingTicket.CarRegistrationNumber = inputCarRegstration;
            newParkingTicket.ValidFrom = DateTime.Now;
            newParkingTicket.ValidTo = DateTime.Now.AddMonths(numberOfMonths);
            newParkingTicket.Price = totalPrice;
            newParkingTicket.Id = maxId;

            PrepaidTicketRepository.Add(newParkingTicket);
            PrepaidTicketRepository.SaveChanges();
            Console.WriteLine($"Total price is {totalPrice}. Your ticket id is {newParkingTicket.Id}");
        }

        private int GemeratePrepaidTicketId()
        {
            var allTickets = PrepaidTicketRepository.GetAll();

            var maxId = 0;

            if (allTickets.Any())
            {
                maxId = allTickets.Max(x => x.Id);
            }

            maxId += 1;
            return maxId;
        }
    }
}
