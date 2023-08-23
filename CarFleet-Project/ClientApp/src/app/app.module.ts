import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FooterMenuComponent } from './footer-menu/footer-menu.component';
import { NewCarComponent } from './new-car-form/new-car.component'; 
import { FleetComponent } from './fleet/fleet.component';

import { AddCarService } from '../services/add-car.service';
import { GetCarsService } from '../services/get-cars.service';
import { GetFiltersService } from '../services/get-filters.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FooterMenuComponent,
    NewCarComponent,
    FleetComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'new-car', component: NewCarComponent, pathMatch: 'full' },
      { path: 'fleet', component: FleetComponent, pathMatch: 'full' },
    ])
  ],
  providers: [AddCarService, GetCarsService, GetFiltersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
