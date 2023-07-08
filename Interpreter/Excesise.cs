using System;
using System.Text;
using System.Collections.Generic;

namespace InterPreter.Exercise
{
    public interface IElement
    {
        int Value { get; }
    }

    public class Integer : IElement
    {
        public int Value { get; }
        public Integer(int value)
        {
            Value = value;
        }
    }

    public class Expre4on : IElement
    {
        public int Value
        {
            get
            {
                switch (myType)
                {
                    case Type.Addition:
                        return L + R;
                    case Type.Subtraction:
                        return L - R;
                    default:
                        throw new Exception("Wrong Type");
                }
            }
        }

        public int L, R;
        public Type myType;

        public enum Type
        {
            Addition,
            Subtraction
        }
    }

    public class Token
    {
        public enum Type
        {
            Plus, Minus, Integer, Variables
        }

        public string Text { set; get; }
        public Type MyType { set; get; }

        public Token(Type type, string text)
        {
            MyType = type;
            Text = text;
        }
    }

    public class Operation
    {
        public static List<Token> Lex(string methodString, Dictionary<char, int> variables)
        {
            var result = new List<Token>();

            for (int i = 0; i < methodString.Length; i++)
            {
                char digit = methodString[i];
                switch (digit)
                {
                    case '-':
                        result.Add(new Token(Token.Type.Minus, "-"));
                        break;
                    case '+':
                        result.Add(new Token(Token.Type.Plus, "+"));
                        break;
                    default:
                        if (char.IsDigit(digit))
                        {
                            var sb = new StringBuilder(methodString[i].ToString());
                            for (int j = i + 1; j < methodString.Length; j++)
                            {
                                if (char.IsDigit(methodString[j]))
                                {
                                    sb.Append(methodString[j]);
                                    i++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            result.Add(new Token(Token.Type.Integer, sb.ToString()));
                        }
                        else
                        {
                            if (variables.ContainsKey(digit))
                            {
                                result.Add(new Token(Token.Type.Integer, variables[digit].ToString()));
                            }
                            else
                            {
                                throw new Exception("Not exist");
                            }
                        }
                        break;
                }
            }
            return result;
        }


        public static int Parse(List<Token> tokens)
        {
            var expr4n = new Expre4on();
            bool haveLHS = false;

            foreach (var token in tokens)
            {
                switch (token.MyType)
                {
                    case Token.Type.Integer:
                        var integer = new Integer(int.Parse(token.Text));
                        if (!haveLHS)
                        {
                            expr4n.L = integer.Value;
                            haveLHS = true;
                        }
                        else
                        {
                            expr4n.R = integer.Value;
                            expr4n.L = expr4n.Value;
                            expr4n.R = 0;
                        }
                        break;
                    case Token.Type.Plus:
                        expr4n.myType = Expre4on.Type.Addition;
                        break;
                    case Token.Type.Minus:
                        expr4n.myType = Expre4on.Type.Subtraction;
                        break;
                    default:
                        throw new Exception("Wrong value");
                }
            }
            return expr4n.Value;
        }
    }

    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            try
            {
                return Operation.Parse(Operation.Lex(expression, Variables));
            }
            catch
            {
                return 0;
            }
        }
    }
}
