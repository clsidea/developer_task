# ASP.NET Core Backend Assignment – Task Management API 

## Overview
A Task Management REST API built with ASP.NET Core Web API featuring JWT authentication, user-scoped tasks, and task event tracking.

---

## Tech Stack
- ASP.NET Core Web API (8)
- Entity Framework Core
- SQL Server
- JWT Authentication

---

## Project Structure

- /Controllers -> API endpoints
- /Services -> Business logic
- /Repositories -> Data access layer
- /Models -> Entities & Enums
- /Models/DTOs -> Data Transfer Objects
- /Extensions -> Mapping extensions (DTO and Entity)
- /Data -> DbContext & Migrations
- /Middleware -> Global exception handler
- /Helpers -> JWT Token generator


---

## Functional Requirements

### 1) Authentication
Implement:
- `POST /api/auth/register`
- `POST /api/auth/login`

---

### 2) Task Management
- POST /api/tasks – create a task

- GET /api/tasks – list logged-in user’s tasks

- PATCH /api/tasks/{id}/status?status=Completed – update task status

- DELETE /api/tasks/{id} – delete task

- Only the task owner can access or modify their tasks

### 2) Task Events
- When a task status is updated to Completed, a record is inserted into TaskEvents table for tracking

---

## Models
- User
- TaskItem
- TaskEvent

## Database
- EF Core Code-First

- User and Tasks → one-to-many relationship

- Task and TaskEvents → one-to-many relationship

- Migrations included

---

## Authentication
- JWT with symmetric key

- Token required as Bearer in Authorization header

---

## Validations
- All DTOs have DataAnnotations validation

- Global Exception Handler ensures consistent JSON error responses

---

## Running the API
1. Setup environment variables
```
JWT_KEY=MySuperSecretKeyThatIsLongAsFar123#@QWERTY!
JWT_ISSUER=TaskManagementAPI
JWT_AUDIENCE=TaskManagementAPIUsers
```
2. Apply migrations
```
Add-Migration "Initial Migration" -Context ApplicationDbContext
```
3. Run the API
4. Test endpoints
- Use Postman, Swagger, or curl


## Author
Hizbullah


