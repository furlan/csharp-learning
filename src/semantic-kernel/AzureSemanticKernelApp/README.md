# Azure Semantic Kernel Application

This project demonstrates how to utilize the Semantic Kernel with the Azure OpenAI service in a C# console application.

## Prerequisites

- .NET SDK (version 6.0 or later)
- An Azure account with access to the OpenAI service
- Your Azure OpenAI API key

## Setup Instructions

1. **Clone the Repository**
   Clone this repository to your local machine using the following command:
   ```
   git clone <repository-url>
   ```

2. **Navigate to the Project Directory**
   Change to the project directory:
   ```
   cd AzureSemanticKernelApp
   ```

3. **Restore Dependencies**
   Restore the project dependencies using the .NET CLI:
   ```
   dotnet restore
   ```

4. **Configure Your API Key**
   Open the `Program.cs` file and replace the placeholder API key with your Azure OpenAI API key.

5. **Build the Project**
   Build the project using the following command:
   ```
   dotnet build
   ```

6. **Run the Application**
   Execute the application with the following command:
   ```
   dotnet run
   ```

## Usage

The application will summarize the provided input text using the Azure OpenAI service. You can modify the input text in the `Program.cs` file to test different summaries.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.