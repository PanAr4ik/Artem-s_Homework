namespace Lesson_07_09_Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int secondNumber;
            int firstNumber;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                try
                {
                    Console.Write("Enter first value(higher value): ");
                    firstNumber = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter second value(lower value): ");
                    secondNumber = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"\nSum{firstNumber + secondNumber} \nDifference{firstNumber - secondNumber}" +
                        $"\nProduct: {firstNumber * secondNumber} \nQuotient{firstNumber / secondNumber}");
                }
                catch
                {
                    Console.WriteLine("\n\nEnter correct data and try again");
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
