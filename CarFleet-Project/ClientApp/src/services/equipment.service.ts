import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map, tap } from 'rxjs';
import { EquipmentElement } from '../models/EquipmentElement';

@Injectable()
export class EquipmentService {
  private baseUrl = 'https://localhost:44435/api/equipment';

  constructor(private http: HttpClient) { }

  getEquipmentElements(): Observable<EquipmentElement[]> {
    return this.http.get<EquipmentElement[]>(`${this.baseUrl}/equipment-elements`).pipe(
      map(r => {
        var result = new Array<EquipmentElement>();
        r.forEach(v => result.push(new EquipmentElement().fromJSON(v)));
        return result;
      })
    );
  }
}
