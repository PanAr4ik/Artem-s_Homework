using System.Drawing;

namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int year = 0;
            try
            {
                Console.Write("Введите тип работы программы: \n1-просчитать введёный год \n2-просчитать нынешний год \n\n");
                short variant = Convert.ToInt16(Console.ReadLine());

                if (variant == 1)
                {
                    Console.Write("Введите год: ");
                    year = Convert.ToInt32(Console.ReadLine());
                }
                else if (variant == 2)                
                    year = DateTime.Now.Year;
                else
                    WriteError();
            }
            catch{WriteError();}

            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                Console.WriteLine($"год: {year} - являеться високосным");
            else
                Console.WriteLine($"год: {year} - не являеться високосным");
        }

        static void WriteError()
        {
            var collor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ОШИБКА: Введите корентные данные и повториет попытку снова");
            Console.ForegroundColor = collor;
        }
    }

}
