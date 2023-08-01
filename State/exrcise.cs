using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class CombinationLock
    {

        public CombinationLock(int[] combination)
        {
            this.Combination = combination;
            Status = "LOCKED";
        }

        // you need to be changing this on user input
        public string Status;
        public string CachedStatus = "";
        readonly int[] Combination;
        public void EnterDigit(int digit)
        {
            Console.WriteLine($"User has entered {digit}");
            CachedStatus += digit.ToString();

            if (CachedStatus == String.Join("", Combination))
            {
                Status = "OPEN";
            }
            else if(String.Join("", Combination).StartsWith(CachedStatus))
            {
                Status = CachedStatus;
            }
            else
            {
                Status = "ERROR";
            }
        }
    }
}
