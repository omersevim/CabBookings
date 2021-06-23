import { Component, Input, OnInit, Output } from '@angular/core';
import { BookingsService } from 'src/app/Core/Services/bookings.service';
import { AddBooking } from 'src/app/Shared/models/addBooking';
import { Booking } from 'src/app/Shared/models/bookings';

@Component({
  selector: 'app-add-booking',
  templateUrl: './add-booking.component.html',
  styleUrls: ['./add-booking.component.css']
})
export class AddBookingComponent implements OnInit {

  @Input() booking : AddBooking = {
    email: '',
    bookingDate: new Date(),
    bookingTime: new Date().getHours().toString(),
    fromPlace: '',
    toPlace: '',
    pickupAddress: '',
    landmark: '',
    pickupDate: new Date(),
    pickupTime: '',
    contactNo: '',
    cabTypeName: '',
    status: 'Booked'
  };
  constructor(private bookingService: BookingsService) { }

  ngOnInit(): void {
   
  }
  createBooking(){
    this.bookingService.createBooking(this.booking).subscribe(
      b =>{
        this.booking = b;
        console.log(this.booking);
      }
    )
  }

  

}
