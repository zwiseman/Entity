import { Component, OnInit, OnDestroy } from '@angular/core';
import { EmployeesService } from 'services/index';
import { Subscription } from 'rxjs';
import { MatDialog} from '@angular/material/dialog';
import { EditEmployeeComponent } from 'components/edit-employee/edit-employee.component';
import { Router } from '@angular/router';
import { CreateEmployeeComponent } from 'components/create-employee/create-employee.component';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  employees: any;

  constructor(private employeeService: EmployeesService, public dialog: MatDialog,
    private router: Router) { }

  ngOnInit() {
    this.subscription = this.employeeService.getEmployeesObserve().subscribe(data => {
      this.employees = data;
    });
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  delete(employee) {
    this.subscription = this.employeeService.deleteEmployee(employee).subscribe(data => {
      console.log('deleted');
      this.router.navigateByUrl('/employees');
    });
  }

  details(employee) {
    const dialogRef = this.dialog.open(EditEmployeeComponent, {
      width: '250px',
      data: employee
    });
  }

  create() {
    const dialogRef = this.dialog.open(CreateEmployeeComponent, {
      width: '250px'
    });
  }
}
