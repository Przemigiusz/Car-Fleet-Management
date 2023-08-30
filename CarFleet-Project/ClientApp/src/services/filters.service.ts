import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PriceType } from '../models/PriceType';
import { FuelType } from '../models/FuelType';
import { SortingType } from '../models/SortingType';
import { CarbodyType } from '../models/CarbodyType';
import { TransmissionType } from '../models/TransmissionType';
import { Observable } from 'rxjs';

@Injectable()
export class FiltersService {
  private baseUrl = 'https://localhost:44435/api/filters';

  constructor(private http: HttpClient) { }

  getPricesPerDay(): Observable<PriceType[]> {
    return this.http.get<PriceType[]>(`${this.baseUrl}/prices-per-day`);
  }
  getFuelTypes(): Observable<FuelType[]> {
    return this.http.get<FuelType[]>(`${this.baseUrl}/fuel-types`);
  }
  getSortingTypes(): Observable<SortingType[]> {
    return this.http.get<SortingType[]>(`${this.baseUrl}/sorting-types`);
  }
  getCarbodyTypes(): Observable<CarbodyType[]> {
    return this.http.get<CarbodyType[]>(`${this.baseUrl}/carbody-types`);
  }
  getTransmissionTypes(): Observable<TransmissionType[]> {
    return this.http.get<TransmissionType[]>(`${this.baseUrl}/transmission-types`);
  }
}
