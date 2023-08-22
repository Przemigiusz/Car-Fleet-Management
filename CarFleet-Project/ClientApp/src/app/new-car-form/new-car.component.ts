import { Component, OnInit } from '@angular/core';
import { AddCarService } from '../../services/add-car.service';
import { AddCarInterface } from '../../interfaces/add-car.interface';
import { Vehicle } from '../../models/Vehicle';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'new-car',
  templateUrl: './new-car.component.html',
  styleUrls: ['./new-car.component.css'],
})
export class NewCarComponent implements OnInit {
  isExpanded = false;
  addCarForm: FormGroup = new FormGroup({});

  constructor(private addCarService: AddCarService,
              private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.initForm();
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
      this.addCarService.addCar(newVehicle).subscribe(
        r => { console.log("sukces") }, //r => { debugger }
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
