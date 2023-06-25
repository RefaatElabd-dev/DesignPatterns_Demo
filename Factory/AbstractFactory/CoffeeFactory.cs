using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.AbstractFactory
{
    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount, int sugerAmount, bool withMilk)
        {
            Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }
}
