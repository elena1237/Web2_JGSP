export class TicketType {
    Id: number;
    Name: string;
    Price: number;

    constructor(private id: number, private name: string, private price:number) { 
        this.Id = id;
        this.Name = name;
        this.Price = price;
        
      }
}
