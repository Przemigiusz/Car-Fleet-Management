import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { FooterMenuComponent } from './footer-menu/footer-menu.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { LoadingSpinnerModule } from './loading-spinner/loading-spinner.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'


@NgModule({
  declarations: [
    AppComponent,
    FooterMenuComponent,
    NavMenuComponent,
  ],
  imports: [
    LoadingSpinnerModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    RouterModule.forRoot([

      {
        path: '', loadChildren: () => import('./home/home.module')
          .then(m => m.HomeModule) },
      {
        path: 'fleet', loadChildren: () => import('./fleet/fleet.module')
          .then(m => m.FleetModule) },
      {
        path: 'new-car', loadChildren: () => import('./new-car/new-car.module')
          .then(m => m.NewCarModule) },
    ]),
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
