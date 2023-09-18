import { Vehicle } from "./Vehicle";

export class Model
{
  modelId: number;
  modelName: string;
  brandId: number;
  vehicles: Vehicle[] = [];

  constructor() {
    this.modelId = 0;
    this.modelName = "";
    this.brandId = 0;
}
}
