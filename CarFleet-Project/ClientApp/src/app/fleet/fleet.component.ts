import { Component, OnInit } from '@angular/core';
import { GetCarsService } from '../../services/get-cars.service'
import { Vehicle } from '../../models/Vehicle';

@Component({
  selector: 'fleet',
  templateUrl: './fleet.component.html',
  styleUrls: ['./fleet.component.css'],
})
export class FleetComponent implements OnInit {
  mainBanner: string = 'assets/images/dope-cars-banner.png';
  data: Vehicle[] = [];

  constructor(private getCarsService: GetCarsService) { }

  ngOnInit() {
    this.getCarsService.getCars().subscribe(r => { this.data = r; }, err => { console.log("error", err); });
  }
}
