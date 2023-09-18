import { AbstractControl, FormGroup, ValidationErrors, ValidatorFn } from '@angular/forms';

export function createAtLeastOneValidator(): ValidatorFn {
  return (form: AbstractControl): ValidationErrors | null => {

    const tempForm = form as FormGroup;
    const controls = tempForm.controls;
    
    for (const control in controls) {
      if (form.get(control)!.value === true) {
        return null;
      }
    }
    return { atLeastOne: true };
  }
}

