import { EquipmentElement } from "./EquipmentElement";
import { Model } from "./Model";
import { Brand } from "./Brand";
import { Fuel } from "./Fuel";
import { Carbody } from "./Carbody";
import { TransmissionType } from "./TransmissionType";
import { VehicleImage } from "./VehicleImage";

export class Vehicle {
  vehicleId: number = 0;

  brandId: number = 0;

  modelId: number = 0;

  fuels: Fuel[] = []

  carbodyId: number = 0;

  transmissionTypeId: number = 0;

  vehicleImages: VehicleImage[] = [];
  equipment: EquipmentElement[] = [];

  yearOfProduction: string = '';
  mileage: string = '';
  doorsAmount: string = '';
}
