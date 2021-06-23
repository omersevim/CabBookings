import { Component, OnInit } from '@angular/core';
import { CabService } from 'src/app/Core/Services/cab.service';
import { Cab } from 'src/app/Shared/models/cabs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  cabs: Cab[] = [];
  constructor(private cabService: CabService) { }

  ngOnInit(): void {
    this.cabService.getAllCabs().subscribe(
      c => {
        this.cabs = c;
        console.table(this.cabs)
      }
    );
  }

  private getCabs(){}


}
