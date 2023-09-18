import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Brand } from '../models/Brand';

export function createIsBrandChosenValidator(brands: Brand[]): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    if (brands.includes(control.value)) {
      return null;
    }
    return { isBrandChosen: true };
  }
}

