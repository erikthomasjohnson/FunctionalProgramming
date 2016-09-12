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
            int startDate = 151000;
            int endDate = 184700;
            using (StreamReader reader = new StreamReader("C:/Users/erikj/Documents/GitHub/FunctionalProgramming/FunctionalProgramming/FunctionalProgramming/Sample.txt"))
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
        public void OrderLogFile(int startDate = 165000, int endDate = 173000)
        {
            using (StreamReader reader = new StreamReader("C:/Users/erikj/Documents/GitHub/FunctionalProgramming/FunctionalProgramming/FunctionalProgramming/Sample.txt"))
            {
                List<int> numberLine = new List<int>();
                List<string> disorderedLine = new List<string>();
                List<string> orderedLine = new List<string>();
                int next = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Count() > 0)
                    {
                        disorderedLine.Add(line);
                        numberLine.Add(GetNumbers(line));
                    }
                }
                numberLine.Sort();
                while (next < numberLine.Count)
                {
                    foreach (string newLine in disorderedLine)
                    {
                        if (GetNumbers(newLine) == numberLine[next])
                        {
                            orderedLine.Add(newLine);
                            next++;
                        }
                    }
                }
                for (int i = 0; i < orderedLine.Count - 1; i++) { if (orderedLine[i] == orderedLine[i + 1]) { orderedLine.RemoveAt(i + 1); } }
                int trip = 0;
                foreach (string requestLine in orderedLine)
                {
                    if (GetNumbers(requestLine) >= startDate) { trip = 1; }
                    if (GetNumbers(requestLine) > endDate) { trip = 0; }
                    if (trip == 1)
                    {
                        Console.WriteLine(requestLine);
                    }
                }
            }
        }
        public int GetNumbers(string line)
        {
            string dateLine = line.Substring(line.IndexOf('[') + 13, 8);
            string getNumbers = new String(dateLine.Where(Char.IsDigit).ToArray());
            int numbers = int.Parse(getNumbers);
            return numbers;
        }
    }
}
