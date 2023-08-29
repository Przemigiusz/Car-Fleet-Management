import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Vehicle } from '../models/Vehicle';
import { Observable } from 'rxjs';
import { AddCarResponseInterface } from '../interfaces/add-car-response.interface';

@Injectable()
export class AddCarService {
  private baseUrl = 'https://localhost:44435/api/vehicle';

  constructor(private http: HttpClient) { }

  addCar(vehicle: Vehicle, file: File): Observable<AddCarResponseInterface> {
    const formData = new FormData();

    formData.append("vehicle", JSON.stringify(vehicle));
    formData.append("file", file);

    //const options = {
    //  headers: new HttpHeaders({
    //    'Content-Type': 'multipart/form-data',
    //  })
    //};

    return this.http.post<AddCarResponseInterface>(`${this.baseUrl}`, formData);
  }
}
