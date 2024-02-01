using Pets.Challenge1;
using Pets.Challenge2;
using System.Globalization;

namespace Pets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            
            // Solution1 solution1 = new Solution1();
            
            // if (!solution1.DisplayMenu())
            //     return;

            Solution2 solution2 = new Solution2();
            
            if (!solution2.DisplayMenu())
                return;
        }
    }
}