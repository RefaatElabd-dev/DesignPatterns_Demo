using System.Text;
using static System.Console;
using Visitor;
using static System.Net.Mime.MediaTypeNames;

//var e = new AdditionExpression(
//              left: new DoubleExpression(1),
//              right: new AdditionExpression(
//                left: new DoubleExpression(2),
//                right: new DoubleExpression(3)));
//var sb = new StringBuilder();
//e.Print(sb);
//WriteLine(sb);


var e = new AdditionExpression(
        left: new DoubleExpression(1),
        right: new AdditionExpression(
          left: new DoubleExpression(2),
          right: new DoubleExpression(3)));
//var sb = new StringBuilder();
//ExpressionPrinter.Print2(e, sb);
//WriteLine(sb);

var pv = new PrinterVisitor();

e.Accept(pv);

WriteLine(pv);

var cv = new CalculatorVisitor();

e.Accept(cv);

WriteLine(pv + " = " + cv);


var st = new SquareTransformer();
var newExpr = e.Reduce(st);
var pt = new PrintTransformer();
var text = newExpr.Reduce(pt);
WriteLine(text);