namespace Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float dividend = 0; float divisor = 0;
            float quotient, remainder;

            try
            {
                Console.Write("Введите делитель: ");
                dividend = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите делитель: ");
                divisor = Convert.ToInt32(Console.ReadLine());
            }
            catch { WriteError(); }
            DivideAndRemainder(dividend, divisor, out quotient, out remainder);

            Console.WriteLine($"Деление {dividend} на {divisor}:");
            Console.WriteLine($"Частное: {quotient}");
            Console.WriteLine($"Остаток: {remainder}");

        }

        static void DivideAndRemainder(float dividend, float divisor, out float quotient, out float remainder)
        {
            quotient = dividend / divisor;
            remainder = dividend % divisor;
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
