/* eslint-disable @angular-eslint/component-selector */
/* eslint-disable no-debugger */
import { Component, OnDestroy, OnInit } from '@angular/core';
import { VehiclesService } from '../../services/vehicles.service';
import { EquipmentService } from '../../services/equipment.service';
import { FiltersService } from '../../services/filters.service';
import { LoadingSpinnerService } from '../../services/loading-spinner.service';
import { AddCarInterface } from '../../interfaces/add-car.interface';
import { Vehicle } from '../../models/Vehicle';
import { EquipmentElement } from '../../models/EquipmentElement';
import { FormBuilder, FormGroup, Validators, ValidationErrors, FormControl } from '@angular/forms';
import { ReplaySubject, takeUntil, map, forkJoin } from 'rxjs';
import { Brand } from '../../models/Brand';
import { Model } from '../../models/Model';
import { Fuel } from '../../models/Fuel';
import { Carbody } from '../../models/Carbody';
import { TransmissionType } from '../../models/TransmissionType';
import { OperationalEquipment } from '../../interfaces/operational-equipment.interface';
import { YearOfProduction } from '../../models/YearOfProduction';
import { createAtLeastOneValidator } from '../../custom-validators/at-least-one';
import { createIsAnOptionValidator } from '../../custom-validators/is-an-option';
import { createIsBrandChosenValidator } from '../../custom-validators/is-brand-chosen';

@Component({
  selector: 'new-car',
  templateUrl: './new-car.component.html',
  styleUrls: ['./new-car.component.css'],
})
export class NewCarComponent implements OnInit, OnDestroy {
  private isExpanded = false;
  public addCarForm: FormGroup = new FormGroup({});

  private equipment: EquipmentElement[] = []; //Whole equipment elements
  public operationalEquipment: OperationalEquipment[] = []; //Elements which are available in the car
  public vehicleImages: File[] = []; //Photos of the car

  public chosenFuels: string[] = [];

  public brands: Brand[] = [];
  public models: Model[] = [];
  public fuels: Fuel[] = [];
  public carbodies: Carbody[] = [];
  public transmissionTypes: TransmissionType[] = [];
  public years: YearOfProduction[] = [];

  private onDestroy$: ReplaySubject<boolean> = new ReplaySubject<boolean>(1);

  public optionsHidden = true;

  public areFuelsLoaded = false;

  public submitClicked = false;

  changeStateOfModels() {
    console.log("CHANGE!!!!");
  }

  onSubmit() {
    this.submitClicked = true;
  }

  displaySelectOptions() {
    (this.optionsHidden) ? this.optionsHidden = false : this.optionsHidden = true;
  }

  changeFuelsState() {
    this.areFuelsLoaded = true;
  }

  updateChoosenFuels(formControlName: string) {
    if (this.addCarForm.get('fuelsOptions')!.get(formControlName)!.value) {
      this.chosenFuels.push(formControlName);
    } else {
      const index = this.chosenFuels.indexOf(formControlName, 0);
      if (index > -1) {
        this.chosenFuels.splice(index, 1);
      }
    }
  }

  updateValue(opElement: OperationalEquipment) {
    if (opElement.isChecked === false) {
      opElement.isChecked = true;
    } else {
      opElement.isChecked = false;
    }
 }

  constructor(private addCarService: VehiclesService, private getEquipmentElementsService: EquipmentService,
    private formBuilder: FormBuilder, private getFiltersService: FiltersService, private loadingSpinnerService: LoadingSpinnerService) {}

  public ngOnDestroy(): void {
    this.onDestroy$.next(true);
    this.onDestroy$.complete();
    this.loadingSpinnerService.changeSpinnerState(false);
    console.log("ngOnDestroy - newCar");
  }

  ngOnInit() {
    this.initForm();
    forkJoin([
      this.getEquipmentElements(),
      this.getCarbodies(),
      this.getFuels(),
      this.getTransmissionTypes(),
      this.getModels(),
      this.getBrands(),
      this.getYears()
    ])
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(
         {
          next: r => {
             this.loadingSpinnerService.changeSpinnerState(true);
             this.initFuelOptions();
             this.changeFuelsState();
          },
           error: err => { console.log("error", err); },
         }
      )
  }

