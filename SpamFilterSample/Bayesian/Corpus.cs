using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Expat.Bayesian
{
	/// <summary>
	/// This is  a list of words found in a bunch of text, 
    /// along with counts of how often those words appear
	/// </summary>
	public class Corpus
	{
		/// <summary>
		/// Regex pattern for words that don't start with a number
		/// </summary>
		public const string TokenPattern = @"([a-zA-Zà-ÿÀ-ß]\w+)\W*";

		private SortedDictionary<string, int> _tokens = new SortedDictionary<string, int>();


		/// <summary>
		/// A sorted list of all the words that show up in the text, 
        /// along with counts of how many times they appear.
		/// </summary>
		public SortedDictionary<string, int> Tokens
		{
			get { return _tokens; }
		}

		public Corpus()
		{
		}

		/// <summary>
		/// Fire up a new Corpus and populate it with text from the supplied reader
		/// </summary>
		
		public Corpus(TextReader reader)
		{
			LoadFromReader(reader);
		}

		/// <summary>
		/// Fire up a new Corpus and populate it with the contents of the supplied file
		/// </summary>
		
		public Corpus(string filepath)
		{
			LoadFromFile(filepath);
		}

		/// <summary>
		/// Populate the Corpus with text from a file.
		/// </summary>
		
		public void LoadFromFile(string filepath)
		{
			LoadFromReader(new StreamReader(filepath));
		}

		/// <summary>
		/// Loads tokens from the specified TextReader into the Corpus.
		/// Doesn't initialize the collection, so it can be called from
		/// a loop if needed.
		/// </summary>
		
		public void LoadFromReader(TextReader reader)
		{
			Regex re = new Regex(TokenPattern, RegexOptions.Compiled);
			string line;
			while (null != (line = reader.ReadLine()))
			{
				Match m = re.Match(line);
				while (m.Success)
				{
					string token = m.Groups[1].Value;
					AddToken(token);
					m = m.NextMatch();
				}
			}
		}

		/// <summary>
		/// Stick a word into the list, incrementing its count if it's already there.
		/// </summary>
		
		public void AddToken(string rawPhrase)
		{
			if (!_tokens.ContainsKey(rawPhrase)) {
				_tokens.Add(rawPhrase, 1);

			} else {
				_tokens[rawPhrase]++;
			}
		}

	}

}
