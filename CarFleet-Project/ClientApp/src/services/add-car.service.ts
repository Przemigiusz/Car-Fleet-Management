import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vehicle } from '../models/Vehicle';
import { Observable } from 'rxjs';

@Injectable()
export class AddCarService {
  private baseUrl = 'https://localhost:44435/api/vehicle';

  constructor(private http: HttpClient) { }

  addCar(vehicle: Vehicle): Observable<Vehicle> {
    return this.http.post<Vehicle>(`${this.baseUrl}`, vehicle);
  }
}
