import { Component, OnInit, NgZone } from '@angular/core';
import { Line } from '../models/Line';
import { Station } from '../models/Station';
import { Router } from '@angular/router';
import { StationsService } from '../stations.service';
import { LineserviceService } from '../lineservice.service';

@Component({
  selector: 'app-grid-lines-admin',
  templateUrl: './grid-lines-admin.component.html',
  styleUrls: ['./grid-lines-admin.component.css'],
  styles: ['agm-map {height: 500px; width: 700px;}'] //postavljamo sirinu i visinu mape
})
export class GridLinesAdminComponent implements OnInit {

  public zoom: number;
  stations: Array<Station> = [];
  imageUrl: string = "./assets/busicon.png";
  lines: Array<Line> = [];
  stationsArray: Station[] = [];
  selectedLine: Line;
  
  constructor(private ngZone: NgZone, private stationService: StationsService, private router: Router, private linesService: LineserviceService) { }

  ngOnInit() {
    this.stationService.getAllStations().subscribe((data)=>{
      Object.assign(this.stations, data);

      this.linesService.getAllLines().subscribe((data)=>{
        Object.assign(this.lines, data);
      });
    
    });
    console.log(this.stations);

  }

  showLine(){
    this.stationsArray = this.selectedLine.Stations;
    console.log(this.stationsArray);
  }

}






    
