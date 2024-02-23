# The Kitchen Routing System

This project is prototype to a restaurant order routing application which exposes an endpoint to create an order and place messages in multiple queues according to the kitchen area assigned to a specific item.

**Author**: Iarah Gonçalves de Almeida

## Stack and tools used

- Microsoft Visual Studio Community 2022 v17.8
- C# and .NET 8.0
- Swagger/OpenAPI
- RabbitMQ
- xUnit

## Installation

- Make sure you have a Visual Studio v17.8 or later, .NET 8 and a Docker installation ready on your setup
- Run this command in your terminal to setup the RabbitMQ:

`docker run -d --hostname rmq --name rmq-server -p 8080:15672 -p 5672:5672 rabbitmq:3.12-management`

- Open the PointOfSale.sln
- Set the src/Presentation as your Startup Project
- Run the app
    
## Functionalities

- The `POST` order endpoint creates a new order and store it in an in-process list, simulating a database in a real project.
- The `POST` order endpoint also sends a message to a specific queue in RabbitMQ, acting as a Producer.
- There are Unit Tests for the Domain project and Integration tests for the Presentation project.
- The Kitchen Area is represented as a Value Object, trowing an UnsupportedKitchenArea exception when an area is not mapped.
- The OrderController will return a bad request status code for unsupported kitchen areas.

## Improvements for the future

Some points to consider:
- The MessageQueue could be improved by using Exchanges, and the responsibility for routing should be configured on the Exchange instead of figuring out the correct queue in the MessageQueueService.
- Some sort of validation should be implemented and configured to return the correct HTTP code and meaningful errors.
- Since this is an Event Based architecture, a CQRS pattern would be a great addition to the project.
- Of course, a in-memory database would be a better option to show off the ORM and SQL skills.
- The idea is to have other services acting as consumers for the message queues, and the PointOfSale would probably act as a consumer later on to get the completed items and update the order status.
