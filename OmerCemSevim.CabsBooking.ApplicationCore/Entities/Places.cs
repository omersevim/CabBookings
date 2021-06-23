﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmerCemSevim.CabsBooking.ApplicationCore.Entities
{
    public class Places
    {
       
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }

        //nav
        public ICollection<Bookings> Bookings { get; set; }
        public ICollection<BookingsHistory> BookingsHistories { get; set; }

    }
}
