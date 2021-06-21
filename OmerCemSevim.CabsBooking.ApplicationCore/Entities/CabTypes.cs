using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.ApplicationCore.Entities
{
    public class CabTypes
    {
        public int CabTypeId { get; set; }
        public string CabTypeName { get; set; }
        //navigation
        public ICollection<BookingsHistory> BookingHistory { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
    }
}
