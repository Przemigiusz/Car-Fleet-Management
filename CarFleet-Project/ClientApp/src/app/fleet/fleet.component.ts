/* eslint-disable @angular-eslint/component-selector */
import { Component, OnDestroy, OnInit } from '@angular/core';
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

@Component({
  selector: 'fleet',
  templateUrl: './fleet.component.html',
  styleUrls: ['./fleet.component.css'],
})
export class FleetComponent implements OnInit, OnDestroy {
  public mainBanner = 'assets/images/dope-cars-banner.png';

  public vehicles: Vehicle[] = [];
  public priceRanges: PriceRange[] = [];
  public sortingTypes: SortingType[] = [];
  public carbodies: Carbody[] = [];
  public fuels: Fuel[] = [];
  public transmissionTypes: TransmissionType[] = [];

  private onDestroy$: ReplaySubject<boolean> = new ReplaySubject<boolean>(1);

  public ngOnDestroy(): void {
    this.onDestroy$.next(true);
    this.onDestroy$.complete();
    this.loadingSpinnerService.changeSpinnerState(false);
    console.log("ngOnDestroy - fleet");
  }

  constructor(private vehiclesService: VehiclesService, private getFiltersService: FiltersService, private loadingSpinnerService: LoadingSpinnerService)
  {}

  ngOnInit() {
    forkJoin([
      this.getVehicles(),
      this.getPriceRanges(),
      this.getSortingTypes(),
      this.getTransmissionTypes(),
      this.getCarbodies(),
      this.getFuels(),
      this.getTransmissionTypes()
    ])
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(
        {
          next: () => {
            this.loadingSpinnerService.changeSpinnerState(true);
          },
          error: (err) => { console.log(err) },
        }
      )
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
}


