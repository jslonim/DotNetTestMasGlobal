import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeSearchComponent } from './employee-search/employee-search.component';

const routes: Routes = [
  { path: '', component: EmployeeSearchComponent },
  { path: 'EmployeeSearch', component: EmployeeSearchComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
