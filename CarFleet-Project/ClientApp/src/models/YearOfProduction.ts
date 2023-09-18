import { Vehicle } from './Vehicle'

export class YearOfProduction {
  yearId: number;
  year: string;
  vehicles: Vehicle[] = [];

  constructor() {
    this.yearId = 0;
    this.year = "";
  }
}
