import { Component, OnDestroy, OnInit } from '@angular/core';
import { GetCarsService } from '../../services/get-cars.service'
import { GetFiltersService } from '../../services/get-filters.service'
import { Vehicle } from '../../models/Vehicle';
import { PriceType } from '../../models/PriceType';
import { SortingType } from '../../models/SortingType';
import { CarbodyType } from '../../models/CarbodyType';
import { FuelType } from '../../models/FuelType';
import { TransmissionType } from '../../models/TransmissionType';
import { ReplaySubject, takeUntil } from 'rxjs';

@Component({
  selector: 'fleet',
  templateUrl: './fleet.component.html',
  styleUrls: ['./fleet.component.css'],
})
export class FleetComponent implements OnInit, OnDestroy {
  mainBanner: string = 'assets/images/dope-cars-banner.png';
  data: Vehicle[] = [];

  priceTypes: PriceType[] = [];
  sortingTypes: SortingType[] = [];
  carbodyTypes: CarbodyType[] = [];
  fuelTypes: FuelType[] = [];
  transmissionTypes: TransmissionType[] = [];

  private onDestroy$: ReplaySubject<boolean> = new ReplaySubject<boolean>(1);

  public ngOnDestroy(): void {
    this.onDestroy$.next(true);
    this.onDestroy$.complete();
  }

  constructor(private getCarsService: GetCarsService, private getFiltersService: GetFiltersService
   ) { }

  ngOnInit() {
    this.getCarsService.getCars()
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
