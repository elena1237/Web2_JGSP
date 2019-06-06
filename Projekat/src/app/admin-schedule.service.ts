import { Injectable } from '@angular/core';
import { Schedule } from './models/Schedule';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminScheduleService {

  url: string = 'http://localhost:52295/Api/schedules';
  constructor(private http: HttpClient) { }  

  

  public getAllSchedules(): Promise<Schedule[]>{
   
    return this.http.get<Schedule[]>(this.url + '/AdminSchedules').toPromise();  
  }
}
