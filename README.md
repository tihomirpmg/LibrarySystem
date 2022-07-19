# Library System

## Author Details

 - Name: Tihomir Naydenov
 - E-mail: <tihomirn884@gmail.com>

## Application Description

	This is Blazor Server Application for Library System.
In this library system can be added new books. In the page section can be viewed catalogue of books. 
There are three types of roles administrator, librarian and reader each with different accesses. A user can be registered and role librarian can be added by administrator.

## Start The Project

### 1.Change Connection

	To start this Blazor Server application you need to change
1. `DefaultConnection` in **appsettings.json** with `"DefaultConnection": "Server=.;Database=LibrarySystem;Trusted_Connection=True;MultipleActiveResultSets=true"`
2. Change debug type to `IIS Express`
3. Open `Package Manager Console`
4. Change `Default project` to `LibrarySystem.Data`
5. Type there `update-database`
6. Enter