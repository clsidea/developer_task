# ASP.NET Core Backend Assignment – Task Management API 

## Overview
Build a **simple Task Management REST API** using **ASP.NET Core Web API**.
The focus is on **clean backend structure, authentication, and user-scoped data**.

---

## Tech Stack
- ASP.NET Core Web API (.NET 7 or 8)
- Entity Framework Core
- SQL Server (LocalDB is fine)
- JWT Authentication

---

## Project Structure
You are free to structure the project, but a clean layered approach is expected:

/Controllers
/Services
/Repositories
/Models
/DTOs
/Data


---

## Functional Requirements

### 1) Authentication
Implement:
- `POST /api/auth/register`
- `POST /api/auth/login`

Requirements:
- Use JWT authentication
- Protect all task endpoints
- No role management needed (single user role)

---

### 2) Task Management (User-Scoped)
Each task should include:
- `title` (required)
- `description` (optional)
- `status` (Pending | Completed)
- `dueDate` (optional)
- `createdAt` (auto)

Endpoints:
- `POST /api/tasks` – create task
- `GET /api/tasks` – get logged-in user’s tasks only
- `PATCH /api/tasks/{id}/status` – update task status
- `DELETE /api/tasks/{id}` – delete task

Rules:
- A user can only access **their own tasks**
- Use DTOs (do not expose entities directly)
- Validate required fields

---

### 3) Event Tracking on Completion
When a task’s status is updated to **Completed**, insert a record into:

**task_events**
- `id`
- `taskId`
- `userId`
- `type` = `"TASK_COMPLETED"`
- `createdAt`

This table is only for tracking (no background worker needed).

---

## Database
- Use **EF Core Code First**
- Create proper relationships (User ↔ Tasks)
- Provide migrations

---

## API Standards
- RESTful design
- Proper HTTP status codes
- Global exception handling
- Clean, readable, maintainable code

---

## Bonus (Optional)
- Swagger / OpenAPI
- Pagination for task list
- Seed test user data

---

## How to Run (Required in README)
1. Database migration steps
2. How to run the API
3. Required environment variables
4. Sample login credentials
5. Example API calls (curl or Postman)

---

## Submission
- Push the project to **GitHub**
- Include a clear `README.md`
- Share the repository link

---

## Evaluation Criteria
- Authentication correctness
- User-scoped data security
- Code structure & cleanliness
- EF Core usage
- Overall API design quality

Good luck!


