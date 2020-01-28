using Microsoft.Azure.CognitiveServices.ContentModerator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContentModeration
{
    public class Moderator
    {
        /*
         * TEXT MODERATION
         * This example moderates text from file.
         */
        public void ModerateText(string inputFile, string outputFile)
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
