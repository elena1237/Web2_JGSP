import { PassengerType } from '../passenger-type';
import { ApplicationUser } from '../application-user';

     export class Passenger extends ApplicationUser {
      Approved:boolean;
      PassengerType: PassengerType;
      ImageUrl: string;
      Password: string;
}
            