import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomBrandSelectComponent } from './custom-brand-select.component';

describe('CustomBrandSelectComponent', () => {
  let component: CustomBrandSelectComponent;
  let fixture: ComponentFixture<CustomBrandSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomBrandSelectComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomBrandSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
