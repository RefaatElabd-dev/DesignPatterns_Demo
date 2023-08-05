using System.Text;

namespace Visitor
{
    public abstract class Expression
    {
        // adding a new operation
        public abstract void Print(StringBuilder sb);
        public abstract void Accept(IVisitorExprission visitorExprission);
        public abstract T Reduce<T>(ITransformer<T> transformer);
    }

    public class DoubleExpression : Expression
    {
        private double value;

        public DoubleExpression(double value)
        {
            this.Value = value;
        }

        public double Value { get => value; set => this.value = value; }

        public override void Accept(IVisitorExprission visitorExprission)
        {
            visitorExprission.Visit(this);
        }

        public override void Print(StringBuilder sb)
        {
            sb.Append(Value);
        }

        public override T Reduce<T>(ITransformer<T> transformer)
        {
            return transformer.Transform(this);
        }
    }

    public class AdditionExpression : Expression
    {
        private Expression left, right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.Left = left ?? throw new ArgumentNullException(paramName: nameof(left));
            this.Right = right ?? throw new ArgumentNullException(paramName: nameof(right));
        }

        public Expression Left { get => left; set => left = value; }
        public Expression Right { get => right; set => right = value; }

        public override void Accept(IVisitorExprission visitorExprission)
        {
            visitorExprission.Visit(this);
        }

        public override void Print(StringBuilder sb)
        {
            sb.Append(value: "(");
            Left.Print(sb);
            sb.Append(value: "+");
            Right.Print(sb);
            sb.Append(value: ")");
        }

        public override T Reduce<T>(ITransformer<T> transformer)
        {
            return transformer.Transform(this);
        }
    }
}
