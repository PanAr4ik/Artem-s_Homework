namespace Lesson_07_09_Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float secondNumber;
            float firstNumber;
            float Sum;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                try
                {
                    Console.Write("Enter first value(higher value): ");
                    firstNumber = Convert.ToSingle(Console.ReadLine());
                    Console.Write("Enter second value(lower value): ");
                    secondNumber = Convert.ToSingle(Console.ReadLine());
                    Sum = firstNumber+secondNumber;

                    Console.WriteLine(String.Format("{0:F2}", Sum));
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
