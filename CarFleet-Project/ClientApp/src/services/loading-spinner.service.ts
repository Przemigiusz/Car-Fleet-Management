import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoadingSpinnerService {
  private isSpinnerHidden: BehaviorSubject<boolean>;

  constructor() {
    this.isSpinnerHidden = new BehaviorSubject<boolean>(true);
  }

  changeSpinnerState(value: boolean) {
    this.isSpinnerHidden.next(value);
  }

  isSpinnerHidden$() {
    return this.isSpinnerHidden.asObservable();
  }
}