  initForm() {
    this.addCarForm = this.formBuilder.group({
      brand: ['', [Validators.required, createIsAnOptionValidator(this.brands)]],
      model: [{value: '', disabled: true}, [Validators.required, createIsAnOptionValidator(this.models)]],
      yearOfProduction: ['', [Validators.required, createIsAnOptionValidator(this.years)]],
      mileage: ['', Validators.required],
      carbodyType: ['', [Validators.required, createIsAnOptionValidator(this.carbodies)]],
      transmissionType: ['', [Validators.required, createIsAnOptionValidator(this.transmissionTypes)]],
      vehicleImage: ['', Validators.required]
    });
    this.addCarForm.addControl('fuelsOptions', new FormGroup({}));
    this.addCarForm.get('fuelsOptions')!.addValidators(createAtLeastOneValidator());
  }

  initFuelOptions() {
    const fuelsTemp: FormGroup = this.addCarForm.controls.fuelsOptions as FormGroup;
    for (const fuel of this.fuels) {
      fuelsTemp.addControl(fuel.fuelName, new FormControl(false));
    }
  }
 
  fileChanged(event: Event) {
    const imageInputElement = event.target as HTMLInputElement;
    if (imageInputElement.files && imageInputElement.files.length > 0) {
      const files = imageInputElement.files;
      for (const file of files) {
        this.vehicleImages.push(file);
      }
    }
  }

  submitForm() {
    if (this.addCarForm.valid) {
      const formData: AddCarInterface = this.addCarForm.value;
      const newVehicle: Vehicle = new Vehicle();

      newVehicle.brandId = this.brands.find(brand => brand.brandName === formData.brand)!.brandId!;
      newVehicle.modelId = this.models.find(model => model.modelName === formData.model)!.modelId!;

      newVehicle.yearOfProductionId = this.years.find(year => year.year === formData.yearOfProduction)!.yearId!;
      newVehicle.mileage = formData.mileage;

      formData.fuels.forEach(f1 => {
        const matchingFuel = this.fuels.find(f2 => f2.fuelName === f1);
        if (matchingFuel) {
          newVehicle.fuels.push(matchingFuel);
        }
      })

      newVehicle.carbodyId = this.carbodies.find(c => c.carbodyName === formData.carBodyType)!.carbodyId!;

      for (const opElement of this.operationalEquipment) {
        if (opElement.isChecked === true) {
          const matchingEquipmentElement = this.equipment.find(ee => ee.elementId === opElement.eqElement.elementId);
          if (matchingEquipmentElement) {
            newVehicle.equipment.push(matchingEquipmentElement);
          }
        }
      }
      this.addCarService.addVehicle(newVehicle)
        .pipe(takeUntil(this.onDestroy$))
        .subscribe(
          {
            next: r => { debugger },
            error: err => { console.log("błąd"), console.log(err) }
          });
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

  private getEquipmentElements() {
    return this.getEquipmentElementsService.getEquipmentElements()
      .pipe(map(r => this.equipment = r));
  }
  private getCarbodies() {
    return this.getFiltersService.getCarbodies()
      .pipe(map(r => this.carbodies = r));
  }
  private getFuels() {
    return this.getFiltersService.getFuels()
      .pipe(map(r => this.fuels = r));
  }
  private getTransmissionTypes() {
    return this.getFiltersService.getTransmissionTypes()
      .pipe(map(r => this.transmissionTypes = r));
  }
  private getModels() {
    return this.getFiltersService.getModels()
      .pipe(map(r => this.models = r));
  }
  private getBrands() {
    return this.getFiltersService.getBrands()
      .pipe(map(r => this.brands = r));
  }
  private getYears() {
    return this.getFiltersService.getYears()
      .pipe(map(r => this.years = r));
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
