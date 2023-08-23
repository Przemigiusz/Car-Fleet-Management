import { Equipment } from "./Equipment";

export class Vehicle {
  vehicleId: number = 0;
  brand: string = '';
  model: string = '';
  yearOfProduction: string = '';
  mileage: string = '';
  fuelType: string = '';
  doorsAmount: string = '';
  carBodyType: string = '';
  equipment: Equipment[] = [];
}
