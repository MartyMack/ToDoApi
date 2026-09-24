# ToDo API

A RESTful To-Do List API built with C#, ASP.NET Core, Entity Framework Core, and PostgreSQL.

## Overview

ToDo API is a backend REST API for managing tasks. It supports creating, viewing, updating, completing, and deleting tasks.

The project was built to practice modern ASP.NET Core Web API development, dependency injection, DTOs, service-layer architecture, Entity Framework Core, PostgreSQL, and RESTful API design.

## Features

- Create a Todo
- Get all Todos
- Get a Todo by ID
- Update a Todo
- Toggle Todo completion
- Delete a Todo
- Request validation
- PostgreSQL database persistence
- Entity Framework Core migrations
- Swagger/OpenAPI documentation

## Tech Stack

- **Language:** C#
- **Framework:** ASP.NET Core 10
- **ORM:** Entity Framework Core
- **Database:** PostgreSQL
- **API Documentation:** Swagger / OpenAPI
- **Version Control:** Git / GitHub
- **IDE:** Visual Studio Code

## Architecture

The API follows a simple layered architecture:

```text
HTTP Request
     ↓
Controller
     ↓
DTO
     ↓
Service
     ↓
EF Core / DbContext
     ↓
PostgreSQL
