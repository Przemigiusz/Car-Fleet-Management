import { Component, OnInit } from '@angular/core';
import { GetCarsService } from '../../services/get-cars.service'
import { GetFiltersService } from '../../services/get-filters.service'
import { Vehicle } from '../../models/Vehicle';
import { PricesPerDay } from '../../models/PricesPerDay';
import { SortingTypes } from '../../models/SortingTypes';
import { CarbodyTypes } from '../../models/CarbodyTypes';
import { FuelTypes } from '../../models/FuelTypes';

@Component({
  selector: 'fleet',
  templateUrl: './fleet.component.html',
  styleUrls: ['./fleet.component.css'],
})
export class FleetComponent implements OnInit {
  mainBanner: string = 'assets/images/dope-cars-banner.png';
  data: Vehicle[] = [];
  

  constructor(private getCarsService: GetCarsService, private getFiltersService: GetFiltersService,
    private pricesPerDay: PricesPerDay,
    private sortingTypes: SortingTypes,
    private carbodyTypes: CarbodyTypes,
    private fuelTypes: FuelTypes,) { }

  ngOnInit() {
    this.getCarsService.getCars().subscribe(r => { this.data = r; }, err => { console.log("error", err); });
    this.getFiltersService.getPricesPerDay().subscribe(r => { this.pricesPerDay = r; }, err => { console.log("error", err); });
    this.getFiltersService.getSortingTypes().subscribe(r => { this.sortingTypes = r; }, err => { console.log("error", err); });
    this.getFiltersService.getCarbodyTypes().subscribe(r => { this.carbodyTypes = r; }, err => { console.log("error", err); });
    this.getFiltersService.getFuelTypes().subscribe(r => { this.fuelTypes = r; }, err => { console.log("error", err); });
  }
}
