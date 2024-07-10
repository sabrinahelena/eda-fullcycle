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
