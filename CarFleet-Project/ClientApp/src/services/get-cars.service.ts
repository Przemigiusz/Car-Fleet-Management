import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vehicle } from '../models/Vehicle';
import { Observable } from 'rxjs';

@Injectable()
export class GetCarsService {
  private baseUrl = 'https://localhost:44435/api/get-vehicles';

  constructor(private http: HttpClient) { }

  getCars(): Observable<Vehicle[]> {
    return this.http.get<Vehicle[]>(`${this.baseUrl}`);
  }
}
