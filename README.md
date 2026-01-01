# e-libraryProject
e-libraryProject is an ASP.NET Core MVC web application for managing books, authors, and their relationships in a digital library system.
The system uses ASP.NET Core Identity for authentication and authorization, supports role-based access, and follows clean MVC and database design principles.

🚀 Features

🔐 Authentication & Authorization

ASP.NET Core Identity with custom ApplicationUser

Login, Register, Logout

Global authentication (all pages require login)

Home page accessible anonymously

Role-based authorization

Admin / User roles

Admin-only access to specific controllers (e.g. BookAuthors)

🧩 Data Models & Relationships

Book

Author

BookAuthor (join entity)

Many-to-Many relationship between Books and Authors

Unique constraint to prevent duplicate book–author links

EF Core Fluent API configuration

🧪 Validation

Data Annotations used extensively:

[Required]

[StringLength]

[EmailAddress]

[Phone]

[Range]

Enum property (EBookStatus)

Schema annotation for database configuration

Custom validation using ModelState.AddModelError

📄 CRUD Operations

Full CRUD functionality for:

Books

Authors

BookAuthors

Delete confirmation pages

Validation messages displayed in UI

🧭 Routing

Default MVC routing

{controller}/{action}/{id}


Attribute routing implemented on selected controllers

🎨 UI & Styling

Bootstrap via CDN

Bootswatch Flatly theme

Automatic dark mode using Bootswatch Darkly

Responsive layout

Consistent styling across tables and action buttons

🧠 View Features

Usage of ViewData and ViewBag

Partial Views for reusable UI components (e.g. action buttons)

🛠️ Technologies Used

ASP.NET Core MVC

Entity Framework Core

ASP.NET Core Identity

SQL Server

Bootstrap 5

Bootswatch (Flatly + Darkly)

C#

⚙️ Setup Instructions

Clone the repository

Configure the database connection string in appsettings.json

Run migrations:

Update-Database


Run the project

Login using the seeded admin account (if enabled)

👤 Default Roles

Admin: Full access (manage books, authors, and relationships)

User: Read-only access

📌 Notes

Bootstrap is loaded via CDN

Bootswatch Flatly is used for light mode

Bootswatch Darkly is used automatically for dark mode

Identity UI uses default (non-scaffolded) pages

📄 License

This project is for educational purposes.
