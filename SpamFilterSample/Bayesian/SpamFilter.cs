using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Expat.Bayesian
{

    /*
     * Naive Baysian Spam Filter. 
     * @author Arkhipov A. 
                                   */
     

    public class SpamFilter
    {
        #region knobs for dialing in performance
        /// <summary>
        /// These are constants used in the Bayesian algorithm
        /// </summary>
        public class KnobList
        {

            public int GoodTokenWeight = 2;
            public int MinCountForInclusion = 5;
            public double MinScore = 0.011;
            public double MaxScore = 0.99;
            public double LikelySpamScore = 0.9998;
            public double CertainSpamScore = 0.9999;
            public int CertainSpamCount = 10;
            public int InterestingWordCount = 15;
        }

        private KnobList _knobs = new KnobList();

        public KnobList Knobs
        {
            get { return _knobs; }
            set { _knobs = value; }
        }

        #endregion

        private Corpus _good;
        private Corpus _bad;
        private SortedDictionary<string, double> _prob;
        private int _ngood;
        private int _nbad;

        #region properties

        //  Spam text
        public Corpus Bad
        {
            get { return _bad; }
            set { _bad = value; }
        }
  
        // Not-spam text
        public Corpus Good
        {
            get { return _good; }
            set { _good = value; }
        }

        /// <summary>
        ///  Probabilities that the given word might appear in a Spam text
        /// </summary>
        public SortedDictionary<string, double> Prob
        {
            get { return _prob; }
            set { _prob = value; }
        }
        #endregion

        #region population

        /// <summary>
        /// Initialize the SpamFilter based on the supplied text
        /// </summary>
     
        public void Load(TextReader goodReader, TextReader badReader)
        {
            _good = new Corpus(goodReader);
            _bad = new Corpus(badReader);

            CalculateProbabilities();
        }

        /// <summary>
        /// Initialize the SpamFilter based on the contents of the supplied Corpuseses
        /// </summary>
        
        public void Load(Corpus good, Corpus bad)
        {
            _good = good;
            _bad = bad;

            CalculateProbabilities();
        }

        public void Load(DataTable table)
        {
            _good = new Corpus();
            _bad = new Corpus();

            foreach (DataRow row in table.Rows)
            {
                bool isSpam = (bool)row["IsSpam"];
                string body = row["Body"].ToString();
                if (isSpam) {
                    _bad.LoadFromReader(new StringReader(body));
                }
                else {
                    _good.LoadFromReader(new StringReader(body));
                }
            }

            CalculateProbabilities();
        }

        /// <summary>
        /// Populating the probabilities collection
        /// </summary>
        private void CalculateProbabilities()
        {
            _prob = new SortedDictionary<string, double>();

            _ngood = _good.Tokens.Count;
            _nbad = _bad.Tokens.Count;
            foreach (string token in _good.Tokens.Keys) {
                CalculateTokenProbability(token);
            }
            foreach (string token in _bad.Tokens.Keys) {
                if (!_prob.ContainsKey(token)) {
                    CalculateTokenProbability(token);
                }
            }
        }

        
        private void CalculateTokenProbability(string token)
        {
            
            int g = _good.Tokens.ContainsKey(token) ? _good.Tokens[token] * Knobs.GoodTokenWeight : 0;
            int b = _bad.Tokens.ContainsKey(token) ? _bad.Tokens[token] : 0;

            if (g + b >= Knobs.MinCountForInclusion) {
                double goodfactor = Min(1, (double)g / (double)_ngood);
                double badfactor = Min(1, (double)b / (double)_nbad);

                double prob = Max(Knobs.MinScore,
                                Min(Knobs.MaxScore, badfactor / (goodfactor + badfactor)) );

                // special case for Spam-only tokens.
                // 0.9998 for tokens only found in spam, or 0.9999 if found more than 10 times
                if (g == 0) {
                    prob = (b > Knobs.CertainSpamCount) ? Knobs.CertainSpamScore : Knobs.LikelySpamScore;
                }

                _prob[token] = prob;
            }
        }
        #endregion

        #region serialization
        
        public void ToFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                StreamWriter writer = new StreamWriter(fs);

                writer.WriteLine(String.Format("{0},{1},{2}", _ngood, _nbad, _prob.Count));
                foreach (string key in _prob.Keys)
                {
                    writer.WriteLine(String.Format("{0},{1}", _prob[key].ToString("#.###"), key));
                }

                writer.Flush();
                fs.Close();
            }
        }

        /// <summary>
        /// Populate from a file created with ToFile().
        /// </summary>
        
        //public void FromFile(string filePath)
        //{
        //    _prob = new SortedDictionary<string, double>();
        //    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        //    {
        //        StreamReader reader = new StreamReader(fs);

        //        ParseCounts(reader.ReadLine());

        //        while (!reader.EndOfStream) {
        //            ParseProb(reader.ReadLine());
        //        }

        //        fs.Close();
        //    }
        //}

        private void ParseCounts(string line)
        {
            string[] tokens = line.Split(',');
            if (tokens.Length >= 1)
            {
                _ngood = Convert.ToInt32(tokens[0]);
                _nbad = Convert.ToInt32(tokens[1]);
            }
        }

        private void ParseProb(string str)
        {
            string[] tokens = str.Split(',');
            //if (tokens.Length > 1)
            //{
            //    //_prob.Add(tokens[1], Convert.ToDouble(tokens[0]));
            //    _prob.Add(tokens[1], Double.Parse(tokens[0]));
            //    //_prob.Add(tokens[1],Convert.ToInt32(tokens[0]));

            //}
        }

        #endregion

        #region spam testing
        /// <summary>
        /// Returns the probability that the supplied body of text is spam
        /// </summary>

        public double Test(string body)
        {
            SortedList probs = new SortedList();

            // Spin through every word in the body and look up its individual spam probability.
            // Keep the list in decending order of "Interestingness"
            Regex re = new Regex(Corpus.TokenPattern, RegexOptions.Compiled);
            Match m = re.Match(body);
            int index = 0;
            while (m.Success) {
                string token = m.Groups[1].Value;
                if (_prob.ContainsKey(token))  {
                    // "interestingness" == how far our score is from 50%.  
                    
                    double prob = _prob[token];
                    string key = (0.5 - Math.Abs(0.5 - prob)).ToString(".000") + token + index++;
                    probs.Add(key, prob);
                }

                m = m.NextMatch();
            }

            double mult = 1;  
            double comb = 1;  
            index = 0;
            foreach (string key in probs.Keys)
            {
                double prob = (double)probs[key];
                mult = mult * prob;
                comb = comb * (1 - prob);

                Debug.WriteLine(index + " " + probs[key] + " " + key);

                if (++index > Knobs.InterestingWordCount)  break;
            }
            return mult / (mult + comb);
        }
        #endregion

        #region  calculations help

        private double Max(double x, double y) { return x > y ? x : y; }
        private double Min(double x, double y) { return x < y ? x : y; }

        #endregion

        public int index { get; set; }
    }
}
