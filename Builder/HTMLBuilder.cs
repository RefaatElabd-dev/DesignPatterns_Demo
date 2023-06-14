using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class HTMLBuilder
    {
        private readonly string rootName;
        HTMLElement root = new HTMLElement();
        public HTMLBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public void AddChild(string name, string text)
        {
            HTMLElement child = new HTMLElement(name, text);
            root.Elements.Add(child);
        }

        public HTMLBuilder AddFluentChild(string name, string text)
        {
            HTMLElement child = new HTMLElement(name, text);
            root.Elements.Add(child);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HTMLElement { Name = rootName };
        }
    }

}
