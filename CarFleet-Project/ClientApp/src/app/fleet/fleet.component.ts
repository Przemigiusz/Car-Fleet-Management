import { Component, OnInit } from '@angular/core';
import { GetCarsService } from '../../services/get-cars.service'
import { GetFiltersService } from '../../services/get-filters.service'
import { Vehicle } from '../../models/Vehicle';
import { PriceType } from '../../models/PriceType';
import { SortingType } from '../../models/SortingType';
import { CarbodyType } from '../../models/CarbodyType';
import { FuelType } from '../../models/FuelType';
import { TransmissionType } from '../../models/TransmissionType';

@Component({
  selector: 'fleet',
  templateUrl: './fleet.component.html',
  styleUrls: ['./fleet.component.css'],
})
export class FleetComponent implements OnInit {
  mainBanner: string = 'assets/images/dope-cars-banner.png';
  data: Vehicle[] = [];

  priceTypes: PriceType[] = [];
  sortingTypes: SortingType[] = [];
  carbodyTypes: CarbodyType[] = [];
  fuelTypes: FuelType[] = [];
  transmissionTypes: TransmissionType[] = [];

  constructor(private getCarsService: GetCarsService, private getFiltersService: GetFiltersService
   ) { }

  ngOnInit() {
    this.getCarsService.getCars().subscribe(r => { this.data = r; }, err => { console.log("error", err); });
    this.getFiltersService.getPricesPerDay().subscribe(r => { this.priceTypes = r; }, err => { console.log("error", err); });
    this.getFiltersService.getSortingTypes().subscribe(r => { this.sortingTypes = r; }, err => { console.log("error", err); });
    this.getFiltersService.getCarbodyTypes().subscribe(r => { this.carbodyTypes = r; }, err => { console.log("error", err); });
    this.getFiltersService.getFuelTypes().subscribe(r => { this.fuelTypes = r; }, err => { console.log("error", err); });
    this.getFiltersService.getTransmissionTypes().subscribe(r => { this.transmissionTypes = r; }, err => { console.log("error", err); });
  }
}
