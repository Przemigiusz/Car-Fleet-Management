import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vehicle } from '../models/Vehicle';
import { Observable, map, tap } from 'rxjs';
import { EquipmentElement } from '../models/EquipmentElement';

@Injectable()
export class GetEquipmentElementsService {
  private baseUrl = 'https://localhost:44435/api/equipment/equipment-elements';

  constructor(private http: HttpClient) { }

  getEquipmentElements(): Observable<EquipmentElement[]> {
    return this.http.get<EquipmentElement[]>(`${this.baseUrl}`).pipe(
      map(r => {
        var result = new Array<EquipmentElement>();
        r.forEach(v => result.push(new EquipmentElement().fromJSON(v)));
        return result;
      })
    );
  }
}
