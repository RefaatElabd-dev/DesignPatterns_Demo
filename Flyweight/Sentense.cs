using System;
using System.Text;

namespace Flyweight
{
    public class Sentence
    {
        private string PlainText;
        private Dictionary<int, WordToken> tokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            this.PlainText = plainText;
        }

        public WordToken this[int index]
        {
            get
            {
                if(!this.tokens.ContainsKey(index))
                    tokens.Add(index, new WordToken());
                return this.tokens[index];
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var words = this.PlainText.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (i > 0)
                {
                    sb.Append(' ');
                }
                if (this.tokens.ContainsKey(i) && this.tokens[i].Capitalize)
                {
                    sb.Append(words[i].ToUpper());
                }
                else
                {
                    sb.Append(words[i]);
                }
            }
            return sb.ToString();
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}
