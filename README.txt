On The Beach Test
Outor: John Manzno
Date:30.04.15

<------PRE REQUIREMENTS--->
1. - Visual Studio 2010+
2. - SQL Server 2008+

<------DEPLOY DATABASE--->
1. - Open the 'EmployeeSalarySearch.v12.suo' in Visual Studio.
2. - On the 'Database' project, right click 'Publish' - fill the required boxes on the pop window and click 'Publish' (Note: you can give any database name, however to make things easier latter on, I recommend the database name as 'OnTheBeachPayRoll'.
3. - Go to and expand 'EmployeeSalarySearch' project, double click in the 'App.Config' file, in the '<connectionStrings>' tag, change the 'data source=' value to your local SQL server e.g: '.\SQLSERVERNAME'
4. - Done and ready to Rock and Roll!


<-----RUNNING THE CONSOLE IN ISOLATION---->

1. - Compile the solution.
2. - From windows file explorer, go to ~EmployeeSalarySearch\EmployeeSalarySearch\bin\Debug\bin, and double click in 'EmployeeSalarySearch.exe' file. 
