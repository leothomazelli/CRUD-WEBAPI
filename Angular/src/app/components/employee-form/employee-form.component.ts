import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Employee } from 'src/app/models/Employees';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css'],
})
export class EmployeeFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<Employee>();
  @Input() btnAction!: string;
  @Input() btnTitle!: string;
  @Input() employeeData: Employee | null = null;
  employeeForm!: FormGroup;

  constructor() {}

  ngOnInit(): void {
    this.employeeForm = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      department: new FormControl('', [Validators.required]),
      shift: new FormControl('', [Validators.required]),
      active: new FormControl(true),
      createdAt: new FormControl(new Date()),
      updatedAt: new FormControl(new Date()),
    });
  }

  submit() {
    this.onSubmit.emit(this.employeeForm.value);
  }
}
