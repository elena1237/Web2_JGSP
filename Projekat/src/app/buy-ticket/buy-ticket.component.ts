import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs/internal/Observable';
import { BuyticketService } from '../buyticket.service';
import { Ticket } from '../ticket';
import { Email } from '../models/Email';

@Component({
  selector: 'app-buy-ticket',
  templateUrl: './buy-ticket.component.html',
  styleUrls: ['./buy-ticket.component.css']
})
export class BuyTicketComponent implements OnInit {
  public email:Email = new Email;
  

  buyForm = this.fb.group({
    email: ['', Validators.required]
  })
  constructor(private buyTicketService:BuyticketService, private fb:FormBuilder) { }  
  
  ngOnInit() {  
    
  } 
      
  createTicket() { 
        this.email.Value=this.buyForm.controls['email'].value;
        this.buyTicketService.createTicketNotRegisteredUser(this.email).subscribe(  
          () => {  
            
          }  
        );  
      }        
  }  
  
  
   
  


