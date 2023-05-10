# SET UP THE PROJECT ON YOUR SYSTEM

## Necessary tools and software
- XAMPP
- Visual Studio ( ASP.NET and web Development module )


### Before setting up the database you need to install some NuGet packages
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- Pomelo.EntityFrameworkCore.MySql

### Follow the steps to create necessary database and table. 
- First open the appsettings.json and update the `ConnectionStrings['DefaultConnectionString']` to your local MariaDB details.
- Next, Open Package Mannager Console and enter the folloing commands
  - `add-migration MyEmployeeContext`
  - `update-database`
- After this open your localhost database (phpmyadmin). There you will see new databse created named ``projectDB`` and 2 tables in it ``emoloyees`` and migration history table.
- If everything is fine with the setup, Then run the code.

- <b>Note: </b> Enter Some Dummy data in the `employees` table