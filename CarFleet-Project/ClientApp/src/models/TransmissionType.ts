import { Vehicle } from './Vehicle'

export class TransmissionType {
  typeId: number;
  typeName: string;
  vehicles: Vehicle[] = [];

  constructor() {
    this.typeId = 0;
    this.typeName = "";
  }
}
