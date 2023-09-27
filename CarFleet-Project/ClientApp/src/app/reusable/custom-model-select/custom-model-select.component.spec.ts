import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomModelSelectComponent } from './custom-model-select.component';

describe('CustomModelSelectComponent', () => {
  let component: CustomModelSelectComponent;
  let fixture: ComponentFixture<CustomModelSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomModelSelectComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomModelSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
