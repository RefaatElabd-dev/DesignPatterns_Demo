using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.AbstractFactory
{
    public class HotDrinkMachine
    {
        public enum AvailableDrinks
        {
            Tea, Coffee
        }

        private const string assymblName = "Factory.AbstractFactory.";
        private Dictionary<AvailableDrinks, IHotDrinkFactory> factories 
            = new Dictionary<AvailableDrinks, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrinks drink in Enum.GetValues(typeof(AvailableDrinks)))
            {
                IHotDrinkFactory factory = (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType(typeName: assymblName + Enum.GetName(typeof(AvailableDrinks), value: drink) + "Factory"));
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeADrink(AvailableDrinks drink, int amount, int sugerAmount, bool withMilk)
        {
            return factories[drink].Prepare(amount, sugerAmount, withMilk);
        }
    }
}
