# Shopping Cart Service

This service manages a shopping cart for the e-commerce application. It includes functionalities to add items, remove items, clear the cart, and retrieve cart details. Data is persisted in PostgreSQL, and caching is done using Redis for quick access.

## Prerequisites

- .NET 8 SDK
- PostgreSQL
- Redis
- Docker

## Features

- Asynchronous operations for scalability
- Uses Redis for caching cart data
- Serilog for logging
- Adheres to best practices for error handling, input validation, and security

## Running the Service

1. Set up PostgreSQL and Redis:

   - Update the `appsettings.json` file with correct connection strings.

2. Build and run the application using Docker:

   ```
   docker build -t shopping-cart-service .
   docker run -p 5000:80 shopping-cart-service
   ```

3. Access the Swagger UI for API documentation:
   - Navigate to `https://localhost:5000/swagger` in your browser.

## API Endpoints

- `GET /api/cart/{cartId}`: Retrieve the cart by ID.
- `POST /api/cart/{cartId}/items`: Add an item to the cart.
- `DELETE /api/cart/{cartId}/items/{productId}`: Remove an item from the cart.
- `DELETE /api/cart/{cartId}/clear`: Clear all items from the cart.

##Run redis needed on docker

# Pull the latest Redis image from Docker Hub

docker pull redis:latest

# Run a Redis container

docker run --name ecommerce-redis -d \
 -p 6379:6379 \
 -v redis_data:/data \
 redis:latest \
 --appendonly yes

echo "Redis is running on port 6379"
