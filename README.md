# DotNetTestMasGlobal
This project was made in .Net Core 3.1 Web API for the backend and Agular 11 for the frontend

## Backend API Endpoints
### **(GET) Employee/GetEmployees**
Gets all employees from the API URL provided for this test

### **(GET) Employee/GetEmployeeById/{id}**

Gets an employee using an ID parameter from the API URL provided for this test

## Backend Structure
This project is built with an N-Layer architechture including a business layer and a data layer, also includes a test project which contains an example test of one 
business layer method

Includes Swagger for the documentation

![image](https://user-images.githubusercontent.com/3581335/110256150-14fe2300-7f76-11eb-84f5-b618385bb0ca.png)



## FrontEnd Structure
The frontend has been split in components from the main app component and includes a share folder for shared components and classes.

The search component includes a service class to call the API on the backend and an Employee class to use an specific class insted of a generic Any type.

The UI is built using Bootstrap for the table and the seatch button while using Flexbox for the position of the UI Components.

![image](https://user-images.githubusercontent.com/3581335/110256347-39a6ca80-7f77-11eb-9d12-a9bdf5279e59.png)

