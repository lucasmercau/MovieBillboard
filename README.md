# Movie Billboard Project .NET Razor
## How to run project
If you are using Visual Studio Code, you need to select Program.cs and then Run the Code using "Debug project associated with this file" the button is on the upper-right section of Visual Studio Code. If you have "Run Code" you need to change the option for "Debug project associated with this file" to run the application.

If you are using Visual Studio 2022, you will need to select "Open a proyect or solution", and then select the MovieBillboard.sln on the root, then press "Ctrl" + "F5" to run the program.

Do not forget to have .NET 7.0 or 8.0 installed on your computer.
## Authentification
If you want to try by yourself CRUD you will need an account, you can try: 
- Account: user1@gmail.com
- Password: User1!

If the account is not working you can create your own account on the Register Page. The password must be at least 6 characters long and you will need to use a uppercase letter, a lowecase letter, a number, and at least one non alphanumeric character. Then it will send you to a Confirmation Page where you will need to confirm your mail to be able to use your account.
## Database
The program has already a database with some data, but if you want to re-start the database, you will need to delete the file called MovieContext-...-.db in the root, also you will need to delete the folder called "Migrations", and in the console write the following:

dotnet ef migrations add InitialCreate

dotnet ef database update

If you press Enter you will re-start the database.
