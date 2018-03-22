using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSum
{
    class Program
    {
        public static List<int> IntMass { get; set; }
        public static int ResultNumber { get; set; }
        static void Main(string[] args)
        {
            IntMass = new List<int>();
            while (IntMass.Count == 0)
            {
                Console.WriteLine("Введите массив чисел через запятую и нажмите 'Enter':");
                if(TryParse()) break;
            }
            Console.WriteLine("Введите целое число и нажмите 'Enter':");
            int x = 0;
            bool result;
            do
            {
                result = int.TryParse(Console.ReadLine(), out x);
                if (!result)
                    Console.WriteLine("Вы неверно ввели число, попробуйте еще раз");
            } while (!result);
            ResultNumber = x;
            Console.WriteLine(SearchForCombinations());
            Console.ReadLine();
        }

        static string SearchForCombinations()
        {
            var result = new List<string>();
            var numbers = IntMass.ToList();
            for (var i = 0; i < IntMass.Count; i++)
            {
                var secondNum = ResultNumber - IntMass[i];
                var idx = numbers.FindIndex(x => x == secondNum);
                var firstIdx = numbers.FindIndex(x => x == IntMass[i]);
                if (idx <= -1) continue;
                result.Add($"({IntMass[i]}, {secondNum})");
                numbers.RemoveAt(firstIdx);
                numbers.RemoveAt(idx);
            }
            if (result.Count == 0)
                return "Ничего не найдено";
            return string.Join(",", result);
        }

        static bool TryParse()
        {
            try
            {
                var inputMass = Console.ReadLine();
                if (string.IsNullOrEmpty(inputMass)) return false;
                IntMass = inputMass.Split(',').Select(int.Parse).ToList();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Вы неверно ввели массив, попробуйте еще раз");
                return false;
                throw;
            }
        }
    }
}
