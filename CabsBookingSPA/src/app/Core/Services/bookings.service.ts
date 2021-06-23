import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { Booking } from 'src/app/Shared/models/bookings';
import { ActivatedRoute } from '@angular/router';
import { AddBooking } from 'src/app/Shared/models/addBooking';
@Injectable({
    providedIn: 'root'
})

export class BookingsService{
    constructor(private apiService: ApiService){ }

    getAllBookings(id: number): Observable<Booking[]>{
        return this.apiService.getAll(`/Cab/${id}/bookings`)
    }
    
    createBooking(booking: AddBooking){
        return this.apiService.create('/Bookings/Insert', booking);
    }

    deleteBooking(id: number){
        return this.apiService.delete('/Bookings/Delete', id);
    }
}