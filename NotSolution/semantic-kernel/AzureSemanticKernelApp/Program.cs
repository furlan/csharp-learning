using System;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

class Program
{
    static async Task Main(string[] args)
    {
        // Retrieve API key and endpoint from environment variables
        string apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");
        string endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
        string deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME");

        if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(deploymentName))
        {
            Console.WriteLine("Please set the AZURE_OPENAI_API_KEY and AUZURE_OPENAI_ENDPOINT environment variables.");
            return;
        }

        //Create the kernel
        var kernel = Kernel.CreateBuilder()
            .AddAzureOpenAIChatCompletion(
                modelId: "gpt-4o",
                deploymentName: deploymentName,
                apiKey: apiKey,
                endpoint: endpoint
            )
            .Build();

        // Define a semantic function with a prompt
        string prompt = @"
Summarize the following text in a concise paragragh:

{{$input}}

Summary:
";

        var summarizeFunction = kernel.CreateFunctionFromPrompt(prompt, functionName: "Summarize");

        //Input text to summarize
        string inputText = @"Microsoft Semantic Kernel is a lightweight SDK that lets you easily 
integrate AI services like Azure OpenAI with conventional programming languages like C#. It helps you 
build intelligent apps faster using semantic functions and planners.";

        // Run the function
        var result = await kernel.InvokeAsync(summarizeFunction, new KernelArguments
        {
            ["input"] = inputText
        });

        Console.WriteLine("Summary:");
        Console.WriteLine(result.GetValue<string>());
    }
}