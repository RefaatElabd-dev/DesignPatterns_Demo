using System.Text;

namespace Visitor
{
    public interface IVisitorExprission
    {
        void Visit(DoubleExpression expr);
        void Visit(AdditionExpression expr);
    }

    public interface ITransformer<T>
    {
        T Transform(DoubleExpression de);
        T Transform(AdditionExpression ae);
    }

    public class SquareTransformer : ITransformer<Expression>
    {
        public Expression Transform(DoubleExpression expr)
        {
            return new DoubleExpression(expr.Value * expr.Value);
        }

        public Expression Transform(AdditionExpression expr)
        {
            return new AdditionExpression(expr.Left.Reduce(this), expr.Right.Reduce(this));
        }
    }

    public class PrintTransformer : ITransformer<string>
    {
        public string Transform(DoubleExpression de)
        {
            return de.Value.ToString();
        }

        public string Transform(AdditionExpression ae)
        {
            return $"({ae.Left.Reduce(this)} + {ae.Right.Reduce(this)})";
        }
    }
    public class PrinterVisitor : IVisitorExprission
    {
        private StringBuilder _sb = new StringBuilder();
        public void Visit(DoubleExpression expr)
        {
           _sb.Append(expr.Value);
        }

        public void Visit(AdditionExpression expr)
        {
            _sb.Append("(");
            expr.Left.Accept(this);
            _sb.Append("+");
            expr.Right.Accept(this);
            _sb.Append(")");
        }

        public override string ToString()
        {
            return _sb.ToString(); 
        }
    }

    public class CalculatorVisitor : IVisitorExprission
    {
        public double Result;
        public void Visit(DoubleExpression expr)
        {
            Result += expr.Value;
        }

        public void Visit(AdditionExpression expr)
        {
            expr.Left.Accept(this);
            expr.Right.Accept(this);
        }

        public override string ToString()
        {
            return Result.ToString();
        }
    }
}
