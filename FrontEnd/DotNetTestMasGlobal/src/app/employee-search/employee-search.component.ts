import { Component, OnInit } from '@angular/core';
import { Employee } from '../shared/Entities/employee';

@Component({
  selector: 'app-employee-search',
  templateUrl: './employee-search.component.html',
  styleUrls: ['./employee-search.component.css']
})
export class EmployeeSearchComponent implements OnInit {

  public employeeList : Employee[]
  constructor() { }

  ngOnInit(): void {
    
  }

}
