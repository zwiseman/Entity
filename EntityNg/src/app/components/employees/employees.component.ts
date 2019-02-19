import { Component, OnInit, OnDestroy } from '@angular/core';
import { EmployeesService } from 'services/index';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  employees = 'this employee';
  i = 0;
  value: string;

  constructor(private employeeService: EmployeesService) { }
  ngOnInit() {
    this.subscription = this.employeeService.getEmployeesObserve().subscribe(data => {
      console.log(data);
    });
  }

  log() {
    this.i++;
    console.log('we did it ' + this.i);
  }

  change () {
    console.log(this.value);
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

}
