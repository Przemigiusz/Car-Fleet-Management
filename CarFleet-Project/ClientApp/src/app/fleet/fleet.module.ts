import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FleetComponent } from './fleet.component'
import { CommonModule } from '@angular/common';

import { GetCarsService } from '../../services/get-cars.service'
import { GetFiltersService } from '../../services/get-filters.service'


@NgModule({
  declarations: [
    FleetComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: FleetComponent, pathMatch: 'full' },
    ])
  ],
  providers: [GetCarsService, GetFiltersService],
  bootstrap: []
})
export class FleetModule { }
