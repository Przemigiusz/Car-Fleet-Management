import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vehicle } from '../models/Vehicle';

@Injectable()
export class AddCarService {
  private baseUrl = 'https://localhost:44460/api/Vehicle';

  constructor(private http: HttpClient) { }

  addCar(vehicle: Vehicle) {
    return this.http.post(`${this.baseUrl}`, vehicle);
  }
}
