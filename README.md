# People Certificates Management API

This is a .NET Core API for managing person's certificates. With this API, you can perform CRUD (Create, Read, Update, Delete) operations to manage information about person's certificates.

## Features

- **Person**: Represents a person with basic information such as name, date of birth, email, phone number, address, etc.
- **Certificate**: Represents a certificate associated with a specific person. Each certificate has a title, a description, and an issue date.

## API Endpoints

### Person

- **GET /api/person**: Returns all registered person.
- **GET /api/person/{id}**: Returns details of a specific person by their ID.
- **POST /api/person**: Creates a new person with the data provided in the request body.
- **PUT /api/person/{id}**: Updates data of a specific person by their ID, with the data provided in the request body.
- **DELETE /api/person/{id}**: Deletes a specific person by their ID.

### Certificate

- **GET /api/certificates**: Returns all registered certificates.
- **GET /api/certificates/{id}**: Returns details of a specific certificate by its ID.
- **POST /api/certificates**: Creates a new certificate associated with a specific person, with the data provided in the request body.
- **PUT /api/certificates/{id}**: Updates data of a specific certificate by its ID, with the data provided in the request body.
- **DELETE /api/certificates/{id}**: Deletes a specific certificate by its ID.

## Technologies Used

- **.NET Core 3.1**: Framework for developing web applications.
- **MongoDB**: NoSQL database for data storage.

## Project Setup

1. **Clone the Repository**:
git clone https://github.com/your-user/your-project.git

2. **Install Dependencies**:
cd your-project
dotnet restore

3. **Configure Database**:
Make sure you have MongoDB installed and running on your local machine. You can also configure the connection to the database in the `appsettings.json` file.

4. **Run the Project**:
dotnet run

5. **Access the API**:
The API will be available at `http://localhost:5000` by default.

## Contributing
Contributions are welcome! Feel free to open issues or send pull requests to improve this project.
