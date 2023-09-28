import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FleetComponent } from './fleet.component'
import { CommonModule } from '@angular/common';

import { VehiclesService } from '../../services/vehicles.service'
import { FiltersService } from '../../services/filters.service'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    FleetComponent,
  ],
  imports: [
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: '', component: FleetComponent, pathMatch: 'full' },
    ])
  ],
  providers: [VehiclesService, FiltersService],
  bootstrap: []
})
export class FleetModule { }
