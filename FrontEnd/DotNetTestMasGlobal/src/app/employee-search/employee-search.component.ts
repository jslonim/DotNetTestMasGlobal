import { stringify } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { Employee } from '../shared/Entities/employee';
import { EmployeeSearchService } from './employee-search.service';

@Component({
  selector: 'app-employee-search',
  templateUrl: './employee-search.component.html',
  styleUrls: ['./employee-search.component.css']
})
export class EmployeeSearchComponent implements OnInit {

  public employeeList : Employee[] = [];
  public employeeId  : string = '';
  public canShowNoResult : boolean = false;
  public canShowLoading : boolean = false;
  
  constructor(private employeeSearchService : EmployeeSearchService) { }

  ngOnInit(): void {

  }

  seachEmployee(){
    this.employeeList = [];
    this.canShowLoading = true;
    this.canShowNoResult = false;
    if(this.employeeId == ''){
      this.employeeSearchService.GetAllEmployees().subscribe(
        result =>{
          this.employeeList = result;
          this.canShowNoResult = true;
          this.canShowLoading = false;
        }
      );
    }
    else if (!isNaN(Number(this.employeeId))){
      this.employeeSearchService.GetEmployeeById(Number(this.employeeId)).subscribe(
        result =>{
          if(result != null){
            this.employeeList.push(result);
          }
          this.canShowNoResult = true;
          this.canShowLoading = false;
        }
      );
    } 
  }

}
