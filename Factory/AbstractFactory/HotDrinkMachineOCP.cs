using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Factory.AbstractFactory
{
    public class HotDrinkMachineOCP
    {
        private List<(string Name, IHotDrinkFactory Factory)> factories = new List<(string Name, IHotDrinkFactory Factory)>();

        public HotDrinkMachineOCP()
        {
            foreach (var t in typeof(HotDrinkMachineOCP).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(item: new
                        (t.Name.Replace("Factory", String.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t))
                        );
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            for (int index = 0; index < factories.Count; index++)
            {
                Console.WriteLine($"{index}: {factories[index].Name}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i) // c# 7
                    && i >= 0
                    && i < factories.Count)
                {
                    Console.Write("Specify amount: ");
                    s = Console.ReadLine();
                    if (s != null
                        && int.TryParse(s, out int amount)
                        && amount > 0)
                    {
                        return factories[i].Factory.Prepare(amount, 2, false);
                    }
                }
            }
        }
    }
}
