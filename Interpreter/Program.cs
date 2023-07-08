using Interpreter;
using InterPreter.Exercise;

//var input = "(13+4)-(12+1)";
//var tokens = StaticMethods.Lex(input);
//Console.WriteLine(string.Join("\t", tokens));

//var parsed = StaticMethods.Parse(tokens);
//Console.WriteLine($"{input} = {parsed.Value}");

Console.WriteLine(new ExpressionProcessor().Calculate("1+2+3"));