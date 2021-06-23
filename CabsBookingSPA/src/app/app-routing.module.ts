import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookingsComponent } from './Bookings/bookings/bookings.component';
import { HomeComponent } from './Home/home/home.component';
import { PlacesComponent } from './Places/places/places.component';
import { AddBookingComponent } from './Shared/components/addBooking/add-booking/add-booking.component';

const routes: Routes = [
  {path:"", component: HomeComponent},
  {path:"Places", component: PlacesComponent},
  {path:":id/bookings", component: BookingsComponent},
  {path:"booking/add", component: AddBookingComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
