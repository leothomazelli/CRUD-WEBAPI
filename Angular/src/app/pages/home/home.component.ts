import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/Employees';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  employees: Employee[] = [];
  generalEmployees: Employee[] = [];

  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.employeeService.GetEmployees().subscribe((data) => {
      const responseData = data.data;
      responseData.map((item) => {
        item.createdAt = new Date(item.createdAt!).toLocaleDateString('pt-BR');
        item.updatedAt = new Date(item.updatedAt!).toLocaleDateString('pt-BR');
      });
      this.employees = data.data;
      this.generalEmployees = data.data;
      console.log(this.employees);
    });
  }
  search(event: Event) {
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.employees = this.generalEmployees.filter((employee) => {
      return employee.name.toLowerCase().includes(value);
    });
  }
}
