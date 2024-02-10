namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = new char[] { '+', '-' };

            char advancedChar = '0';

            while (true)
            {
                Console.WriteLine("Введите строку или введите exit");
                string? str = Console.ReadLine();
                if (String.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Вы ввели пустую строку");
                    Console.WriteLine();
                    continue;
                }
                if (str == "exit")
                {
                    break;
                }
                int countSymbol = CountSymbols(str, chars);
                Console.WriteLine($"Колличество символов {new String(chars)} в строке равно {countSymbol.ToString()} ");
                countSymbol = CountSymbols(str, chars, advancedChar, IsFollowedSymbol);
                Console.WriteLine($"Колличество символов {new String(chars)} в строке после которых есть символ {advancedChar} равно {countSymbol.ToString()} ");
                
            }
        }

        static int CountSymbols(string input, char[] symbols, char advSymbol, Func<string,int,char,bool> condition)
        {
            int count = 0;
            for (int i = 0; i<input.Length; i++)
            {
                if (Array.Exists(symbols, symbol => symbol == input[i]) && condition(input,i,advSymbol))
                    count++;
            }
            return count;
        }

        static int CountSymbols(string input, char[] symbols)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Array.Exists(symbols, symbol => symbol == input[i]))
                    count++;
            }
            return count;
        }

        static bool IsFollowedSymbol(string str, int index, char advChar) 
        {
            string res = str.Substring(index);
            foreach (char c in res)
            {
                if (c==advChar) return true;
            }
            return false;
        }
    }
}
