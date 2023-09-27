export class Vehicle {
  vehicleId: number;

  brandId: number;

  modelId: number;

  carbodyId: number;

  transmissionTypeId: number;

  yearOfProductionId: number;

  equipmentIds: number[] = []
  fuelsIds: number[] = [];

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
