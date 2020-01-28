using Microsoft.Azure.CognitiveServices.ContentModerator;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace ContentModeration
{
    class Program
    {

        // TEXT MODERATION
        // Name of the file that contains text
        private static readonly string TextFile = @"..\..\..\TextFile.txt";
        // The name of the file to contain the output from the evaluation.
        private static string TextOutputFile = @"..\..\..\TextModerationOutput.txt";

        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("CONTENT_MODERATOR_ENDPOINT", "https://aicertcontentmoderatortutorial.cognitiveservices.azure.com/");
            Environment.SetEnvironmentVariable("CONTENT_MODERATOR_SUBSCRIPTION_KEY", "2e84cf22ed5e42d99689ea32b33c5ec8");
            // Moderate text from text in a file
            ModerateText(TextFile, TextOutputFile);
        }

        /*
         * TEXT MODERATION
         * This example moderates text from file.
         */
        public static void ModerateText(string inputFile, string outputFile)
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("TEXT MODERATION");
            Console.WriteLine();
            // Load the input text
            string text = File.ReadAllText(inputFile);

            // Remove carriage returns
            text = text.Replace(Environment.NewLine, " ");
            // Convert string to a byte[], then into a stream (for parameter in ScreenText()).
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            MemoryStream stream = new MemoryStream(textBytes);

            Console.WriteLine("Screening {0}...", inputFile);
            // Format text

            // Save the moderation result to a file.
            using (StreamWriter outputWriter = new StreamWriter(outputFile, false))
            {
                using (var client = Clients.NewClient())
                {
                    // Screen the input text: check for profanity, classify the text into three categories,
                    // do autocorrect text, and check for personally identifying information (PII)
                    outputWriter.WriteLine("Autocorrect typos, check for matching terms, PII, and classify.");

                    // Moderate the text
                    var screenResult = client.TextModeration.ScreenText("text/plain", stream, "eng", true, true, null, true);
                    outputWriter.WriteLine(JsonConvert.SerializeObject(screenResult, Formatting.Indented));
                }

                outputWriter.Flush();
                outputWriter.Close();
            }

            Console.WriteLine($"Results written to {outputFile}");
            Console.WriteLine();
        }
    }
}
