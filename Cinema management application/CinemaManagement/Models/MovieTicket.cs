using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaManagement.Models
{
    public class MovieTicket
    {
        public Hall Hall { get; set; }
        public Movie Movie { get; set; }
        public int NumOfSeats { get; set; }
        
    }
}
