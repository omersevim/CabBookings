import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Core/Layout/Header/header/header.component';
import { HomeComponent } from './Home/home/home.component';
import { CabViewComponent } from './Cabs/cab-view/cab-view.component';
import { PlacesComponent } from './Places/places/places.component';
import { BookingsComponent } from './Bookings/bookings/bookings.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AddBookingComponent } from './Shared/components/addBooking/add-booking/add-booking.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    CabViewComponent,
    PlacesComponent,
    BookingsComponent,
    AddBookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
