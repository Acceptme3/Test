namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = { { { 1, 2 },{ 3, 4 } },
                        { { 4, 5 }, { 6, 7 } },
                        { { 7, 8 }, { 9, 10 } },
                        { { 10, 11 }, { 12, 13 } }
                      };

            Console.Write("{");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (i > 0)
                {
                    Console.Write(" , ");
                }

                Console.Write("{");

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j > 0)
                    {
                        Console.Write(" , ");
                    }

                    Console.Write("{");

                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (k > 0)
                        {
                            Console.Write(" , ");
                        }

                        Console.Write(array[i, j, k]);
                    }

                    Console.Write("}");
                }

                Console.Write("}");
            }

            Console.WriteLine("}");
            Console.ReadKey();
        }
    }
}
