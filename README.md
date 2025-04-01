# E-Commerce API

## 📌 Overview

This is a RESTful API built using **.NET Core**, **Entity Framework Core**, and **Fluent Validation** for managing products, customers, and orders in an e-commerce application.

## 🚀 Features

- Manage **Customers** (Create, Retrieve)
- Manage **Orders** (Create, Retrieve, Update Status)
- Manage **Products** (Create, Retrieve)
- **Validation** using Fluent Validation
- **Swagger Documentation** for API testing
- **Code-First Approach** with EF Core migrations

## 🛠️ Technologies Used

- .NET Core 7/8
- Entity Framework Core
- Fluent Validation
- SQL Server
- Swagger (Swashbuckle)

## 📂 Project Structure

```
ECommerceAPI/
│-- ECommerceAPI/          # Main API Project
│   │-- Controllers/       # API Controllers
│   │-- Models/            # Entity Models
│   │-- Data/              # Database Context
│   │-- Validators/        # Fluent Validation Rules
│   └── Program.cs         # Entry Point
│
└── ECommerceAPI.Tests/    # Unit Testing Project
```

---

## 🏗️ Setup and Installation

### 🔹 Prerequisites

- .NET SDK 7/8
- SQL Server

### 🔹 Clone the Repository

```sh
git clone https://github.com/mehofwzy/E-commerceAPI.git
cd ECommerceAPI
```

### 🔹 Install Dependencies

```sh
dotnet restore
```

### 🔹 Database Migration

```sh
dotnet ef migrations add InitialCreate

dotnet ef database update
```

### 🔹 Run the Application

```sh
dotnet run
```

### 🔹 Access Swagger Documentation

Open in your browser:

```
https://localhost:<port>/swagger
```

---

## 📢 API Endpoints

### **Customer Management**

- **GET** `/api/customers` → Retrieve all customers
- **POST** `/api/customers` → Create a new customer
- **GET** `/api/customers/{id}` → Get details of a specific customer
  
### **Order Management**

- **POST** `/api/orders` → Create a new order
- **GET** `/api/orders/{id}` → Get details of an order
- **POST** `/api/UpdateOrderStatus/{id}` → Update order status to "Delivered"
  
### **Product Management**

- **GET** `/api/products` → Retrieve all products
- **POST** `/api/products` → Add a new product
- **GET** `/api/products/{id}` → Get details of a product



---

## ✅ HTTP Status Codes

| Status Code               | Meaning                       |
| ------------------------- | ----------------------------- |
| 200 OK                    | Successful response           |
| 201 Created               | Resource successfully created |
| 400 Bad Request           | Validation error              |
| 404 Not Found             | Resource not found            |
| 500 Internal Server Error | Unexpected server error       |

---

## 🧪 Running Unit Tests

```sh
dotnet test
```

---

## 📜 License

This project is made by Eng.Mohamed Fawzy - .NET Software Developer

---

## 📌 Author

Developed by **Mohamed Fawzy**

- 📧 Email: [mehofawzy@outlook.com](mailto\:mehofawzy@outlook.com)
- 🌐 Portfolio: [linkedin.com/in/mehofwzy](https://linkedin.com/in/mehofwzy)

