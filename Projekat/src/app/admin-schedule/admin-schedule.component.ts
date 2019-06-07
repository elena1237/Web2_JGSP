import { Component, OnInit } from '@angular/core';
import { Line } from '../models/Line';
import { Schedule } from '../models/Schedule';
import { AdminScheduleService } from '../admin-schedule.service';
import { Observable } from 'rxjs';
import { FormBuilder, Validators } from '@angular/forms';
import { ScheduleType } from '../models/ScheduleType';

@Component({
  selector: 'app-admin-schedule',
  templateUrl: './admin-schedule.component.html',
  styleUrls: ['./admin-schedule.component.css']
})
export class AdminScheduleComponent implements OnInit {

  public schedules: Array<Schedule>;
  public  line: number;
  public Departure: string;
  public id: number;
  private schedule:Schedule;
  private LineId:number;
  private DayInWeek:string;
  private ScheduleTypeId:number;
  private ScheduleType:ScheduleType;
  private Line:Line;

  updateForm = this.fb.group({
    LineId: [this.LineId, Validators.required],
    Departure: [this.Departure, Validators.required],
    Id: [''],

  });


  constructor(private scheduleService: AdminScheduleService,private fb: FormBuilder) { 
    this.schedules = new Array<Schedule>();
  }

  public Update(selectedSchedule: any)
  {
    this.LineId =selectedSchedule.LineId;
    this.Departure=selectedSchedule.Departure;
    this.id=selectedSchedule.Id; 
    this.DayInWeek=selectedSchedule.DayInWeek;
    this.ScheduleTypeId=selectedSchedule.ScheduleTypeId;
    this.LineId=selectedSchedule.LineId;
    this.ScheduleType=selectedSchedule.ScheduleType;
    this.Line=selectedSchedule.Line;
  }
  
  async ngOnInit() {

    this.schedules = await this.scheduleService.getAllSchedules();

  }

 

public Delete(selectedSchedule: any)
{

  this.scheduleService.deleteScheduleById(selectedSchedule.Id);
  window.location.reload();
  
}

public UpdateSubmit()
{
  this.schedule = new Schedule(this.id, this.Departure,this.LineId,this.DayInWeek,this.ScheduleTypeId,this.ScheduleType,this.Line);
   this.scheduleService.updateScheduleById(this.schedule).subscribe((data) => {
  });
  window.location.reload();


}







  

}


