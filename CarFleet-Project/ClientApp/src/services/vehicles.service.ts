import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Vehicle } from '../models/Vehicle';
import { VehicleImage } from '../models/VehicleImage';
import { Observable } from 'rxjs';

@Injectable()
export class VehiclesService {
  private baseUrl = 'https://localhost:44435/api/vehicle';

  constructor(private http: HttpClient) { }

  addVehicle(vehicle: Vehicle): Observable<Vehicle> {
    return this.http.post<Vehicle>(`${this.baseUrl}/post-vehicle`, vehicle);
  }

  addVehicleImages(vehicleImages: VehicleImage[]): Observable<VehicleImage[]> {
    return this.http.post<VehicleImage[]>(`${this.baseUrl}/post-image`, vehicleImages);
  }

  getVehiclesImages(): Observable<VehicleImage[]> {
    return this.http.get<VehicleImage[]>(`${this.baseUrl}/get-vehicles-images`);
  }

  getVehicles(): Observable<Vehicle[]> {
    return this.http.get<Vehicle[]>(`${this.baseUrl}/get-vehicles`);
  }
}
