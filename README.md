# Dapp

## Overview

A dating app for those who have the guts to go live and chat with potential matches

### Packages

1. **API**:
   - A .NET Core application responsible for managing the APIs for the app. It handles data persistence, user authentication, and the business logic for the application.

2. **Shared**:
   - Contains shared TypeScript code, including constants, custom types, and auto-generated types. These types are derived from the API's Swagger specifications and are shared across the `web` and `webrtc-server` packages to ensure type safety and consistency.

3. **Web**:
   - A Next.js application that serves as the front-end web client. This package provides the user interface for interacting with the application.

4. **WebRTC-Server**:
   - A WebSocket server that manages TCP connections for real-time data and WebRTC signaling. It facilitates peer-to-peer connections for live interactions between users.

5. **Worker**:
   - This package is responsible for running the background jobs, including sending transactional/scheduled emails.

---

## Prerequisites

To run the project locally, ensure the following dependencies are installed:

- **PostgreSQL**: Version 15 or higher.
- **Yarn**: Version 1.x.x.
- **Node.js**: Version 20.x.x.
- **.NET SDKs**: Compatible with the .NET Core application.

---

## Setup Instructions

### 1. Database Setup

1. **Create the Database and Apply Migrations:**

   ```bash
   cd api
   dotnet ef database update
   ```

2. **Seed the Database:**
   - To seed fake data like rooms and users:

     ```bash
     dotnet run seed-fake-data
     ```

   - To seed required data like system questions and countries:

     ```bash
     dotnet run seed-required-data
     ```

   - To run both of the above scripts:

     ```bash
     dotnet run seed-all
     ```

3. **Run the API in Watch Mode:**

   ```bash
   dotnet watch
   ```

### 2. Generate Front-End and WebRTC Server Types

After running the API for the first time or whenever the models have changed, you need to regenerate the TypeScript types for the front end and WebRTC server.

1. Navigate to the `shared` directory:

   ```bash
   cd shared
   ```

2. Run the following command to generate the types:

   ```bash
   yarn generate-types
   ```

### 3. Run the WebRTC Server

1. Navigate to the `webrtc-server` directory:

   ```bash
   cd webrtc-server
   ```

2. Start the WebRTC server:

   ```bash
   yarn start
   ```

### 4. Run the Front-End Client

1. Navigate to the `web` directory:

   ```bash
   cd web
   ```

2. Install dependencies:

   ```bash
   yarn install
   ```

3. Start the development server:

   ```bash
   yarn dev
   ```

---

## Additional Commands

### 1. Apply Database Migrations

We are using the Code to SQL approach, so after changing any database entity inside the code, follow these steps to apply your changes to the DB:

1. Add a migration:

   ```bash
   dotnet ef migrations add {name_of_the_migration}
   ```

2. Apply the migration to the database:

   ```bash
   dotnet ef database update
   ```

### 2. Seed Database Data

- Fake data:

  ```bash
  dotnet run seed-fake-data
  ```

- Required data:

  ```bash
  dotnet run seed-required-data
  ```

- Both fake and required data:

  ```bash
  dotnet run seed-all
  ```

---

## Notes

1. Ensure all dependencies are installed before starting.
2. Update the TypeScript types (`yarn generate-types`) after modifying API models.
3. Follow the proper sequence when starting components to avoid errors.

---

## Contribution Guidelines

- Follow the coding conventions defined for each package.
- Ensure proper type safety and consistency.
- Write meaningful commit messages.
- Add tests for new features and bug fixes.

---

## Future Enhancements

- Add Docker support for easier setup.
- Implement CI/CD pipelines for automated testing and deployment.
- Enhance documentation with architecture diagrams and API specifications.

---

## Contact

For further assistance, reach out to the project maintainers.
