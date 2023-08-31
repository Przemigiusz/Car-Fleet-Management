import { Model } from "./Model";
import { Vehicle } from "./Vehicle";

export class Brand
{
  brandId: number = 0;
  brandName: string = "";
  vehicles: Vehicle[] = [];
  models: Model[] = [];
}

