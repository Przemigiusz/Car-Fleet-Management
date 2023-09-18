import { Component, OnDestroy, OnInit } from '@angular/core';
import { LoadingSpinnerService } from '../../services/loading-spinner.service'
import { ReplaySubject } from 'rxjs/internal/ReplaySubject';
import { takeUntil } from 'rxjs';

@Component({
  selector: 'app-loading-spinner',
  templateUrl: './loading-spinner.component.html',
  styleUrls: ['./loading-spinner.component.css']
})
export class LoadingSpinnerComponent implements OnInit, OnDestroy {
  public isSpinnerHidden = false;

  private onDestroy$: ReplaySubject<boolean> = new ReplaySubject<boolean>(1);

  public ngOnDestroy(): void {
    this.onDestroy$.next(true);
    this.onDestroy$.complete();
    console.log("ngOnDestroy - loadingSpinner");
  }

  constructor(private loadingSpinnerService: LoadingSpinnerService) { }

  ngOnInit() {
    console.log("ngOnInit - loadingSpinner");
    this.loadingSpinnerService.isSpinnerHidden$()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe({
        next: r => { this.isSpinnerHidden = r; console.log(r); },
        error: err => { console.log("error", err) }
      })
  }
}
