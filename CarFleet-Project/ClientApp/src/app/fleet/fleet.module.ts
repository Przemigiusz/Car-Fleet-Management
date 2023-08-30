import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FleetComponent } from './fleet.component'
import { CommonModule } from '@angular/common';

import { VehiclesService } from '../../services/vehicles.service'
import { FiltersService } from '../../services/filters.service'


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
  providers: [VehiclesService, FiltersService],
  bootstrap: []
})
export class FleetModule { }
