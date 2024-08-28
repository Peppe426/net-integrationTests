# net-integrationTests

Purpose: The primary goal of this repository is to provide examples and templates for writing tests in .NET, which can be useful for learning and applying best practices in test-driven development (TDD).

---

This repository provides a boilerplate for demonstrating various testing best practices in .NET using NUnit. It includes examples of different types of tests: unit tests, integration tests, and acceptance tests.

## Repository Structure

- **/UnitTests**: Contains unit tests for testing individual components in isolation.
- **/IntegrationTests**: Includes tests for verifying interactions between components or services.
- **/AcceptanceTests**: Focuses on end-to-end testing to ensure the system meets business requirements.

## Getting Started

To use this boilerplate, follow these steps:

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/Peppe426/net-tests.git
   ```

2. **Navigate to the Project Directory:**
   ```bash
   cd net-tests
   ```

3. **Restore Dependencies:**
   ```bash
   dotnet restore
   ```

4. **Build the Solution:**
   ```bash
   dotnet build
   ```

5. **Run the Tests:**
   ```bash
   dotnet test
   ```


## Best Practices

- **Keep Tests Isolated**: Each test should be independent and not rely on the state of other tests.
- **Clear Naming**: Name tests clearly to describe their purpose and expected outcome.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
