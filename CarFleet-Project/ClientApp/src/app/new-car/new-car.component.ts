import { Component, OnDestroy, OnInit } from '@angular/core';
import { VehiclesService } from '../../services/vehicles.service';
import { EquipmentService } from '../../services/equipment.service';
import { FiltersService } from '../../services/filters.service';
import { AddCarInterface } from '../../interfaces/add-car.interface';
import { Vehicle } from '../../models/Vehicle';
import { VehicleImage } from '../../models/VehicleImage';
import { EquipmentElement } from '../../models/EquipmentElement';
import { FormBuilder, FormGroup, Validators, FormControl, ValidationErrors } from '@angular/forms';
import { ReplaySubject, takeUntil } from 'rxjs';
import { Brand } from '../../models/Brand';
import { Model } from '../../models/Model';
import { Fuel } from '../../models/Fuel';
import { Carbody } from '../../models/Carbody';
import { TransmissionType } from '../../models/TransmissionType';

@Component({
  selector: 'new-car',
  templateUrl: './new-car.component.html',
  styleUrls: ['./new-car.component.css'],
})
export class NewCarComponent implements OnInit, OnDestroy {
  private isExpanded = false;
  public addCarForm: FormGroup = new FormGroup({});

  private equipment: EquipmentElement[]; //Whole equipment elements
  public operationalEquipment: any[]; //Elements which are available in the car

  public brands: Brand[];
  public models: Model[];
  public fuels: Fuel[];
  public carbodies: Carbody[];
  public transmissionTypes: TransmissionType[];

  private onDestroy$: ReplaySubject<boolean> = new ReplaySubject<boolean>(1);

  private images: VehicleImage[] = []; //Photos of the car

  updateValue(opElement: any) {
    if (opElement.isChecked === false) {
      opElement.isChecked = true;
    } else {
      opElement.isChecked = false;
    }
 };

  constructor(private addCarService: VehiclesService, private getEquipmentElementsService: EquipmentService,
    private formBuilder: FormBuilder, private getFiltersService: FiltersService) {}

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
          this.operationalEquipment.push({ equipmentElement: el, isChecked: false });
        }
      }, err => { console.log("error", err); });

    this.getFiltersService.getCarbodies()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(r => {
        this.carbodies = r;
      }, err => { console.log("error", err); });

    this.getFiltersService.getFuels()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(r => {
        this.fuels = r;
      }, err => { console.log("error", err); });

    this.getFiltersService.getTransmissionTypes()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(r => {
        this.transmissionTypes = r;
      }, err => { console.log("error", err); });

    this.getFiltersService.getModels()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(r => {
        this.models = r;
      }, err => { console.log("error", err); });

    this.getFiltersService.getBrands()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(r => {
        this.brands = r;
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
      carbodyType: ['', Validators.required],
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
      newVehicle.brandId = formData.brand;
      newVehicle.modelId = formData.model;
      newVehicle.yearOfProduction = formData.yearOfProduction;
      newVehicle.mileage = formData.mileage;
      newVehicle.fuel = formData.fuelType;
      newVehicle.doorsAmount = formData.doorsAmount;
      newVehicle.carbodyId = formData.carBodyType;

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
