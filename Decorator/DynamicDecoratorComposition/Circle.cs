namespace Decorator.DynamicDecoratorComposition
{
    public class Circle : IShape
    {
        float radius;

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public string AsString() => $"A circle with radius {radius}";
    }
}
