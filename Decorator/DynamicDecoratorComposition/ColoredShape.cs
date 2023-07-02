using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DynamicDecoratorComposition
{
    public class ColoredShape : IShape
    {
        IShape _shape;
        string color;
        public ColoredShape(IShape shape, string color)
        {
            _shape = shape;
            this.color = color;
        }

        public string AsString() => $"{_shape.AsString()} with Color {color}";
    }
}
