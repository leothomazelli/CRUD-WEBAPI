import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/Employees';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  btnAction = 'Register';
  btnTitle = 'Register Employee';
  constructor(
    private employeeService: EmployeeService,
    private router: Router
  ) {}
  createEmployee(employee: Employee) {
    this.employeeService.CreateEmployee(employee).subscribe((data) => {
      this.router.navigate(['/']);
    });
  }
}
