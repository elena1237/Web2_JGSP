import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { PriceListComponent } from './price-list/price-list.component';
import { BuyTicketComponent } from './buy-ticket/buy-ticket.component';
import {AuthGuard} from './login/auth/auth.guard';
import { AdminScheduleComponent } from './admin-schedule/admin-schedule.component';

const routes: Routes = [

  { 
    path: 'login', 
    component: LoginComponent, 
   // canActivate: [AuthGuard]

  },
  { 
    path: 'admin-schedule', 
    component: AdminScheduleComponent, 
    canActivate: [AuthGuard]

  },
  { 
    path: 'home', 
    component: HomeComponent, 
  },
  { 
    path: 'priceList', 
    component: PriceListComponent, 
  },
  { 
    path: 'schedule', 
    component: ScheduleComponent, 
  },
  { 
    path: 'buyTicket', 
    component: BuyTicketComponent, 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
