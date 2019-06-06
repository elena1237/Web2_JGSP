import { Component, OnInit } from '@angular/core';
import { Line } from '../models/Line';
import { Schedule } from '../models/Schedule';
import { AdminScheduleService } from '../admin-schedule.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-admin-schedule',
  templateUrl: './admin-schedule.component.html',
  styleUrls: ['./admin-schedule.component.css']
})
export class AdminScheduleComponent implements OnInit {

  public schedules: Array<Schedule>;



  constructor(private scheduleService: AdminScheduleService) { 
    this.schedules = new Array<Schedule>();
    this.headElements = new Array<string>();
  }


  headElements = ['ID', 'First', 'Last', 'Handle'];

  
  async ngOnInit() {

    this.schedules = await this.scheduleService.getAllSchedules();

  }










  

}


