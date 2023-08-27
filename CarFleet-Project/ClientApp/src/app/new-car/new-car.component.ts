import { Component, OnDestroy, OnInit } from '@angular/core';
import { AddCarService } from '../../services/add-car.service';
import { GetEquipmentElementsService } from '../../services/get-equipment-elements';
import { AddCarInterface } from '../../interfaces/add-car.interface';
import { Vehicle } from '../../models/Vehicle';
import { EquipmentElement } from '../../models/EquipmentElement';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ReplaySubject, takeUntil } from 'rxjs';

@Component({
  selector: 'new-car',
  templateUrl: './new-car.component.html',
  styleUrls: ['./new-car.component.css'],
})
export class NewCarComponent implements OnInit, OnDestroy {
  isExpanded = false;
  addCarForm: FormGroup = new FormGroup({});
  equipment: EquipmentElement[];
  operationalEquipment: any[] ;
  private onDestroy$: ReplaySubject<boolean> = new ReplaySubject<boolean>(1);

  updateValue(opElement: any) {
    if (opElement.isChecked === false) {
      opElement.isChecked = true;
    } else {
      opElement.isChecked = false;
    }
 };

  constructor(private addCarService: AddCarService, private getEquipmentElementsService: GetEquipmentElementsService,
    private formBuilder: FormBuilder) {}

  public ngOnDestroy(): void {
    this.onDestroy$.next(true);
    this.onDestroy$.complete();
  }

  ngOnInit() {
    this.initForm();
    this.getEquipmentElementsService.getEquipmentElements()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(r => {
        this.equipment = r;
        this.operationalEquipment = [];
        for (let el of this.equipment) {
          this.operationalEquipment.push({ elementId: el.elementId, elementName: el.elementName, isChecked: false });
        }
      }, err => { console.log("error", err); });
  };

  initForm() {
    this.addCarForm = this.formBuilder.group({
      brand: ['', Validators.required],
      model: ['', Validators.required],
      yearOfProduction: ['', Validators.required],
      mileage: ['', Validators.required],
      fuelType: ['', Validators.required],
      doorsAmount: ['', Validators.required],
      carBodyType: ['', Validators.required],
    })
  }

  submitForm() {
    if (this.addCarForm.valid) {
      const formData: AddCarInterface = this.addCarForm.value;
      const newVehicle: Vehicle = new Vehicle();
      newVehicle.brand = formData.brand;
      newVehicle.model = formData.model;
      newVehicle.yearOfProduction = formData.yearOfProduction;
      newVehicle.mileage = formData.mileage;
      newVehicle.fuelType = formData.fuelType;
      newVehicle.doorsAmount = formData.doorsAmount;
      newVehicle.carBodyType = formData.carBodyType;
      for (let opElement of this.operationalEquipment) {
        if (opElement.isChecked === true) {
          newVehicle.equipment.push(new EquipmentElement(opElement.elementId, opElement.elementName));
        }
      }
      this.addCarService.addCar(newVehicle)
        .pipe(takeUntil(this.onDestroy$))
        .subscribe(
        r => { debugger },
        err => { console.log("błąd"), console.log(err) });
    }
    else {
      console.log("Form is not valid!!!");
    }
    
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
