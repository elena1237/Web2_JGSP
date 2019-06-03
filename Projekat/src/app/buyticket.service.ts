import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import {Ticket} from './ticket';

@Injectable({
  providedIn: 'root'
})
export class BuyticketService {

  url: string = 'http://localhost:52295/Api/ticket';
  constructor(private http: HttpClient) { }  
  getAllTicket(): Observable<Ticket[]> {  
    return this.http.get<Ticket[]>(this.url + '/AllTicket');  
  }  
  getTicketById(employeeId: string): Observable<Ticket> {  
    return this.http.get<Ticket>(this.url + '/GetById/' + employeeId);  
  }  
  createTicket(employee: Ticket): Observable<Ticket> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<Ticket>(this.url + '/InsertTicket/',  
    employee, httpOptions);  
  }  
  updateTicket(employee: Ticket): Observable<Ticket> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put<Ticket>(this.url + '/UpdateTicket/',  
    employee, httpOptions);  
  }  
  deleteTicketById(employeeid: string): Observable<number> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.delete<number>(this.url + '/DeleteTicket?id=' +employeeid,  
 httpOptions);  
  }  
}  

