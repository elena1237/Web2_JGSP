import { Component, OnInit } from '@angular/core';
import { Line } from '../models/Line';
import { Schedule } from '../models/Schedule';
import { AdminScheduleService } from '../admin-schedule.service';
import { Observable } from 'rxjs';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-schedule',
  templateUrl: './admin-schedule.component.html',
  styleUrls: ['./admin-schedule.component.css']
})
export class AdminScheduleComponent implements OnInit {

  public schedules: Array<Schedule>;
  public  line: number;
  public departure: string;
  public Id: number;
  updateForm = this.fb.group({
    LineId: ['', Validators.required],
    Departure: ['', Validators.required],
    Id: [''],

  });


  constructor(private scheduleService: AdminScheduleService,private fb: FormBuilder) { 
    this.schedules = new Array<Schedule>();
  }

  public Update(selectedSchedule: any)
  {
      this.line=selectedSchedule.LineId;
      this.departure=selectedSchedule.Departure;
      this.Id=selectedSchedule.Id;

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
   this.scheduleService.updateScheduleById(this.updateForm.value).subscribe((data) => {
  });


}







  

}


