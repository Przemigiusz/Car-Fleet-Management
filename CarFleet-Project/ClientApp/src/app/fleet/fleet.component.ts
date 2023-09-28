/* eslint-disable @typescript-eslint/no-non-null-assertion */
/* eslint-disable @angular-eslint/component-selector */
import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { VehiclesService } from '../../services/vehicles.service'
import { FiltersService } from '../../services/filters.service'
import { Vehicle } from '../../models/Vehicle';
import { PriceRange } from '../../models/PriceRange';
import { SortingType } from '../../models/SortingType';
import { Carbody } from '../../models/Carbody';
import { Fuel } from '../../models/Fuel';
import { TransmissionType } from '../../models/TransmissionType';
import { ReplaySubject, forkJoin, map, takeUntil } from 'rxjs';
import { LoadingSpinnerService } from '../../services/loading-spinner.service';
import { Model } from '../../models/Model';
import { Brand } from '../../models/Brand';
import { FormControl, FormGroup } from '@angular/forms';
import { chosenBrand } from '../../models/chosen-brand';

@Component({
  selector: 'fleet',
  templateUrl: './fleet.component.html',
  styleUrls: ['./fleet.component.css'],
})
export class FleetComponent implements OnInit, OnDestroy {
  public mainBanner = 'assets/images/dope-cars-banner.png';

  public customSelects: FormGroup = new FormGroup({});

  public vehicles: Vehicle[] = [];
  public priceRanges: PriceRange[] = [];
  public sortingTypes: SortingType[] = [];
  public carbodies: Carbody[] = [];
  public fuels: Fuel[] = [];
  public transmissionTypes: TransmissionType[] = [];

  public brands: Brand[] = [];
  public models: Model[] = [];

  public brandOptionsHidden = true;
  public modelOptionsHidden = true;
 
  public chosenBrands: chosenBrand[] = [];
  public chosenModels: string[] = [];

  public areFuelsLoaded = false;
  public areBrandsLoaded = false;

  public brandSearchTerm = "";
  public modelSearchTerm = "";

  private onDestroy$: ReplaySubject<boolean> = new ReplaySubject<boolean>(1);

  @HostListener('document:click', ['$event'])
  onClickFuels(event: MouseEvent) {
    const targetElement = event.target as HTMLElement;

    if (!targetElement.closest('.customBrandSelectAlias')) {
      this.brandOptionsHidden = true;
    }
    if (!targetElement.closest('.customModelSelectAlias')) {
      this.modelOptionsHidden = true;
    }
  }

  updateChoosenBrandsOrModels(dataType: string, choice: string) {
    if (this.checkOrUncheckBrandsOrModels(dataType, choice)) {
      if (dataType === 'brand') {
        const brand1 = this.brands.find(brand => brand.brandName === choice)!;
        const brand2 = new chosenBrand(brand1.brandId, brand1.brandName);
        this.chosenBrands.push(brand2);
      } else {
        this.chosenModels.push(choice);
      }
    } else {
      if (dataType === 'brand') {
        const index = this.chosenBrands.findIndex(brand => brand.brandName === choice);
        if (index > -1) {
          this.chosenBrands.splice(index, 1);
        }
      } else {
        const index = this.chosenModels.indexOf(choice, 0);
        if (index > -1) {
          this.chosenModels.splice(index, 1);
        }
      }
    }
  }

  checkOrUncheckBrandsOrModels(dataType: string, choice: string) {
    let control;

    if (dataType === "brand") {
      control = this.customSelects.get("brandOptions")!.get(choice)!;
    } else {
      control = this.customSelects.get("modelOptions")!.get(choice)!;
    }

    if (control.value) {
      return true; //zostala teraz zaznaczona
    }
    return false; //zostala teraz odznaczona
  }

  public ngOnDestroy(): void {
    this.onDestroy$.next(true);
    this.onDestroy$.complete();
    this.loadingSpinnerService.changeSpinnerState(false);
    console.log("ngOnDestroy - fleet");
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

  constructor(private vehiclesService: VehiclesService, private getFiltersService: FiltersService, private loadingSpinnerService: LoadingSpinnerService)
  {}

  ngOnInit() {
    this.initForm();
    forkJoin([
      this.getVehicles(),
      this.getPriceRanges(),
      this.getSortingTypes(),
      this.getTransmissionTypes(),
      this.getCarbodies(),
      this.getFuels(),
      this.getTransmissionTypes(),
      this.getModels(),
      this.getBrands()
       
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
          },
          error: (err) => { console.log(err) },
        }
      )
  }

  filterBrands() {
    if (this.brandSearchTerm === "") {
      return this.brands;
    }
    return this.brands.filter(brand => brand.brandName.toLowerCase().startsWith(this.brandSearchTerm.toLowerCase()));
  }

  filterModels() {
    if (this.modelSearchTerm === "") {
      return this.models.filter(model => this.chosenBrands.some(brand => brand.brandId === model.brandId));
    }
    return this.models.filter(model => model.modelName.toLowerCase().startsWith(this.modelSearchTerm.toLowerCase()));
  }

  initForm() {
    this.customSelects.addControl('fuelOptions', new FormGroup({}));
    this.customSelects.addControl('brandOptions', new FormGroup({}));
    this.customSelects.addControl('modelOptions', new FormGroup({}));
  }

  initFuelOptions() {
    const fuelsTemp: FormGroup = this.customSelects.get("fuelOptions") as FormGroup;
    for (const fuel of this.fuels) {
      fuelsTemp.addControl(fuel.fuelName, new FormControl(false));
    }
  }

  initBrandOptions() {
    const brandsTemp: FormGroup = this.customSelects.get("brandOptions") as FormGroup;
    for (const brand of this.brands) {
      brandsTemp.addControl(brand.brandName, new FormControl(false));
    }
  }

  initModelOptions() {
    const modelsTemp: FormGroup = this.customSelects.get("modelOptions") as FormGroup;
    for (const model of this.models) {
      modelsTemp.addControl(model.modelName, new FormControl(false));
    }
  }

  private getVehicles() {
    return this.vehiclesService.getVehicles()
      .pipe(map(r => this.vehicles = r));
  }
  private getPriceRanges() {
    return this.getFiltersService.getPriceRanges()
      .pipe(map(r => this.priceRanges = r));
  }
  private getSortingTypes() {
    return this.getFiltersService.getSortingTypes()
      .pipe(map(r => this.sortingTypes = r));
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
}


