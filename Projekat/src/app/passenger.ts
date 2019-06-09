import { PassengerType } from './passenger-type';

export class Passenger {
    Aproved: boolean;
    PassengerType: PassengerType;
    ImageUrl: string;
    Id: number;

    constructor(private id: number, private approved: boolean, private passengerType:PassengerType, private imageUrl: string) { 
        this.Id = id;
        this.Aproved = approved;
        this.PassengerType = passengerType;
        this.ImageUrl = imageUrl;
        
      }
}
