 import { Component, OnInit } from '@angular/core';
 import { Cab } from 'src/app/Shared/models/cabs';
 import { CabService } from 'src/app/Core/Services/cab.service';

 @Component({
   selector: 'app-cab-view',
   templateUrl: './cab-view.component.html',
   styleUrls: ['./cab-view.component.css']
 })
 export class CabViewComponent implements OnInit {

   cabs: Cab[] = [];
   constructor(private cabService: CabService) { }

   ngOnInit(): void {
     this.cabService.getAllCabs().subscribe(
       c => {
         this.cabs = c;
       }
     );
   }

 }
