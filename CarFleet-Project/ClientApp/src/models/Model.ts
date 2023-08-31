import { Brand } from "./Brand";
import { Vehicle } from "./Vehicle";

export class Model
{
  modelId: number = 0;
  modelName: string = "";
  brandId: number = 0;
  vehicles: Vehicle[] = [];
}
