import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PagedResults } from 'src/app/Shared/models/pagedResults';

@Injectable({
    providedIn: 'root'
})

export class ApiService{
    private headers: HttpHeaders;

    /**
     *
     */
    constructor(protected http: HttpClient) {
        this.headers = new HttpHeaders();
        this.headers.append('Content-Type', 'application/json');
    }

    getAll(path:string):Observable<any[]> {
        console.log(`${environment.apiUrl}${path}`);
        return this.http.get(`${environment.apiUrl}${path}`).pipe(map(resp=>resp as any[]),catchError(this.handleError))
    }

    private handleError(error: HttpErrorResponse){
        //A client-side or network error occured.
        if(error.error instanceof ErrorEvent){
            console.error('An error occured:', error.error.message);
        }
        //backend returned an unsuccessful response code.
        //the response body may contain clues as to what is wrong.
        else{
            console.log(error.error.errorMessage);
            console.error(`Backend returned code ${error.status}, ` + `body was: ${error.message}`);
        }
        //return an observable with a user facing error message.
        return throwError(error.error.errorMessage);
        
    }

    delete(path: string, id: number){
        return this.http.delete(`${environment.apiUrl}${path}`).pipe(
            map(response=>response), catchError(this.handleError)
        );
    }

    create(path: string, resource, options?): Observable<any> {
        return this.http
          .post(`${environment.apiUrl}${path}`, resource, { headers: this.headers })
          .pipe(
            map(response => response),
            catchError(this.handleError)
          );
      }
}