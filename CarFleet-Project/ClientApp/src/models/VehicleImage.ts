import { SafeUrl } from '@angular/platform-browser';

export class VehicleImage {
  imageId: number;
  imageType: string;
  imageName: string;
  vehicleId: number;
  imageBase64: string;
  imageUrl: SafeUrl;

  constructor() {
    this.imageId = 0;
    this.imageType = "";
    this.imageName = "";
    this.vehicleId = 0;
    this.imageBase64 = "";
    this.imageUrl = "";
  }
}
