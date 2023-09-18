import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Brand } from '../models/Brand';
import { Model } from '../models/Model';
import { YearOfProduction } from '../models/YearOfProduction';
import { TransmissionType } from '../models/TransmissionType';
import { Carbody } from '../models/Carbody';

export function createIsAnOptionValidator(dataListArray: Brand[] | Model[] | YearOfProduction[] | TransmissionType[] | Carbody[]): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    if (dataListArray.some(el => { el instanceof Brand })) {
      if (dataListArray.some(el => {el instanceof Brand && el.brandName === control.value; })) {
        return null;
      }
    }
    else if (dataListArray.some(el => { el instanceof Model })) {
      if (dataListArray.some(el => { el instanceof Model && el.modelName === control.value; })) {
        return null;
      }
    }
    else if (dataListArray.some(el => { el instanceof YearOfProduction })) {
      if (dataListArray.some(el => { el instanceof YearOfProduction && el.year === control.value; })) {
        return null;
      }
    }
    else if (dataListArray.some(el => { el instanceof TransmissionType })) {
      if (dataListArray.some(el => { el instanceof TransmissionType && el.typeName === control.value; })) {
        return null;
      }
    }
    else if (dataListArray.some(el => { el instanceof Carbody })) {
      if (dataListArray.some(el => { el instanceof Carbody && el.carbodyName === control.value; })) {
        return null;
      }
    }
    return { isAnOption: true };
  }
}

