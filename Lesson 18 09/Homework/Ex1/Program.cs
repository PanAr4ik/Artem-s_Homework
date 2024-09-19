namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int a, b, c = 0;
                    a = GetNumber();
                    b = GetNumber();
                    c = GetNumber();
                    Console.WriteLine(MaxOfThreeNumber(a, b, c));
                }
                catch { WriteError(); }
            }

        }

        
        static int MaxOfThreeNumber(int a, int b, int c)
        {
            List<int> list = new List<int>() {a, b, c};
            return list.Max();
        }

        static int GetNumber()
        {
            Console.Write("Enter the number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            return number;
        }

        static void WriteError()
        {
            ConsoleColor collor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error, enter corect data & try again");
            Console.ForegroundColor = collor;
        }


    }
}
