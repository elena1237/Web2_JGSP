import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PriceList } from './models/PriceList';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { Passenger } from './passenger';
import { Ticket } from './ticket';
import { TicketType } from './ticket-type';
import { PassengerType } from './passenger-type';

@Injectable({
  providedIn: 'root'
})
export class PriceListService {
  
  url: string = 'http://localhost:52295/Api/PriceList';
  constructor(private http: HttpClient, private fb: FormBuilder) { }  


  public getAllPassTypes(): Promise<PassengerType[]>{
    return this.http.get<PassengerType[]>('http://localhost:52295/Api/PassengerType/GetAllPT').toPromise<PassengerType[]>();  
  }
  public getAllTicketTypes(): Promise<TicketType[]>{
    return this.http.get<TicketType[]>('http://localhost:52295/Api/TicketType/GetAllTT').toPromise<TicketType[]>();  
  }
  public getAllPriceList(): Promise<PriceList[]>{
    return this.http.get<PriceList[]>('http://localhost:52295/Api/PriceList/GetAllPL').toPromise<PriceList[]>();  
  }


  public getPassengerById(passenger: number): Observable<PassengerType> {  
    return this.http.get<PassengerType>('http://localhost:52295/Api/PassengerType' + '/GetById/' + passenger);  
  }  

  public getTicketById(ticket: number): Observable<TicketType> {  
    return this.http.get<TicketType>('http://localhost:52295/Api/TicketType' + '/GetById/' + ticket);  
  } 


  
  public createPriceList(priceList: PriceList): Observable<PriceList> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<PriceList>(this.url + '/InsertPriceList',  
    priceList, httpOptions);  
  }  

  public updatePassengerTypeById(passengerType: PassengerType): Observable<PassengerType> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put<PassengerType>('http://localhost:52295/Api/PassengerType/PutPassengerType/' +passengerType.Id,passengerType,  
httpOptions);  

  }

  public updateTicketTypeById(ticketType: TicketType): Observable<TicketType> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put<TicketType>('http://localhost:52295/Api/TicketType/PutTicketType/' +ticketType.Id,ticketType,  
httpOptions);  

  }
  
}
