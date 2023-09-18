import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { VehiclesService } from '../../services/vehicles.service';
import { EquipmentService } from '../../services/equipment.service';
import { NewCarComponent } from './new-car.component';
import { FiltersService } from '../../services/filters.service';

@NgModule({
  declarations: [
    NewCarComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: '', component: NewCarComponent, pathMatch: 'full' },
    ])
  ],
  providers: [VehiclesService, EquipmentService, FiltersService],
  bootstrap: []
})
export class NewCarModule { }
