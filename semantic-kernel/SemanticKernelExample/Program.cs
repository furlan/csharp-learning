using System;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

class Program
{
    static async Task Main(string[] args)
    {
        // Create the kernel
        var kernel = Kernel.CreateBuilder()
            .AddOpenAIChatCompletion(
                modelId: "gpt-3.5-turbo", // or "gpt-4"
                apiKey: ""
            )
            .Build();

        // Define a semantic function with a prompt
        string prompt = @"
Summarize the following text in a concise paragraph:

{{$input}}

Summary:
";

        var summarizeFunction = kernel.CreateFunctionFromPrompt(prompt, functionName: "Summarize");

        // Input text to summarize
        string inputText = @"Microsoft Semantic Kernel is a lightweight SDK that lets you easily 
integrate AI services like OpenAI with conventional programming languages like C#. It helps you 
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
