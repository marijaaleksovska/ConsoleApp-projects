using ParkingManagement.Models;

namespace ParkingManagement.Repositories
{
    public class PrepaidTicketRepository : BaseRepository<PrepaidTicket>
    {
        protected override string GetFileName()
        {
            return "PrepaidTickets.txt";
        }
    }
}
