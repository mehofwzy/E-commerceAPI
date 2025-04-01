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
## 📝 Sample of Json requests used for testing APIs
-- Customer Table
CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,     -- Unique Identifier (auto-incremented)
    Name NVARCHAR(100) NOT NULL,            -- Full Name of the customer
    Email NVARCHAR(100) NOT NULL UNIQUE,    -- Email (must be unique)
    Phone NVARCHAR(20) NOT NULL             -- Phone number
);

-- Product Table
CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,      -- Unique Identifier (auto-incremented)
    Name NVARCHAR(100) NOT NULL,            -- Name of the product
    Description NVARCHAR(500) NULL,         -- Description of the product
    Price DECIMAL(18, 2) NOT NULL,          -- Price of the product
    Stock INT NOT NULL                      -- Available stock for the product
);

-- Order Table
CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,      -- Unique Identifier (auto-incremented)
    CustomerId INT NOT NULL,                -- Reference to Customer
    OrderDate DATETIME NOT NULL,            -- Date when the order was placed
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending', -- Order Status (default is 'Pending')
    TotalPrice DECIMAL(18, 2) NOT NULL,     -- Total Price of the Order
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);

-- Order_Product Table (Many-to-Many relationship between Orders and Products)
CREATE TABLE OrderProducts (
    OrderId INT NOT NULL,                  -- Reference to Order
    ProductId INT NOT NULL,                -- Reference to Product
    Quantity INT NOT NULL,                 -- Quantity of the product in the order
    PRIMARY KEY (OrderId, ProductId),      -- Composite primary key
    CONSTRAINT FK_OrderProducts_Orders FOREIGN KEY (OrderId) REFERENCES Orders(Id),
    CONSTRAINT FK_OrderProducts_Products FOREIGN KEY (ProductId) REFERENCES Products(Id)
);



---

## 📜 License

This project is made by Eng.Mohamed Fawzy - .NET Software Developer

---

## 📌 Author

Developed by **Mohamed Fawzy**

- 📧 Email: [mehofawzy@outlook.com](mailto\:mehofawzy@outlook.com)
- 🌐 Portfolio: [linkedin.com/in/mehofwzy](https://linkedin.com/in/mehofwzy)

