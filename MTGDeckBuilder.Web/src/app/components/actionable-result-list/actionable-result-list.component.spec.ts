import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionableResultListComponent } from './actionable-result-list.component';

describe('ActionableResultListComponent', () => {
  let component: ActionableResultListComponent;
  let fixture: ComponentFixture<ActionableResultListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActionableResultListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ActionableResultListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
