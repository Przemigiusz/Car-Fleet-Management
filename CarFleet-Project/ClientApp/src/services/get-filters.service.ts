import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vehicle } from '../models/Vehicle';
import { PricesPerDay } from '../models/PricesPerDay';
import { FuelTypes } from '../models/FuelTypes';
import { SortingTypes } from '../models/SortingTypes';
import { CarbodyTypes } from '../models/CarbodyTypes';
import { Observable } from 'rxjs';

@Injectable()
export class GetFiltersService {
  private baseUrl = 'https://localhost:44435/api/filters';

  constructor(private http: HttpClient) { }

  getPricesPerDay(): Observable<PricesPerDay> {
    return this.http.get<PricesPerDay>(`${this.baseUrl}/prices-per-day`);
  }
  getFuelTypes(): Observable<FuelTypes> {
    return this.http.get<FuelTypes>(`${this.baseUrl}/fuel-types`);
  }
  getSortingTypes(): Observable<SortingTypes> {
    return this.http.get<SortingTypes>(`${this.baseUrl}/sorting-types`);
  }
  getCarbodyTypes(): Observable<CarbodyTypes> {
    return this.http.get<CarbodyTypes>(`${this.baseUrl}/-carbody-types`);
  }
}
