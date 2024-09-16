namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> numbers = new List <int> ();
            int userInput = 0;
            int numberToCompare;
            int result = 0;


            Console.WriteLine("Введите несколько целых чисел, после введите любое отрицательное число, для прекращения вврода.\n\n");
            try
            {
                while (userInput >= 0)
                {
                    Console.Write("Введите число: ");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    numbers.Add(userInput);
                }


                Console.Write("Введите число для сравнения: ");
                numberToCompare = Convert.ToInt32(Console.ReadLine());

                foreach (int number in numbers)
                {
                    if (number > numberToCompare) result++;
                }
            }
            catch { Console.WriteLine("Введите коректные данные."); }

            Console.WriteLine($"В ввёденном массиве {result} больше чем сравниваемое число.");

        }
    }
}
