using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.FunctionalBuilder
{
    public static class PersonBuilderExtensions
    {
       public static PersonBuilder WorkAsA(this PersonBuilder personBuilder, string position)
        {
            personBuilder.Do((p) => { p.Position = position; return p; });
            return personBuilder;
        }
    }
}
