import { Vehicle } from "./Vehicle";

export class EquipmentElement {
  elementId: number;
  elementName: string = "";
  vehicles: Vehicle[] = [];

  public fromJSON(json: any) {
    for (let propName in json) {
      if (this.hasOwnProperty(propName)) {
        const propKey = propName as keyof EquipmentElement;
        // @ts-ignore
        this[propKey] = json[propName];
      }
    }
    return this;
  }
}
