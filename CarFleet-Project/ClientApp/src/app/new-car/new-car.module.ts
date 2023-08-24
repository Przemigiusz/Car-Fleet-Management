import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AddCarService } from '../../services/add-car.service';
import { NewCarComponent } from './new-car.component';

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
  providers: [AddCarService],
  bootstrap: []
})
export class NewCarModule { }