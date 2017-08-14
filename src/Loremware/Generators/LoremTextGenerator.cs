using System;
using System.Text;

namespace Loremware.Generators
{
    public static class LoremTextGenerator
    {
        public static string GenerateLoremIpsumText(int minWords = 15, 
                                                    int maxWords = 30, 
                                                    int minSentences = 5, 
                                                    int maxSentences = 10, 
                                                    int numParagraphs = 3)
        {
            var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                              "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                              "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            var result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                result.Append("<p>");
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
                result.Append("</p>");
            }

            return result.ToString();
        }
    }
}
