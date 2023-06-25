using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.AbstractFactory
{
    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount, int sugerAmount, bool withMilk)
        {
            var addMilk = withMilk ? "" : "don't";
            Console.WriteLine($"Put in tea bag, boil water, pour {amount}, with {sugerAmount} of suger cupes, {addMilk} add Milk, add lemon, enjoy!");
            return new Tea();
        }
    }
}
