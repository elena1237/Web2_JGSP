import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule , FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AgmCoreModule } from '@agm/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { PriceListComponent } from './price-list/price-list.component';
import { BuyTicketComponent } from './buy-ticket/buy-ticket.component';
import {LoginService} from './login.service';
import {BuyticketService} from './buyticket.service';
import { TicketComponent } from './ticket/ticket.component';
import { AdminScheduleComponent } from './admin-schedule/admin-schedule.component';
import { AdminScheduleService } from './admin-schedule.service';
import { NgbdDatepickerComponent } from './ngb-datepicker/ngb-datepicker.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { PriceListUserComponent } from './price-list-user/price-list-user.component';
import { AdminStationsComponent } from './admin-stations/admin-stations.component';
import { MapComponent } from './map/map.component';
import { RegistrationComponent } from './registration/registration.component';
import { AdminLinesComponent } from './admin-lines/admin-lines.component';
import { GridLinesAdminComponent } from './grid-lines-admin/grid-lines-admin.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    HeaderComponent,
    FooterComponent,
    ScheduleComponent,
    PriceListComponent,
    BuyTicketComponent,
    TicketComponent,
    AdminScheduleComponent,
    NgbdDatepickerComponent,
    PriceListUserComponent,
    AdminStationsComponent,
    MapComponent,
    RegistrationComponent,
    AdminLinesComponent,
    GridLinesAdminComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    NgbModule.forRoot(),
    AgmCoreModule.forRoot({apiKey: 'AIzaSyDnihJyw_34z5S1KZXp90pfTGAqhFszNJk'}),
  ],
  bootstrap: [AppComponent],
  providers: [LoginService,HttpClientModule, BuyticketService, AdminScheduleService]
})
export class AppModule { }






  
 