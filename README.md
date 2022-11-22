**What is a service bus?**

*A service bus is a layer of abstraction above a messaging system like RabbitMq which helps us implement messaging between disparate applications in a distributed system without worrying about low level implementation details like exchanges, queues and bindings in RabbitMq.*

**What is MassTransit?**

*MassTransit is an example of a service bus implementation which is a free, open-source, distributed application framework for .NET applications. It abstracts away the underlying logic required to work with message brokers, such as RabbitMQ, making it easier to create message-based, loosely coupled applications.*

**There are a few fundamental concepts we should cover first:**

**1- Service Bus, usually shortened to Bus**, is the term given to the type of application that handles the movement of messages.

**2- Transports** are the different types of message brokers MassTransit works with, including RabbitMQ, InMemory, Azure Service Bus, and more.

**3- Message** is a contract, defined code first by creating a .NET class or interface.

**4- Command** is a type of message, specifically used to tell a service to do something. These message types are sent to an endpoint (queue) and will be expressed using a verb-noun sequence.

**5- Events** are another message type, signifying that something has happened. Events are published to one or multiple consumers and will be expressed using noun-verb (past tense) sequence.

**Why Use MassTransit?**

*There are a few benefits to choosing to use a library such as MassTransit, instead of working with the native message broker library. Firstly, by abstracting the underlying message broker logic, we can work with multiple message brokers, without having to completely rewrite our code. This allows us to work with something such as the InMemory transport when working locally, then when deploying our code, use another transport such as Azure Service Bus or Amazon Simple Queue Service.
Additionally, when we work with a message-based architecture, there are a lot of specific patterns we need to be aware of and implement, such as retry, circuit breaker, outbox to name a few. MassTransit handles all of this for us, along with many other features such as exception handling, distributed transactions, and monitoring.*

