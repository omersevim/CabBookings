import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Cab } from 'src/app/Shared/models/cabs'
import { Observable } from 'rxjs';
@Injectable({
    providedIn: 'root'
})

export class CabService{
    constructor(private apiService: ApiService){ }

    getAllCabs(): Observable<Cab[]>{
        return this.apiService.getAll('/Cab')
    }
}