using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectBlock9
{
    public class NonTargetGroups
    {
        public void RegularExample()
        {
            string pattern = @"(?:\+\d{1,3})?\s?\d{10}";
            string input = "+7 12345678903452";


            Match match = Regex.Match(input, pattern);

            Console.WriteLine(match.Value);

        }
    }
}
