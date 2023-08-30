export class VehicleImage {
  imageId: number = 0;
  imageType:string = "";
  imageName: string = "";
  vehicleImage: File;

  constructor(imageType: string, imageName: string, imageId?: number, vehicleImage?: File) { }
}
