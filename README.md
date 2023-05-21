# SET UP THE PROJECT ON YOUR SYSTEM

## Necessary tools and software
- XAMPP
- Visual Studio ( ASP.NET and web Development module )
- Google account


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

### Setting up to google accound for retrinving the files
- Login/Register to [Google console](console.cloud.google.com)
- Create a new project 
  - ![Step 1](http://drive.google.com/uc?export=view&id=1Y-9YLSZdymMXQ5w30tY_SDp8zBMRlQhk)
  - ![Step 2](http://drive.google.com/uc?export=view&id=16hwhIxD3_UUbY1FyHwTQk_-biWzPpLNN)
- Select the project you created just now
- Enable Google Drive API
  - ![Step 1](http://drive.google.com/uc?export=view&id=1Hkjwt1dhi0x8MjOtbwjuEcAS1fjbvC6M)
  - ![Step 2](http://drive.google.com/uc?export=view&id=1METR987atMN5YBMbZmq96oQZQOAQwZlk)
  - ![Step 3](http://drive.google.com/uc?export=view&id=1PKnvVkLS2kZmnX7DG461VYxlyRSu9hoa)
  - ![Step 4](http://drive.google.com/uc?export=view&id=1Ze8NPOCxrCpx-MhkWMdr-VXOyexZv7vs)
- Configure the OAuth consent screen
  - ![Step 1](http://drive.google.com/uc?export=view&id=1gmM9TwqGhA8Dw4JS5fCy0qSrDs3wkvWf)
  - Fill necessary details on OAuth consent screen and click `SAVE AND CONTINUE`
  - On the Scopes page click `ADD OR REMOVE SCOPES` and search for `Google Drive API` and add all the fileds then click `SAVE AND CONTINUE`
  - On the test users screen add a user *(note: The user must hava a valid google email account) after you have added a vaild user click `SAVE AND CONTINUE`
- Create credentials for accessing the google drive
  - Go to Credentials section
  - ![Step 1](http://drive.google.com/uc?export=view&id=1c2jvXf379qUQhwkEsRNqqVrM8-mSgY6B)
  - ![Step 2](http://drive.google.com/uc?export=view&id=1oESKMUe8ZObCP6v6sYhBLqfp30n5wFKg)
  - ![Step 2](http://drive.google.com/uc?export=view&id=1r-Kp1POL7mJVShEJt9pWIMbbqD2uci7I)
  - Give a name and click `CREATE`
  - ![Step 2](http://drive.google.com/uc?export=view&id=1eYHC1Fjp5C3e0Nxdm2duz8M5IQhA-gj6)

### Creating a necessary folderes in google drive
- Login in to your google drive account [Login](drive.google.com) *(note: account must be same as before)
- Create a folder named `Employee`
- In the `Employee` folder create forder with `employee IDS`, eg 1,2,3 etc. *(note: folder names should only contain integer names.)
- Upload `pdf/images(jpeg,jpg,png)` into the respective `employee ID` folders.

### If you have completed the above steps continue
- Rename the `.json` file which was downloaded before to `credentials.json`
- Copy and paste `credentials.json` to project folder path: `\bin\Debug\net7.0`.
## Thats all you need to do 😊👌