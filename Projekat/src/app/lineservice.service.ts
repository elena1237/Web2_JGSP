import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Line } from './models/Line';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LineserviceService {
  
  private url: string;
  constructor(private client: HttpClient) {
    this.url = "http://localhost:52295/api/Line";
   }

  public createLine(line: Line): Observable<Line> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.client.post<Line>(this.url + '/InsertLine',  
    line, httpOptions);  
  }  


  public getAllLines(): Observable<Line[]>{
   
    return this.client.get<Line[]>(this.url + '/AllLines');  
  }

  public delete(id: number):Observable<Line>{
    return this.client.delete<Line>(this.url + '/DeleteLine' + `/${id}`);
}

public updateLine(ticketType: Line): Observable<Line> {  
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
  return this.client.put<Line>('http://localhost:52295/Api/Line/UpdateLine/' +ticketType.Id,ticketType,  
httpOptions);  

}
}
