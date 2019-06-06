import { Line } from './Line';
import { ScheduleType } from './ScheduleType';

export class Schedule{
    Id: number;
    Departure: string;
    DayInWeek: string;
    ScheduleTypeId:number;
    ScheduleType : ScheduleType
    LineId:number;
    Line:Line;
    
}









