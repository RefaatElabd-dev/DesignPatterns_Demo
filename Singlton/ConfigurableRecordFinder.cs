using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singlton
{
    public class ConfigurableRecordFinder
    {
        private IDB database;

        public ConfigurableRecordFinder(IDB database)
        {
            this.database = database;
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
                result += database.GetPopulation(name);
            return result;
        }
    }
}
