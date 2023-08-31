import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PriceRange } from '../models/PriceRange';
import { Fuel } from '../models/Fuel';
import { SortingType } from '../models/SortingType';
import { Carbody } from '../models/Carbody';
import { TransmissionType } from '../models/TransmissionType';
import { Observable } from 'rxjs';
import { Model } from '../models/Model';
import { Brand } from '../models/Brand';

@Injectable()
export class FiltersService {
  private baseUrl = 'https://localhost:44435/api/filters';

  constructor(private http: HttpClient) { }

  getPriceRanges(): Observable<PriceRange[]> {
    return this.http.get<PriceRange[]>(`${this.baseUrl}/get-price-ranges`);
  }
  getFuels(): Observable<Fuel[]> {
    return this.http.get<Fuel[]>(`${this.baseUrl}/get-fuels`);
  }
  getSortingTypes(): Observable<SortingType[]> {
    return this.http.get<SortingType[]>(`${this.baseUrl}/get-sorting-types`);
  }
  getCarbodies(): Observable<Carbody[]> {
    return this.http.get<Carbody[]>(`${this.baseUrl}/get-carbodies`);
  }
  getTransmissionTypes(): Observable<TransmissionType[]> {
    return this.http.get<TransmissionType[]>(`${this.baseUrl}/get-transmission-types`);
  }
  getBrands(): Observable<Brand[]> {
    return this.http.get<Brand[]>(`${this.baseUrl}/get-brands`);
  }
  getModels(): Observable<Model[]> {
    return this.http.get<Model[]>(`${this.baseUrl}/get-models`);
  }
}
