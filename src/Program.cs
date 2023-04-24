
using AwesomeApplication.BL;
using Azure;

IAwesome awesome = new Awesome();

const string sourceText = "This is a test.";
const string targetLanguage = "es";

try
{
    Console.WriteLine($"Translating '{sourceText}' to: {targetLanguage}.");
    var translatedText = await awesome.TranslateAsync(sourceText, targetLanguage).ConfigureAwait(false);
    Console.WriteLine($"Result: '{translatedText}'");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
