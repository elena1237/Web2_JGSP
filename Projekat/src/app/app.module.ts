import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule , FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
  ],
  bootstrap: [AppComponent],
  providers: [LoginService,HttpClientModule, BuyticketService, AdminScheduleService]
})
export class AppModule { }
