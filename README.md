# OrderedListProject

## Overview

This project provides C# implementations for a generic ordered list with key operations like `Push`, `Pop`, `Peek`, and `IsEmpty`. Currently, two distinct implementations are provided based on their time complexity:

### 1. QuickPopOrderedList:
   - `Pop`: O(1)
   - `Push`: O(n)

### 2. QuickPushOrderedList<T>:
   - `Pop`: O(n)
   - `Push`: O(1)

## Testing

The project offers both Console-based and Unit testing frameworks. Tests focus on:

* Validating the accuracy of `Push` and `Pop` operations.
* Ensuring adherence to the specified time complexity.
* Currently, tests are centered around integer arrays using a standard sorting algorithm.

## Development Roadmap

- **Generic Testing**:
  - Transition functions within the `OrderedListTests` project to generic methods to accommodate various data types beyond integers.
  
- **Expanded Test Cases**:
  - Incorporate tests for data types other than integers. This would involve leveraging alternative ordering algorithms suited to those types.
  - Enhance the breadth and complexity of tests. Instead of merely inserting and popping all values, introduce more intricate scenarios.
  - Factor in multi-threading considerations with dedicated tests.

- **Project Deployment**:
  - Dockerize the application for consistent and scalable deployment.
  - Provide comprehensive documentation detailing the deployment and usage process.


