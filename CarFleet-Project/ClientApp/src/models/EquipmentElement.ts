export class EquipmentElement {
  elementId: number;
  elementName: string;

  constructor() {
    this.elementId = 0;
    this.elementName = "";
  }

  public fromJSON(json: EquipmentElement) {
    for (const propName in json) {
      if (Object.prototype.hasOwnProperty.call(this, propName)) {
        const propKey = propName as keyof EquipmentElement;
        // eslint-disable-next-line @typescript-eslint/ban-ts-comment
        // @ts-ignore
        this[propKey] = json[propName];
      }
    }
    return this;
  }
}
