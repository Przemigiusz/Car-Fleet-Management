import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map} from 'rxjs';
import { EquipmentElement } from '../models/EquipmentElement';

@Injectable()
export class EquipmentService {
  private baseUrl = 'https://localhost:44435/api/equipment';

  constructor(private http: HttpClient) { }

  getEquipmentElements(): Observable<EquipmentElement[]> {
    return this.http.get<EquipmentElement[]>(`${this.baseUrl}/get-equipment-elements`).pipe(
      map(r => {
        const result = new Array<EquipmentElement>();
        r.forEach(ee => result.push(new EquipmentElement().fromJSON(ee)));
        return result;
      })
    );
  }
}
