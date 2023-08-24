import { Component, OnInit } from '@angular/core';
import { AddCarService } from '../../services/add-car.service';
import { GetEquipmentElementsService } from '../../services/get-equipment-elements';
import { AddCarInterface } from '../../interfaces/add-car.interface';
import { Vehicle } from '../../models/Vehicle';
import { EquipmentElement } from '../../models/EquipmentElement';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'new-car',
  templateUrl: './new-car.component.html',
  styleUrls: ['./new-car.component.css'],
})
export class NewCarComponent implements OnInit {
  isExpanded = false;
  addCarForm: FormGroup = new FormGroup({});
  equipment: EquipmentElement[] = [];
  isChecked: FormControl;

  updateValue(equipmentItem: any) {
    if (equipmentItem.isChecked === false) {
      equipmentItem.isChecked = true;
    } else {
      equipmentItem.isChecked = false;
    }
 };

  constructor(private addCarService: AddCarService, private getEquipmentElementsService: GetEquipmentElementsService,
    private formBuilder: FormBuilder) {
    this.isChecked = new FormControl();
  }

  ngOnInit() {
    this.initForm();
    this.getEquipmentElementsService.getEquipmentElements().subscribe(r => { this.equipment = r; }, err => { console.log("error", err); });
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
      for (let el of this.equipment) {
        if (el.isChecked === true) {
          newVehicle.equipment.push(el.name);
        }
      }
      this.addCarService.addCar(newVehicle).subscribe(
        r => { debugger }, //r => { debugger } console.log("sukces")
        err => { console.log("błąd") });
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
