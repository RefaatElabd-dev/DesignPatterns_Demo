namespace Decorator.DynamicDecoratorComposition
{
    public class Square: IShape
    {
        float side;

        public Square(float side)
        {
            this.side = side;
        }

        public string AsString() => $"A Square with Side {side}";
    }
}
