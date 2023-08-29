using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class Memento
    {
        public Token Token = null;
        public Memento(int value)
        {
            this.Token = new Token(value);
        }

        public Memento(Token token)
        {
            this.Token = token;
        }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            var addedToken = new Token(value);
            this.Tokens.Add(addedToken);
            return new Memento(addedToken);
        }

        public Memento AddToken(Token token)
        {
            var addedToken = new Token(token.Value);
            this.Tokens.Add(addedToken);
            return new Memento(addedToken);
        }

        public void Revert(Memento m)
        {
            for (int i = this.Tokens.Count - 1; i >= 0; i--)
            {
                if (m.Token.Equals(this.Tokens[i])) break;

                this.Tokens.Remove(this.Tokens[i]);
            }
        }
    }
}
