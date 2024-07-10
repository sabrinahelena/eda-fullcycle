# eda-fullcycle

This repository contains projects and exercises from the FullCycle course on Event-Driven Architecture (EDA). Here, you'll find implementations and experiments related to EDA concepts and practices.

## About the Course

The FullCycle course on Event-Driven Architecture (EDA) dives deep into the principles and practices of EDA. The course covers various topics, including event sourcing, CQRS, and the integration of microservices through events. As a participant, I am learning how to design and implement systems that leverage events to decouple components and enable scalable, responsive architectures.

## Projects

### 1. Event Dispatcher

The first project I have uploaded is focused on creating an Event Dispatcher. This project is titled 'events' and includes the following components:

- **Event Interface**: Defines the basic structure of an event, including methods for retrieving the event name, date, and payload.
- **Event Handler Interface**: Represents a handler that processes events.
- **Event Dispatcher Interface**: Manages the registration, removal, and dispatching of event handlers.

#### Key Features

- **Register Handlers**: Allows for the registration of multiple handlers for specific events.
- **Dispatch Events**: Dispatches events to the appropriate handlers based on the event name.
- **Remove Handlers**: Removes handlers from specific events.
- **Check Handlers**: Verifies if a handler is registered for a specific event.
- **Clear Handlers**: Clears all registered handlers.

### 2. Book Management with Event Handling

The second project builds on the Event Dispatcher project by implementing a simple library system that creates and updates books, generating events when these actions occur. This project demonstrates how to use the event dispatcher and handler system to manage events in a practical application.

#### Components

- **Book**: Represents a book with a title, author, and published date.
- **BookCreatedEvent**: Event triggered when a new book is created.
- **BookUpdatedEvent**: Event triggered when an existing book is updated.
- **CreateBookHandler**: Handles the creation of books and dispatches the `BookCreatedEvent`.
- **UpdateBookHandler**: Handles the updating of books and dispatches the `BookUpdatedEvent`.
- **BookCreatedEventHandler**: Handles the `BookCreatedEvent` to perform actions when a new book is created.
- **BookUpdatedEventHandler**: Handles the `BookUpdatedEvent` to perform actions when a book is updated.

#### Example Usage

Here's how the process of creating and updating a book, and handling the events works:

1. **Setup the Event Dispatcher and Handlers**:
    - An instance of `EventDispatcher` is created.
    - Handlers are registered to listen for the `BookCreatedEvent` and `BookUpdatedEvent`.

2. **Create a Book**:
    - The `CreateBookHandler` is used to create a new book.
    - When a book is created, a `BookCreatedEvent` is dispatched.

3. **Update a Book**:
    - The `UpdateBookHandler` is used to update an existing book.
    - When a book is updated, a `BookUpdatedEvent` is dispatched.

4. **Handle the Events**:
    - The `BookCreatedEventHandler` receives the `BookCreatedEvent` and processes it, such as logging the book details to the console.
    - The `BookUpdatedEventHandler` receives the `BookUpdatedEvent` and processes it, such as logging the updated book details to the console.

5. **Remove a Handler**:
    - Handlers can be removed from the `EventDispatcher`. For example, the `BookCreatedEventHandler` can be removed, and subsequent book creations will not trigger this handler.
