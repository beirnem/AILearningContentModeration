using System;

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

            Moderator mod = new Moderator();
            // Moderate text from text in a file
            mod.ModerateText(TextFile, TextOutputFile);
        }
    }
}
