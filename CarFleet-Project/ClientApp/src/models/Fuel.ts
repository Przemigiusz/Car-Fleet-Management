import { Vehicle } from "./Vehicle";

export class Fuel {
  fuelId: number;
  fuelName: string;
  vehicles: Vehicle[] = [];

  constructor() {
    this.fuelId = 0;
    this.fuelName = "";
  }
}
