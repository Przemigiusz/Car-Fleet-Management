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
import { ReplaySubject, takeUntil } from 'rxjs';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'fleet',
  templateUrl: './fleet.component.html',
  styleUrls: ['./fleet.component.css'],
})
export class FleetComponent implements OnInit, OnDestroy {
  public mainBanner = 'assets/images/dope-cars-banner.png';

  public data: Vehicle[] = [];
  public priceRanges: PriceRange[] = [];
  public sortingTypes: SortingType[] = [];
  public carbodies: Carbody[] = [];
  public fuels: Fuel[] = [];
  public transmissionTypes: TransmissionType[] = [];

  private onDestroy$: ReplaySubject<boolean> = new ReplaySubject<boolean>(1);

  public ngOnDestroy(): void {
    this.onDestroy$.next(true);
    this.onDestroy$.complete();
  }

  constructor(private vehiclesService: VehiclesService, private getFiltersService: FiltersService, private sanitizer: DomSanitizer)
  {}

  ngOnInit() {
    this.vehiclesService.getVehicles()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe({ next: r => { this.data = r; }, error: err => { console.log("error", err); } }); 
    this.getFiltersService.getPriceRanges()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe({ next: r => { this.priceRanges = r; }, error: err => { console.log("error", err); } });
    this.getFiltersService.getSortingTypes()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe({ next: r => { this.sortingTypes = r; }, error: err => { console.log("error", err); } });
    this.getFiltersService.getCarbodies()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe({ next: r => { this.carbodies = r; }, error: err => { console.log("error", err); } });
    this.getFiltersService.getFuels()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe({ next: r => { this.fuels = r; }, error: err => { console.log("error", err); } });
    this.getFiltersService.getTransmissionTypes()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe({ next: r => { this.transmissionTypes = r; }, error: err => { console.log("error", err); } });
  }
}
