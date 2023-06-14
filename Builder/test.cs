using System.Text;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public class Field
    {
        public string Name, DataType;

        public Field(string name, string dataType)
        {
            Name = name;
            DataType = dataType;
        }

        public override string ToString()
        {
            return $"  public {DataType} {Name};";
        }
    }

    public class ClassElement
    {
        public string Name;
        private const int indentSize = 2;
        public List<Field> Fields = new List<Field>();
        public ClassElement() { }
        public ClassElement(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {Name}");
            sb.AppendLine("{");
            foreach (var f in Fields)
                sb.AppendLine(f.ToString());

            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    public class CodeBuilder
    {
        public ClassElement classElement = new ClassElement();
        public CodeBuilder(string className)
        {
            classElement.Name = className;
        }

        public CodeBuilder AddField(string name, string dataType)
        {
            Field f = new Field(name, dataType);
            classElement.Fields.Add(f);
            return this;
        }

        public override string ToString()
        {
            return classElement.ToString();
        }
    }
}
