import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  why: string = 'assets/images/why.png';
  cartoonCar: string = 'assets/images/cartoon-car.png';
  accessibility: string = 'assets/images/accessibility.png';
  forEveryBudget: string = 'assets/images/for-every-budget.png';
  inWholeCountry: string = 'assets/images/in-whole-country.png';
  ecological: string = 'assets/images/ecological.png';
  mainBanner: string = 'assets/images/dope-cars-banner.png';
}
