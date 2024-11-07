# eShop Microservices API
## Overview
This project is a microservices-based eShop API built with .NET. The application is divided into several microservices, each responsible for handling specific eCommerce functionalities, allowing for scalability and modularity.

## Microservices
1. Order Microservice:
  - Customers can create, view, and cancel orders, add items to the shopping cart, and checkout.
  - Admins can view all orders with pagination, sorted by order date.

2. Product Microservice:
  - Customers can view products with pagination and filter by category.
  - Admins can add, update, and delete products.

3. Shipping Microservice:
  - Customers can view the shipping status of their orders.
  - Admins can update shipping statuses.

4. Reviews Microservice:
  - Customers can create and view product reviews.
  - Admins can approve or reject reviews.

5. Promotions Microservice:
  - Customers can view current promotions.
  - Admins can create, update, and delete promotions.

## Key Features
- Role-based Access: Separate functionalities for customers and admins.
- Pagination & Sorting: For orders and products.
- RESTful API: Organized, maintainable endpoints for each microservice.
- Scalability: Modular microservice architecture to support easy scaling and maintenance.

## Tech Stack
- Backend: .NET Core, ASP.NET Core Web API
- Database: SQL Server
- API Documentation: Swagger
