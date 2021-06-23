import { Component, OnInit } from '@angular/core';
import { PlaceService } from 'src/app/Core/Services/placeService';
import { Places } from 'src/app/Shared/models/places';

@Component({
  selector: 'app-places',
  templateUrl: './places.component.html',
  styleUrls: ['./places.component.css']
})
export class PlacesComponent implements OnInit {

  places: Places[] = [];
  constructor(private placeService: PlaceService) { }

  ngOnInit(): void {
    this.placeService.getAllPlaces().subscribe(
      p => {
        this.places = p;
        console.table(this.places);
      }
    )
  }

}
