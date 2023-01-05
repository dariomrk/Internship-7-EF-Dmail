# Internship-7-EF-Dmail

Simulation of an email client.  
Main focus on Entity Framework, Postgres, LINQ and design patterns.

## Project setup
1. Edit `App.example.config`.
   - Edit the connection string.
   - Rename `App.example.config` to `App.config`.
2. Apply migrations.
   - Open the `Package Manager Console` (Visual Studio) : `View > Other Windows > Package Manager Console`.
   - Make sure that the selected project is `Internship-7-EF-Dmail.Data`.
   - Run `Update-Database` in the Package Manager Console.

## Database diagram
![database diagram](./dbDiagram.png)

## Seed data

**Login info:**

| Username                 | Password                 |
| ------------------------ | ------------------------ |
| `administrator@dmail.hr` | `administrator-password` |
| `user@dmail.hr`          | `user-password`          |
| `dario@dmail.hr`         | `password`               |
  