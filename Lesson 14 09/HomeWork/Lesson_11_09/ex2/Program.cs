namespace ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y = 1;
            short size = 10;
            Random random = new Random();
           
            Console.WriteLine("Введитe размер матрицы в формате (X Y) x-столбцы; y-строки");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');
            
            x = int.Parse(parts[0]);
            y = int.Parse(parts[1]);        
            int[,] array = new int[x, y];
            Console.WriteLine("Введитe максимальный размер значения");
            size = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("----------------------");

            for (int a = 0; a < x; a++)
            {
                int sum = 0;
                for (int b = 0; b < y; b++)
                {
                    int boofer = random.Next(size);
                    array[a, b] = boofer;
                    Console.Write($"{boofer}, ");
                    sum += boofer;
                }
                Console.WriteLine($"       Сумма: {sum} ");
            }
        }
    }
}
