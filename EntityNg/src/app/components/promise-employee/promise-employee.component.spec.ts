import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PromiseEmployeeComponent } from './promise-employee.component';

describe('PromiseEmployeeComponent', () => {
  let component: PromiseEmployeeComponent;
  let fixture: ComponentFixture<PromiseEmployeeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PromiseEmployeeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PromiseEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
