using System.Text;
using System.Text.RegularExpressions;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                str = RegexHide(str);
                Console.WriteLine("Результат с использованием регулярных выражений: ");
                Console.WriteLine(str);
                Console.WriteLine();
                Console.WriteLine("Результат без использования регулярных выражений: ");
                str = StringBuilderHide(str);
                Console.WriteLine(str);
            }        
        }

        static string RegexHide (string str) 
        {
            string patternForLink = @"https?://\S+|www\.\S+";
            string patternForEmail = @"\S+@\S+";

            str = Regex.Replace(str, patternForLink,m=>new string('*',m.Length));
            str = Regex.Replace(str, patternForEmail,m=>new string('*',m.Length));
            return str;
        }

        static string StringBuilderHide(string str)
        {
            StringBuilder result = new StringBuilder();

            string[] words = str.Split(' ');

            foreach (string word in words)
            {
                string hiddenWord = word;
                if (IsLink(word) || IsEmail(word))
                {
                    hiddenWord = new string('*', word.Length);
                }
                result.Append(hiddenWord).Append(" ");
            }

            if (result.Length > 0)
            {
                result.Length--;
            }

            return result.ToString();
        }

        static bool IsLink(string str)
        {
            if (str.StartsWith("www.") || str.StartsWith("http://") || str.StartsWith("https://")) 
            {
                return true;
            }
            return false;
        }

        static bool IsEmail(string str)
        {
            return str.Contains("@");
        }
    }
}
