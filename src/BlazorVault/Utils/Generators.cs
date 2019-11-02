using System;
using System.Text;

namespace BlazorVault.Utils
{
	internal static class Generators
	{
		internal static string LoremIpsum(
			int minWords, 
			int maxWords,
			int minSentences, 
			int maxSentences,
			int numParagraphs)
		{

			var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
		"adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
		"tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

			var rand = new Random();
			int numSentences = rand.Next(maxSentences - minSentences)
				+ minSentences + 1;
			int numWords = rand.Next(maxWords - minWords) + minWords + 1;

			StringBuilder result = new StringBuilder();

			for (int p = 0; p < numParagraphs; p++)
			{
				for (int s = 0; s < numSentences; s++)
				{
					for (int w = 0; w < numWords; w++)
					{
						if (w > 0) { result.Append(" "); }
						result.Append(words[rand.Next(words.Length)]);
					}
					result.Append(". ");
				}
			}

			return result.ToString();
		}
	}
}
