# Unit Conversion API

## Overview

Unit Conversion API is a RESTful ASP.NET Core Web API that allows users to convert numerical values between different units of measurement.

The API currently supports the following conversion categories:

* Length
* Weight / Mass
* Temperature

The application is built using .NET 8 and follows a layered architecture to separate API, application, infrastructure, and domain concerns.

---

## Technology Stack

* ASP.NET Core Web API (.NET 8)
* C#
* Swagger / OpenAPI
* Dependency Injection
* Custom Exception Handling
* RFC7807 ProblemDetails Responses

---

## Project Structure

```text
UnitConversion
│
├── Controllers
├── DTOs
├── Middleware
├── Program.cs
│
├── UnitConversion.Application
│   ├── Exceptions
│   └── Interface
│
├── UnitConversion.Infrastructure
│   ├── Data
│   └── Service
│
└── UnitConversion.Domain
```

### Layer Responsibilities

#### API Layer

Responsible for:

* Handling HTTP requests
* Returning HTTP responses
* Swagger/OpenAPI configuration
* Dependency Injection configuration
* Global exception middleware

#### Application Layer

Responsible for:

* Service contracts (interfaces)
* Application-specific exceptions

#### Infrastructure Layer

Responsible for:

* Unit conversion implementation
* Hardcoded unit definitions
* Business logic execution

#### Domain Layer

Reserved for domain entities and business models.

---

## Supported Units

### Length

* Meter
* Kilometer
* Centimeter
* Foot
* Inch

### Weight / Mass

* Kilogram
* Gram
* Pound
* Ounce

### Temperature

* Celsius
* Fahrenheit
* Kelvin

---

## API Endpoint

### Convert Units

```http
POST /api/unitconversion
```

### Request Body

```json
{
  "category": "length",
  "fromUnit": "meter",
  "toUnit": "foot",
  "value": 10
}
```

### Successful Response

```json
{
  "originalValue": 10,
  "fromUnit": "meter",
  "toUnit": "foot",
  "convertedValue": 32.808398950131235
}
```

---

## Example Conversions

### Length Conversion

Request:

```json
{
  "category": "length",
  "fromUnit": "meter",
  "toUnit": "foot",
  "value": 10
}
```

Response:

```json
{
  "originalValue": 10,
  "fromUnit": "meter",
  "toUnit": "foot",
  "convertedValue": 32.808398950131235
}
```

### Weight Conversion

Request:

```json
{
  "category": "weight",
  "fromUnit": "kilogram",
  "toUnit": "pound",
  "value": 1
}
```

Response:

```json
{
  "originalValue": 1,
  "fromUnit": "kilogram",
  "toUnit": "pound",
  "convertedValue": 2.2046244201837775
}
```

### Temperature Conversion

Request:

```json
{
  "category": "temperature",
  "fromUnit": "celsius",
  "toUnit": "fahrenheit",
  "value": 100
}
```

Response:

```json
{
  "originalValue": 100,
  "fromUnit": "celsius",
  "toUnit": "fahrenheit",
  "convertedValue": 212
}
```

---

## Error Handling

The API uses custom exceptions and global exception middleware.

Invalid requests return standardized RFC7807 ProblemDetails responses.

Example:

```json
{
  "title": "Invalid Conversion Request",
  "status": 400,
  "detail": "Unit 'invalid' not found.",
  "instance": "/api/unitconversion"
}
```

---

## Running the Application

### Prerequisites

* .NET 8 SDK
* Visual Studio 2022

### Clone Repository

```bash
git clone <repository-url>
```

### Build Project

```bash
dotnet build
```

### Run Application

```bash
dotnet run
```

Or start the application directly from Visual Studio using:

```text
F5
```

---

## Swagger Documentation

After running the application, Swagger UI is available at:

```text
https://localhost:<port>/swagger
```

Swagger can be used to test all available endpoints directly from the browser.
