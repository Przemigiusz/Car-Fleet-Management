import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vehicle } from '../models/Vehicle';
import { VehicleImage } from '../models/VehicleImage';
import { Observable } from 'rxjs';

@Injectable()
export class VehiclesService {
  private baseUrl = 'https://localhost:44435/api/vehicle';

  constructor(private http: HttpClient) { }

  addVehicle(vehicle: Vehicle): Observable<number> {
    return this.http.post<number>(`${this.baseUrl}/post-vehicle`, vehicle);
  }

  addVehicleImages(vehicleId: number, vehicleImages: File[]): Observable<string> {
    const formData = new FormData();
    formData.append("vehicleId", vehicleId.toString());
    for (const image of vehicleImages) {
      formData.append('vehicleImages', image);
    }
    return this.http.post<string>(`${this.baseUrl}/post-image`, formData, { responseType: 'text' as 'json' });
  }


  getVehiclesImages(): Observable<VehicleImage[]> {
    return this.http.get<VehicleImage[]>(`${this.baseUrl}/get-vehicles-images`);
  }

  getVehicles(): Observable<Vehicle[]> {
    return this.http.get<Vehicle[]>(`${this.baseUrl}/get-vehicles`);
  }
}
