/* eslint-disable @typescript-eslint/no-non-null-assertion */
/* eslint-disable @angular-eslint/component-selector */
/* eslint-disable no-debugger */
import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { VehiclesService } from '../../services/vehicles.service';
import { EquipmentService } from '../../services/equipment.service';
import { FiltersService } from '../../services/filters.service';
import { LoadingSpinnerService } from '../../services/loading-spinner.service';
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

  public fuelOptionsHidden = true;
  public brandOptionsHidden = true;
  public modelOptionsHidden = true;

  public specificModels: Model[] = [];

  public areFuelsLoaded = false;
  public areBrandsLoaded = false;

  public submitClicked = false;

  public brandSearchTerm = "";
  public modelSearchTerm = "";

  @HostListener('document:click', ['$event'])
  onClickFuels(event: MouseEvent) {
    const targetElement = event.target as HTMLElement;

    if (!targetElement.closest('.customFuelSelectAlias')) {
      this.fuelOptionsHidden = true;
    }
    if (!targetElement.closest('.customBrandSelectAlias')) {
      this.brandOptionsHidden = true;
    }
    if (!targetElement.closest('.customModelSelectAlias')) {
      this.modelOptionsHidden = true;
    } 
  }

  updateChoice(dataType: string, choice: string) {
    if (this.checkOrUncheck(dataType, choice)) {
      if (dataType === 'brand') {
        const choosenBrandId = this.brands.find(brand => brand.brandName === choice)!.brandId!;
        this.specificModels = this.models.filter(model => model.brandId === choosenBrandId);
        this.brandSearchTerm = choice;
        this.brandOptionsHidden = true;
      } else {
        this.modelSearchTerm = choice;
        this.modelOptionsHidden = true;
      }
    } else {
        (dataType === "brand") ? (this.brandSearchTerm = "", this.specificModels = []) : this.modelSearchTerm = "";
    }
  }

  checkOrUncheck(dataType: string, choice: string) {
    let control;

    if (dataType === "brand") {
      control = this.addCarForm.get("brandOptions")!.get(choice)!; 
    } else {
      control = this.addCarForm.get("modelOptions")!.get(choice)!;
    }

    if (control.value) {
      return true; //zostala teraz zaznaczona
    }
    return false; //zostala teraz odznaczona
  }

  filterBrands() {
      if (this.brandSearchTerm === "") {
        return this.brands;
      }
      return this.brands.filter(brand => brand.brandName.toLowerCase().startsWith(this.brandSearchTerm.toLowerCase()));
  }

  filterModels() {
    if (this.modelSearchTerm === "") {
      return this.specificModels;
    }
    return this.specificModels.filter(model => model.modelName.toLowerCase().startsWith(this.modelSearchTerm.toLowerCase()));
  }

  onSubmit() {
    this.submitClicked = true;
  }

  displayFuelSelectOptions() {
    (this.fuelOptionsHidden) ? this.fuelOptionsHidden = false : this.fuelOptionsHidden = true;
  }

  displayBrandSelectOptions() {
    (this.brandOptionsHidden) ? this.brandOptionsHidden = false : this.brandOptionsHidden = true;
  }

  displayModelSelectOptions() {
    (this.modelOptionsHidden) ? this.modelOptionsHidden = false : this.modelOptionsHidden = true;
  }

  changeFuelsState() {
    this.areFuelsLoaded = true;
  }

  changeBrandsState() {
    this.areBrandsLoaded = true;
  }

  updateChoosenFuels(formControlName: string) {
    if (this.addCarForm.get('fuelOptions')!.get(formControlName)!.value) {
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
      this.getBrands(),
      this.getModels(),
      this.getYears()
    ])
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(
         {
          next: () => {
             this.loadingSpinnerService.changeSpinnerState(true);
             this.initFuelOptions();
             this.initBrandOptions();
             this.initModelOptions();
             this.changeFuelsState();
             this.changeBrandsState();
             for (const el of this.equipment) {
               this.operationalEquipment.push({ eqElement: el, isChecked: false });
             }
          },
          error: (err) => { console.log(err) },
         }
      )
  }

  initForm() {
    this.addCarForm = this.formBuilder.group({
      yearOfProduction: ['', Validators.required],
      mileage: ['', [Validators.required, Validators.pattern("^[1-9]\\d*$")]],
      carbodyType: ['', Validators.required],
      transmissionType: ['', Validators.required],
      vehicleImage: ['', Validators.required]
    });
    this.addCarForm.addControl('fuelOptions', new FormGroup({}));
    this.addCarForm.get('fuelOptions')!.addValidators(createAtLeastOneValidator());

    this.addCarForm.addControl('brandOptions', new FormGroup({}));
    this.addCarForm.get('brandOptions')!.addValidators(createAtLeastOneValidator());

    this.addCarForm.addControl('modelOptions', new FormGroup({}));
    this.addCarForm.get('modelOptions')!.addValidators(createAtLeastOneValidator());
  }

  initFuelOptions() {
    const fuelsTemp: FormGroup = this.addCarForm.controls.fuelOptions as FormGroup;
    for (const fuel of this.fuels) {
      fuelsTemp.addControl(fuel.fuelName, new FormControl(false));
    }
  }

  initBrandOptions() {
    const brandsTemp: FormGroup = this.addCarForm.controls.brandOptions as FormGroup;
    for (const brand of this.brands) {
      brandsTemp.addControl(brand.brandName, new FormControl(false));
    }
  }

  initModelOptions() {
    const modelsTemp: FormGroup = this.addCarForm.controls.modelOptions as FormGroup;
    for (const model of this.models) {
      modelsTemp.addControl(model.modelName, new FormControl(false));
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
      const formData = this.addCarForm.value;
      const newVehicle: Vehicle = new Vehicle();

      newVehicle.brandId = this.brands.find((brand) => brand.brandName === this.brandSearchTerm)!.brandId;
      newVehicle.modelId = this.models.find((model) => model.modelName === this.modelSearchTerm)!.modelId;

      newVehicle.yearOfProductionId = this.years.find(year => year.year === formData.yearOfProduction)!.yearId!;
      newVehicle.transmissionTypeId = this.transmissionTypes.find(tt => tt.typeName === formData.transmissionType)!.typeId!;

      newVehicle.mileage = formData.mileage;

      for (const fuel of this.chosenFuels) {
        const selectedFuelId = this.fuels.find((f) => f.fuelName === fuel)!.fuelId;
        newVehicle.fuelsIds.push(selectedFuelId);
      }

      newVehicle.carbodyId = this.carbodies.find((c) => c.carbodyName === formData.carbodyType)!.carbodyId!;

      for (const opElement of this.operationalEquipment) {
        if (opElement.isChecked === true) {
          const matchingEquipmentElementId = this.equipment.find(ee => ee.elementId === opElement.eqElement.elementId)!.elementId;
          newVehicle.equipmentIds.push(matchingEquipmentElementId);
        }
      }

      this.addCarService.addVehicle(newVehicle)
        .pipe(takeUntil(this.onDestroy$))
        .subscribe(
          {
            next: (r) => {
              this.addCarService.addVehicleImages(r, this.vehicleImages)
              .pipe(takeUntil(this.onDestroy$))
              .subscribe(
                {
                  next: (r) => { console.log(r) },
                  error: (err) => {console.log(err) }
                });
            },
            error: (err) => { console.log(err) }
          });
    }
    else {
      console.log("Form is not valid!!!");
      this.getFormValidationErrors();
    } 
  }

  getFormValidationErrors() {
    Object.keys(this.addCarForm.controls).forEach((key) => {
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
