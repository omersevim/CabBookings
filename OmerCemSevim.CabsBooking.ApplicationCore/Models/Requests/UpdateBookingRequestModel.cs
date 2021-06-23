using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.ApplicationCore.Models.Requests
{
    public class UpdateBookingRequestModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingTime { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public string PickupAddress { get; set; }
        public string Landmark { get; set; }
        public DateTime PickupDate { get; set; }
        public string PickupTime { get; set; }
        public string CabTypeName { get; set; }
        public string ContactNo { get; set; }
        public string Status { get; set; }
    }
}
