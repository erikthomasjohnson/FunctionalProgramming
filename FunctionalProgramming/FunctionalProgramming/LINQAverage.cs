using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    class Functions
    {
        public Functions()
        {
        }
        public void GetAvg()
        {
            string grades = "1,8,3,2,14,33,26,91,2004";
            var numbers = grades.Split(',').Select(Int32.Parse).ToList();
            numbers.Sort();
            double result = (from x in numbers where x > numbers[2] select x).Average();
            Console.WriteLine(result);
        }
        public void GetNameSplit()
        {
            string name = "Llewellyn";
            name = string.Concat(name.ToLower().OrderBy(z => z));
            var letterCount = name.GroupBy(c => c).Select( collect => new { Char = collect.Key, Count = collect.Count() });
            foreach (var x in letterCount) { Console.Write("{0}{1},", x.Char, x.Count); }
        }
        public void GetTextFile()
        {
            int startDate = 161000;
            int endDate = 174700;
            using (StreamReader reader = new StreamReader("C:/Users/erikj/Documents/Visual Studio 2015/Projects/FunctionalProgramming/FunctionalProgramming/Sample.txt"))
            {
                string line;
                int trip = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Count() > 0)
                    {
                        string dateLine = line.Substring(line.IndexOf('[') + 13, 8);
                        string getNumbers = new String(dateLine.Where(Char.IsDigit).ToArray());
                        int numbers = int.Parse(getNumbers);
                        if (numbers >= startDate) { trip = 1; }
                        if (numbers > endDate) { trip = 0; }
                        if (trip == 1)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
