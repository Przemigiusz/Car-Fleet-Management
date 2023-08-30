import { Component, OnDestroy, OnInit } from '@angular/core';
import { VehiclesService } from '../../services/vehicles.service';
import { EquipmentService } from '../../services/equipment.service';
import { AddCarInterface } from '../../interfaces/add-car.interface';
import { Vehicle } from '../../models/Vehicle';
import { VehicleImage } from '../../models/vehicleImage';
import { EquipmentElement } from '../../models/EquipmentElement';
import { FormBuilder, FormGroup, Validators, FormControl, ValidationErrors } from '@angular/forms';
import { ReplaySubject, takeUntil } from 'rxjs';

@Component({
  selector: 'new-car',
  templateUrl: './new-car.component.html',
  styleUrls: ['./new-car.component.css'],
})
export class NewCarComponent implements OnInit, OnDestroy {
  private isExpanded = false;
  public addCarForm: FormGroup = new FormGroup({});
  private equipment: EquipmentElement[];
  public operationalEquipment: any[] ;
  private onDestroy$: ReplaySubject<boolean> = new ReplaySubject<boolean>(1);
  private images: VehicleImage[] = [];

  updateValue(opElement: any) {
    if (opElement.isChecked === false) {
      opElement.isChecked = true;
    } else {
      opElement.isChecked = false;
    }
 };

  constructor(private addCarService: VehiclesService, private getEquipmentElementsService: EquipmentService,
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
      vehicleImage: [null, Validators.required]
    })
  }



  fileChanged(event: Event) {
    const imageInputElement = event.target as HTMLInputElement;
    if (imageInputElement.files && imageInputElement.files.length > 0) {
      const vehicleImage = new VehicleImage(imageInputElement.name, imageInputElement.type);
      this.images.push(vehicleImage);
    }
  }

  submitForm() {
    if (this.addCarForm.valid) {
      console.log("Form is valid!!!");
      console.log(this.addCarForm.errors);
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
      this.addCarService.addVehicle(newVehicle)
        .pipe(takeUntil(this.onDestroy$))
        .subscribe(
        r => { debugger },
        err => { console.log("błąd"), console.log(err) });
    }
    else {
      console.log("Form is not valid!!!");
      this.getFormValidationErrors();
    }  
  }

  getFormValidationErrors() {
    Object.keys(this.addCarForm.controls).forEach((key,value) => {
      const controlErrors: ValidationErrors = this.addCarForm.get(key)!.errors!;
      Object.keys(controlErrors || {}).forEach(keyError => {
        console.log(`Key control: ${key}, keyError: ${keyError}, errValue: ${controlErrors[keyError]}`);
      });
    });
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
