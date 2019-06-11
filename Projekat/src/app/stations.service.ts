import { Injectable } from '@angular/core';
import { Station } from './models/Station';
import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class StationsService {

  url: string = 'http://localhost:52295/Api/Stations';

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  public createStation(station: Station): Observable<Station> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<Station>(this.url + '/InsertStation',station, httpOptions);  
  }  

  public getAllStations(): Observable<Station[]>{
   
    return this.http.get<Station[]>(this.url + '/AllStations');  
  }

}
