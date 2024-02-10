namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 6, 7, 2, 3, 9, 4, 7, 1, 3, 6, 8, 3, 7, 8, 3 };
 
            Console.WriteLine($"Минимальная сумма соседних элементов массива: { SumCompare(array)}");
            Console.ReadLine();
        }

        static int SumCompare(int[] array)
        {
            int sum = 0;
            int res = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int next = (i + 1 < array.Length) ? array[i + 1] : 0;
                res = array[i] + next;

                if (sum == 0 || sum > res)
                {
                    sum = res;
                }
            }
            return sum;
        }
    }
}
