namespace EX2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueCalculation = true;

            while (continueCalculation)
            {
                Console.Clear();
                Console.Write("Bведите первое число: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Некорректный ввод числа.\n");
                    continue;
                }
                
                Console.WriteLine("Выберите операцию (+, -, *, /):");
                string operation = Console.ReadLine();

                Console.Write("Введите второе число: ");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    Console.WriteLine("Некорректный ввод числа. \n");
                    continue;
                }

                double result = 0;
                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 == 0)
                            Console.WriteLine("Деление на ноль невозможно.\n");
                        else
                            result = num1 / num2;
                        break;
                    default:
                        Console.WriteLine("Некорректная операция.\n");
                        continue;
                }

                Console.WriteLine("Результат: " + result);

                Console.WriteLine("Продолжить вычисления? (да/нет)");
                string answer = Console.ReadLine().ToLower();
                continueCalculation = answer == "да";
            }
        }
    }
}

