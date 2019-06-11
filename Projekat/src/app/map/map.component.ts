
import { Component, OnInit, Input, NgZone } from '@angular/core';
import { GeoLocation } from '../models/map/geolocations';
import { MarkerInfo } from '../models/map/marker-info-model';
import { Polyline } from '../models/map/polyline';
import { StationsService } from '../stations.service';
import { Coordinate } from '../models/Coordinate';
import { Station } from '../models/Station';
import { Validators, FormBuilder } from '@angular/forms';
import { Line } from '../models/Line';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
  styles: ['agm-map {height: 500px; width: 700px;}'] //postavljamo sirinu i visinu mape
})
export class MapComponent implements OnInit {

  markerInfo: MarkerInfo;
  public polyline: Polyline;
  public zoom: number;
  public coordinate: Coordinate=new Coordinate();
  public station:Station=new Station();
  public lines:Line[]=[];
  public stations: Array<Station> = [];
  public geoLocation: GeoLocation;
  public markerInfos: MarkerInfo;
  addStationForm = this.fb.group({
    name: ['', Validators.required],
    address: ['', Validators.required],
  });

   ngOnInit() {
    
  
      this.polyline = new Polyline([], 'blue', { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}});


      this.stationService.getAllStations().subscribe((data)=>{
        Object.assign(this.stations, data);
      });
      // for(let s of this.stations)
      // {

      //     this.geoLocation = new GeoLocation(s.Coordinate.X,s.Coordinate.Y);
      //     this.polyline.addLocation(this.geoLocation);
          
      // }


  }


  constructor(private ngZone: NgZone,private stationService:StationsService,private fb: FormBuilder){
  }


  public SubmitStation()
  {
    this.station.Name=this.addStationForm.controls['name'].value;
    this.station.Address=this.addStationForm.controls['address'].value;
    this.station.Lines=this.lines;
    
    this.stationService.createStation(this.station).subscribe(  
      () => {  
        
      }  
    );
  }


  placeMarker($event){
    this.polyline.addLocation(new GeoLocation($event.coords.lat, $event.coords.lng))

    this.coordinate.X=$event.coords.lat;
    this.coordinate.Y=$event.coords.lng;
    this.station.Coordinate=this.coordinate;

    console.log(this.polyline)
  }

}