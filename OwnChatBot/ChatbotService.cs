using System;
using System.Collections.Generic;
using System.Linq;

public class ChatbotService
{
    private Dictionary<string, List<string>> knowledgeBase;

    public ChatbotService()
    {
        // Initialize knowledge base with some predefined responses
        knowledgeBase = new Dictionary<string, List<string>>()
        {
            { "greeting", new List<string> { "Hello!", "Hi there!", "Hey!" } },
            { "farewell", new List<string> { "Goodbye!", "See you later!", "Bye!" } },
            // Add more categories and responses as needed
        };
    }

    public string Respond(string input)
    {
        // Preprocess input (e.g., convert to lowercase, remove punctuation)
        input = input.ToLower().Trim();

        // Determine the category of the input
        string category = ClassifyInput(input);

        // Generate response based on the category
        string response = GenerateResponse(category);

        return response;
    }

    private string ClassifyInput(string input)
    {
        // Perform simple classification based on keywords or patterns
        if (input.Contains("hello") || input.Contains("hi"))
        {
            return "greeting";
        }
        else if (input.Contains("bye"))
        {
            return "farewell";
        }
        // Add more classification rules as needed
        else
        {
            return "default";
        }
    }

    private string GenerateResponse(string category)
    {
        // Retrieve a random response from the knowledge base for the given category
        if (knowledgeBase.ContainsKey(category))
        {
            var responses = knowledgeBase[category];
            var random = new Random();
            int index = random.Next(responses.Count);
            return responses[index];
        }
        else
        {
            return "I'm not sure what you mean.";
        }
    }
}
