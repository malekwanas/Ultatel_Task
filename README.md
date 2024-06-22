# Ultatel Task

This project is a sample application developed for a job position at Ultatel. It includes a frontend built with Angular 18 and a backend using ASP.NET Web API with .NET 8. The backend handles user authentication and management of student records.

## Table of Contents

- [Installation](#installation)
- [Setup](#setup)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Endpoints](#endpoints)
- [Contact](#contact)

## Installation

### Prerequisites

Before you begin, ensure you have the following installed:

- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)

### Clone the Repository

```bash
git clone https://github.com/malekwanas/Ultatel_Task.git
cd Ultatel_Task
```

## Setup

### Backend

1. Navigate to the backend directory:

    ```bash
    cd backend
    ```

2. Restore the .NET dependencies:

    ```bash
    dotnet restore
    ```

3. Update the `appsettings.json` file with your SQL Server connection string.

4. Apply the migrations to your database:

    ```bash
    dotnet ef database update
    ```

5. Run the backend server:

    ```bash
    dotnet run
    ```

### Frontend

1. Navigate to the frontend directory:

    ```bash
    cd frontend
    ```

2. Install the npm dependencies:

    ```bash
    npm install
    ```

3. Run the frontend server:

    ```bash
    ng serve
    ```

## Usage

Once both the frontend and backend servers are running, you can access the application by navigating to `http://localhost:4200` in your web browser.

## Project Structure

```plaintext
Ultatel_Task/
├── backend/
│   ├── Controllers/
│   │   ├── AccountController.cs
│   │   └── StudentController.cs
│   ├── Models/
│   ├── Services/
│   ├── Repositories/
│   └── Program.cs
└── frontend/
    ├── src/
    │   ├── app/
    │   ├── assets/
    │   └── environments/
    └── angular.json
```

### Endpoints

#### AccountController

- **POST `api/account/Register`**: Registers a new admin user.
- **POST `api/account/Login`**: Authenticates an admin user and returns a JWT token.

#### StudentController

- **GET `api/student/GetAllStudents`**: Retrieves all students with pagination.
- **GET `api/student/SearchStudentsByFilter`**: Searches for students by various filters.
- **DELETE `api/student/DeleteStudent/{id}`**: Deletes a student by ID.
- **PUT `api/student/UpdateStudent/{studentId}`**: Updates a student's details.
- **POST `api/student/AddStudent`**: Adds a new student.

## Contact

- **Email**: malekwanas96@gmail.com
- **LinkedIn**: [Malek Wanas](https://www.linkedin.com/in/malek-wanas/)
