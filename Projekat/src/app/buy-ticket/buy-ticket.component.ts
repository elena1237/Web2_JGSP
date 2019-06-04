import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs/internal/Observable';
import { BuyticketService } from '../buyticket.service';
import { Ticket } from '../ticket';

@Component({
  selector: 'app-buy-ticket',
  templateUrl: './buy-ticket.component.html',
  styleUrls: ['./buy-ticket.component.css']
})
export class BuyTicketComponent implements OnInit {

   
  // employeeForm: any;  
  
  // allEmployees: Observable<Ticket[]>;  
  // employeeIdUpdate = null;  
  // massage = null;  
  
  constructor(private buyTicketService:BuyticketService) { }  
  
  ngOnInit() {  
    // this.employeeForm = this.formbulider.group({  
    //   TimeIssued:
  } 
    // this.loadAllEmployees();  
  createTicket(ticket: Ticket) { 

        this.buyTicketService.createTicketNotRegisteredUser().subscribe(  
          () => {  
            
          }  
        );  
      }        
  }  
  
  
//   loadAllEmployees() {  
//     this.allEmployees = this.employeeService.getAllEmployee();  
//   }  
//   onFormSubmit() {  
//     this.dataSaved = false;  
//     const employee = this.employeeForm.value;  
//     this.CreateEmployee(employee);  
//     this.employeeForm.reset();  
//   }  
//     
  
//     
//   CreateEmployee(employee: Employee) {  
//     if (this.employeeIdUpdate == null) {  
//       this.employeeService.createEmployee(employee).subscribe(  
//         () => {  
//           this.dataSaved = true;  
//           this.massage = 'Record saved Successfully';  
//           this.loadAllEmployees();  
//           this.employeeIdUpdate = null;  
//           this.employeeForm.reset();  
//         }  
//       );  
//     } else {  
//       employee.EmpId = this.employeeIdUpdate;  
//       this.employeeService.updateEmployee(employee).subscribe(() => {  
//         this.dataSaved = true;  
//         this.massage = 'Record Updated Successfully';  
//         this.loadAllEmployees();  
//         this.employeeIdUpdate = null;  
//         this.employeeForm.reset();  
//       });  
//     }  
//   }   
//    
//   }  
// }  
//   resetForm() {  
//     this.employeeForm.reset();  
//     this.massage = null;  
//     this.dataSaved = false;  
//   }  

