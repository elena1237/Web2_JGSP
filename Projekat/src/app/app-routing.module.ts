import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { PriceListComponent } from './price-list/price-list.component';
import { BuyTicketComponent } from './buy-ticket/buy-ticket.component';
import {AuthGuard} from './login/auth/auth.guard';
import { AdminScheduleComponent } from './admin-schedule/admin-schedule.component';
import { PriceListUserComponent } from './price-list-user/price-list-user.component';
import { AdminStationsComponent } from './admin-stations/admin-stations.component';
import { RegistrationComponent } from './registration/registration.component';
import { AdminLinesComponent } from './admin-lines/admin-lines.component';
import { GridLinesAdminComponent } from './grid-lines-admin/grid-lines-admin.component';


const routes: Routes = [

  { 
    path: 'login', 
    component: LoginComponent, 
   // canActivate: [AuthGuard]

  },
  { 
    path: 'registration', 
    component: RegistrationComponent, 
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
    canActivate: [AuthGuard]

  },
  { 
    path: 'schedule', 
    component: ScheduleComponent, 
  },
  { 
    path: 'buyTicket', 
    component: BuyTicketComponent, 
  },
  { 
    path: 'priceListUser', 
    component: PriceListUserComponent, 
  },
  { 
    path: 'stations', 
    component: AdminStationsComponent, 
    canActivate: [AuthGuard]


  },

  { 
    path: 'lines', 
    component: AdminLinesComponent, 
    canActivate: [AuthGuard]
  },
  { 
    path: 'userlines', 
    component: GridLinesAdminComponent, 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
