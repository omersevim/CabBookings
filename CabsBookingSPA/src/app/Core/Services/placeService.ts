import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Places } from 'src/app/Shared/models/places'
import { Observable } from 'rxjs';
@Injectable({
    providedIn: 'root'
})

export class PlaceService{
    constructor(private apiService: ApiService){ }

    getAllPlaces(): Observable<Places[]>{
        return this.apiService.getAll('/Places')
    }
}