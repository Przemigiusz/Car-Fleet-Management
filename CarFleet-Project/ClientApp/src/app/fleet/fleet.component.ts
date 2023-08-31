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
  public mainBanner: string = 'assets/images/dope-cars-banner.png';

  public data: Vehicle[] = [];
  public priceTypes: PriceRange[] = [];
  public sortingTypes: SortingType[] = [];
  public carbodyTypes: Carbody[] = [];
  public fuelTypes: Fuel[] = [];
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
      .subscribe(r => { this.data = r; }, err => { console.log("error", err); }); 
    this.getFiltersService.getPricesPerDay()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(r => { this.priceTypes = r; }, err => { console.log("error", err); });
    this.getFiltersService.getSortingTypes()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(r => { this.sortingTypes = r; }, err => { console.log("error", err); });
    this.getFiltersService.getCarbodyTypes()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(r => { this.carbodyTypes = r; }, err => { console.log("error", err); });
    this.getFiltersService.getFuelTypes()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(r => { this.fuelTypes = r; }, err => { console.log("error", err); });
    this.getFiltersService.getTransmissionTypes()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(r => { this.transmissionTypes = r; }, err => { console.log("error", err); });
  }
}
