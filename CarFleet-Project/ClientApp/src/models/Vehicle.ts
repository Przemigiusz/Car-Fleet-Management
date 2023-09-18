import { EquipmentElement } from "./EquipmentElement";
import { Fuel } from "./Fuel";
import { VehicleImage } from "./VehicleImage";

export class Vehicle {
  vehicleId: number;

  brandId: number;

  modelId: number;

  fuels: Fuel[] = []

  carbodyId: number;

  transmissionTypeId: number;

  yearOfProductionId: number;

  vehicleImages: VehicleImage[] = [];
  equipment: EquipmentElement[] = [];

  mileage: string;

  constructor() {
    this.vehicleId = 0;
    this.brandId = 0;
    this.modelId = 0;
    this.carbodyId = 0;
    this.transmissionTypeId = 0;
    this.yearOfProductionId = 0;
    this.mileage = "";
  }
}
