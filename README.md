# Perfume API

A RESTful Web API for managing a perfume catalog, built with ASP.NET Core 8 and PostgreSQL.

## Tech Stack
- ASP.NET Core 8 Web API
- Entity Framework Core (Code-First)
- PostgreSQL
- Swagger / OpenAPI

## Features
- Full CRUD operations for products
- Bilingual product data (Arabic / English)
- DTO-based request/response separation
- Async database operations
- Database seeding via EF Core migrations

## API Endpoints

| Method | Endpoint            | Description        | Response |
|--------|---------------------|--------------------|----------|
| GET    | /api/products       | Get all products   | 200      |
| GET    | /api/products/{id}  | Get product by id  | 200 / 404|
| POST   | /api/products       | Create a product   | 201      |
| PUT    | /api/products/{id}  | Update a product   | 204 / 404|
| DELETE | /api/products/{id}  | Delete a product   | 204 / 404|

## Getting Started

1. Clone the repo:
git clone https://github.com/AboodAbualrub03/Perfume.Api.git

2. Copy `appsettings.Example.json` to `appsettings.json` and set your PostgreSQL connection string.
3. Apply migrations:
dotnet ef database update

4. Run:
dotnet run

5. Open Swagger at `https://localhost:<port>/swagger`

## Architecture
The project follows a layered structure:
- **Controllers** — handle HTTP requests/responses
- **Services** — business logic
- **Data** — EF Core DbContext
- **Dtos** — data transfer objects
- **Models** — domain entities

