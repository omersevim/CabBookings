using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.ApplicationCore.Entities
{
    public class BookingsHistory
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingTime { get; set; }
        public int FromPlace { get; set; }
        public int ToPlaceId { get; set; }
        public string PickupAddress { get; set; }
        public string Landmark { get; set; }
        public DateTime PickupDate { get; set; }
        public string PickupTime { get; set; }
        public int CabTypeId { get; set; }
        public string ContactNo { get; set; }
        public string Status { get; set; }
        public string CompTime { get; set; }
        public System.Decimal Charge { get; set; }
        public string Feedback { get; set; }
        //navigation
        public Places FromPlaces { get; set; }
        public Places ToPlace { get; set; }
        public CabTypes CabType { get; set; }
    }
}
