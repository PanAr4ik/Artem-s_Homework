namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int userInput;
            bool wantoRestart = true;

            Console.WriteLine("Добро пожаловать игру «Угадай число»" +
                "\nПравила: " +
                "\nКомпьютер загадывает число от 1 до 100, ваша задача его отгадать." +
                "\nВам будут даваться такие подсказки: больше или меньше число которое вы ввели по сравнению с загаданым числом. " +
                "\nУ вас есть 8 попыток что-бы отгатать, потом игра завершиться.");

            while (wantoRestart)
            {
                
                Console.WriteLine("============================================================================");

                byte tryCounter = 0;
                int randomValue = rand.Next(1, 101);
                bool showValue = true;

                while (tryCounter < 8)
                {
                    try {
                        Console.Write("Введите значение: ");
                        userInput = Convert.ToInt32(Console.ReadLine());
                        if (userInput == randomValue)
                        {
                            Console.WriteLine("Поздравляю!!! Вы угодали число");
                            showValue = false;
                            break;
                        }
                        else if (userInput < randomValue)
                        {
                            Console.WriteLine("Ваше число меньше чем загаданое");
                            Console.WriteLine($"У вас осталось {8 - tryCounter} попыток");
                        }
                        else if (userInput > randomValue)
                        {
                            Console.WriteLine("Ваше число Больше чем загаданое");
                            Console.WriteLine($"У вас осталось {8 - tryCounter} попыток\n");
                        }
                        tryCounter++;
                    }
                    catch
                    {
                        Console.WriteLine("Введите коректное число \n\n");
                    }
                }
                if (showValue) Console.WriteLine($"\n\nЗагаданое число было {randomValue}");

                Console.WriteLine("Желаете продолжить игру (да/нет)");
                string answer = Console.ReadLine().ToLower();
                wantoRestart = answer == "да";
                Console.Clear();
            }
        }
    }
}
