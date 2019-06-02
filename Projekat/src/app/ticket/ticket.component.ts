import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { BuyticketService } from '../buyticket.service';  
import { Ticket } from '../ticket'; 
@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {

  dataSaved = false;  
  employeeForm: any;  
  allEmployees: Observable<Ticket[]>;  
  employeeIdUpdate = null;  
  massage = null;  
  
  constructor(private formbulider: FormBuilder, private employeeService:BuyticketService) { }  
  
  ngOnInit() {  
    this.employeeForm = this.formbulider.group({  
      TimeIssued: ['', [Validators.required]],  
      
    });  
    this.loadAllTickets();  
  }  
  loadAllTickets() {  
    this.allEmployees = this.employeeService.getAllTicket();  
  }  
  onFormSubmit() {  
    this.dataSaved = false;  
    const employee = this.employeeForm.value;  
    this.CreateTicket(employee);  
    this.employeeForm.reset();  
  }  
  loadTicketToEdit(employeeId: string) {  
    this.employeeService.getTicketById(employeeId).subscribe(employee=> {  
      this.massage = null;  
      this.dataSaved = false;  
      this.employeeIdUpdate = employee.Id;  
      this.employeeForm.controls['TimeIssued'].setValue(employee.TimeIssued);  
      
    });  
  
  }  
  CreateTicket(employee: Ticket) {  
    if (this.employeeIdUpdate == null) {  
      this.employeeService.createTicket(employee).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.massage = 'Record saved Successfully';  
          this.loadAllTickets();  
          this.employeeIdUpdate = null;  
          this.employeeForm.reset();  
        }  
      );  
    } else {  
      employee.Id = this.employeeIdUpdate;  
      this.employeeService.updateTicket(employee).subscribe(() => {  
        this.dataSaved = true;  
        this.massage = 'Record Updated Successfully';  
        this.loadAllTickets();  
        this.employeeIdUpdate = null;  
        this.employeeForm.reset();  
      });  
    }  
  }   
  deleteEmployee(employeeId: string) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.employeeService.deleteTicketById(employeeId).subscribe(() => {  
      this.dataSaved = true;  
      this.massage = 'Record Deleted Succefully';  
      this.loadAllTickets();  
      this.employeeIdUpdate = null;  
      this.employeeForm.reset();  
  
    });  
  }  
}  
  resetForm() {  
    this.employeeForm.reset();  
    this.massage = null;  
    this.dataSaved = false;  
  }  
}
