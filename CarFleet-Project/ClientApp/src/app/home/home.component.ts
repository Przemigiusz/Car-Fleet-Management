import { Component, OnDestroy, OnInit } from '@angular/core';
import { ReplaySubject } from 'rxjs/internal/ReplaySubject';
import { LoadingSpinnerService } from '../../services/loading-spinner.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit, OnDestroy{
  why = 'assets/images/why.png';
  cartoonCar = 'assets/images/cartoon-car.png';
  accessibility = 'assets/images/accessibility.png';
  forEveryBudget = 'assets/images/for-every-budget.png';
  inWholeCountry = 'assets/images/in-whole-country.png';
  ecological = 'assets/images/ecological.png';
  mainBanner = 'assets/images/dope-cars-banner.png';

  private onDestroy$: ReplaySubject<boolean> = new ReplaySubject<boolean>(1);

  constructor(private loadingSpinnerService: LoadingSpinnerService) { }

  public ngOnDestroy(): void {
    this.loadingSpinnerService.changeSpinnerState(false);
    console.log("ngOnDestroy - home");
  }

  ngOnInit() {
    this.loadingSpinnerService.changeSpinnerState(true);
  }


}
