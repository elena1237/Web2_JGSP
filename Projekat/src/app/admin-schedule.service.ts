import { Injectable } from '@angular/core';
import { Schedule } from './models/Schedule';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FormBuilder } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class AdminScheduleService {



  url: string = 'http://localhost:52295/Api/Schedules';
  constructor(private http: HttpClient, private fb: FormBuilder) { }  


  public getAllSchedules(): Promise<Schedule[]>{
   
    return this.http.get<Schedule[]>(this.url + '/AdminSchedules').toPromise();  
  }

  public deleteScheduleById(scheduleId: number): Promise<number> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.delete<number>(this.url + '/DeleteSchedule?id=' +scheduleId,  
 httpOptions).toPromise();  
  }  

  public updateScheduleById(schedule: Schedule): Observable<Schedule> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put<Schedule>(this.url + '/PutSchedule/' +schedule.Id,schedule,  
httpOptions);  

  }

  public createSchedule(schedule: Schedule): Observable<Schedule> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<Schedule>(this.url + '/InsertSchedule',  
    schedule, httpOptions);  
  }  


}