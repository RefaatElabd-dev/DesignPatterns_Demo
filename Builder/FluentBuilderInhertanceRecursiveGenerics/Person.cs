
namespace Builder.FluentBuilderInhertanceRecursiveGenerics
{
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public class Builder : PersonJopBuilder<Builder>
        {
            internal Builder() { }
        }

        public static Builder New => new Builder();
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }
}
