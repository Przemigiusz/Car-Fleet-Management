import { Model } from "./Model";
import { Vehicle } from "./Vehicle";

export class Brand
{
  brandId: number;
  brandName: string;
  vehicles: Vehicle[] = [];
  models: Model[] = [];

  constructor() {
    this.brandId = 0;
    this.brandName = "";
  }
}

