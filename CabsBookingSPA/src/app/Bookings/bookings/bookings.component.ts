import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { BookingsService } from 'src/app/Core/Services/bookings.service';
import { Booking } from 'src/app/Shared/models/bookings';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent implements OnInit {

  id: number = 0;
  bookings: Booking[] = [];
  constructor(private bookingService: BookingsService,  private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.getCabId(params);
      this.bookingService.getAllBookings(this.id).subscribe(
        b=>{
          this.bookings = b;
          console.table(this.bookings);
        }
      )
    });
    
  }

  getCabId(params: ParamMap):void {
    this.id = parseInt(params.get('id') || "0");
  }

  remove(id: number){
    return this.bookingService.deleteBooking(id).subscribe( r =>
      location.reload()
    );
  }

}
