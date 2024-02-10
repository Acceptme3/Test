global using Microsoft.Extensions.DependencyInjection;
using Task1.Services;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IPercentCalc, PercentCalc>()
                .BuildServiceProvider();

            string? str;
            while (true)
            {
                Console.WriteLine("Введите сумму ваших денежных средств, которую хотите внести и мы рассчитаем вам ставку");
                Console.WriteLine();
                Console.WriteLine("Если хотите выйти из приложения введите exit");
                str = Console.ReadLine();
                if (String.IsNullOrEmpty(str)) 
                {
                    Print("Вы ничего не ввели. Пожалуйста, повторите попытку");
                    continue;
                }
                if (str == "exit") 
                {
                    Console.WriteLine("Выход..");
                    break;
                }
                if (int.TryParse(str, out int result) && result > 0) 
                {
                    IPercentCalc percentCalc = serviceProvider.GetRequiredService<IPercentCalc>();
                    Print($"Если вы внесете сейчас {result}, то через год вы будете иметь : {percentCalc.GetInterestRate(result)}");
                    continue;
                }
                Print("Вы ввели некорректные данные. Пожалуйста, повторите попытку");
                continue;            
            }
            Console.ReadKey();
        }
        static void Print(string text) 
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine();
        } 
    }
}
