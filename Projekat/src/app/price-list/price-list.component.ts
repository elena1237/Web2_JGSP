import { Component, OnInit } from '@angular/core';
import { PriceListService } from '../price-list.service';
import { FormBuilder, Validators } from '@angular/forms';
import { PriceList } from '../models/PriceList';
import { DatePicker } from '../models/DatePicker';
import { Passenger } from '../passenger';
import { Ticket } from '../ticket';
import { Observable } from 'rxjs';
import { PassengerType } from '../passenger-type';
import { TicketType } from '../ticket-type';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-price-list',
  templateUrl: './price-list.component.html',
  styleUrls: ['./price-list.component.css']
})


export class PriceListComponent implements OnInit {
  Students = {
      dob:'',
      dob2:''

  }

  public priceList: PriceList;
  public model: DatePipe;
  public model2: DatePipe;
  public passengers: Observable<PassengerType>;
  public tickets: Observable<TicketType>;
  public basePrice: number;
  public discount: number;
  public ticketType: TicketType;
  public passengerType: PassengerType;
  public ticketTypeHelp:TicketType;
  public passTypeHelp : PassengerType;
  


  sklForm = this.fb.group({
    ticket: ['', Validators.required],
    passenger: ['', Validators.required],
    //to: [''],
    //from: [''],
    basePrice: ['', Validators.required],
    discount: ['', Validators.required],



  });

  
  TicketType:Array<Object> = [
    {name: "Dnevna"},
    {name: "Mesecna"},
    {name: "Godisnja"},
    {name: "Vremenska"},
  
  ];

  PassengerType:Array<Object> = [
    {name: "Penzioner"},
    {name: "Student"},
    {name: "Regularni"},
  
  ];

  constructor(private priceListService: PriceListService,private fb: FormBuilder) { }

  ngOnInit() {

  }

  // public onDate(selectedSchedule: any)
  // {
  //   let nesto = selectedSchedule;
    

  // }
  public AddSubmit(){

     let to = this.model;
     let from = this.model2;
     let tick = this.sklForm.controls['ticket'].value;
     let pas = this.sklForm.controls['passenger'].value;
     let basePrice = this.sklForm.controls['basePrice'].value;
     let discount = this.sklForm.controls['discount'].value;
  
     let pasId;
     if(pas =="Student")
     {
      pasId = 1;      
     }
     else if(pas == "Penzioner")
     {
      pasId = 2;     
      }
      else
      {
        pasId = 3;
      }
   
      let ticketId;
      if(tick =="Vremenska")
      {
        ticketId = 1;      
      }
      else if(tick == "Dnevna")
      {
        ticketId = 2;     
       }
       else if(tick == "Mesecna")
       {
        ticketId = 3;
       }else{

        ticketId = 4;

       }

       this.tickets = this.priceListService.getTicketById(ticketId);


       
       this.tickets.forEach(element => {
         if(element.Id==ticketId)
          this.ticketTypeHelp=new TicketType(element.Id,element.Name,element.Price);
   
       });
   

       //let nesto=this.ticketTypeHelp.Id;
       //let idTT=nesto.Id;
       //let nameTT=this.ticketTypeHelp.Name;


      this.ticketType = new TicketType(this.ticketTypeHelp.Id,this.ticketTypeHelp.Name,basePrice);
       this.priceListService.updateTicketTypeById(this.ticketType).subscribe((data) => {
       });


       this.passengers =  this.priceListService.getPassengerById(pasId); 
       let namePas;
       let idP;
       this.passengers.forEach(element => {
        if(element.Id==pasId)
          this.passTypeHelp=new PassengerType(element.Id,element.Name,element.Discount);
         
         });

       //let nesto2=this.passTypeHelp.Id;
       //let name2 = this.passTypeHelp.Name;
       this.passengerType = new PassengerType(this.passTypeHelp.Id,this.passTypeHelp.Name,discount);
       this.priceListService.updatePassengerTypeById(this.passengerType).subscribe((data) => {
       });

       const d = new DatePipe('en-US').transform(this.Students.dob,'dd/MM/yyyy');
       const d2 = new DatePipe('en-US').transform(this.Students.dob2,'dd/MM/yyyy')

       let price = basePrice*discount;
      this.priceList = new PriceList(1, d,d2,pasId,price,ticketId,true);
  
       this.priceListService.createPriceList(this.priceList).subscribe(  
         () => {  
           
         }  
       );  
     } 
    
}
