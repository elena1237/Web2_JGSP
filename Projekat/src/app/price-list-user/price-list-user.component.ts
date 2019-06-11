import { Component, OnInit } from '@angular/core';
import { PriceListService } from '../price-list.service';
import { PriceList } from '../models/PriceList';
import { Passenger } from '../passenger';
import { PassengerType } from '../passenger-type';
import { TicketType } from '../ticket-type';

@Component({
  selector: 'app-price-list-user',
  templateUrl: './price-list-user.component.html',
  styleUrls: ['./price-list-user.component.css']
})
export class PriceListUserComponent implements OnInit {

  public priceLists: PriceList[] = [];
  public passengers: PassengerType[] = [];
  public tickets: TicketType[] = [];


  constructor(private priceListService: PriceListService) { }

  async ngOnInit() {

    this.priceLists = await this.priceListService.getAllPriceList();
    this.tickets = await this.priceListService.getAllTicketTypes();
    this.passengers = await this.priceListService.getAllPassTypes();
  
  }


}
