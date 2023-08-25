export class EquipmentElement {
  elementId: number;
  elementName: string = "";

  constructor(elementId?: number, elementName?: string) {
    this.elementId = elementId!;
    this.elementName = elementName!;
  }

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
