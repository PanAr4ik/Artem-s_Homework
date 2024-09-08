namespace Lesson_07_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            short age, weight;

            Console.ForegroundColor = ConsoleColor.Cyan;
            try
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
               
                Console.Write("\nEnter your age: ");
                age = Convert.ToInt16(Console.ReadLine());
                
                Console.Write("\nEnter your weight: ");
                weight = Convert.ToInt16(Console.ReadLine());
                
                Console.WriteLine($"\nYour name is: {name}\nYour age is: {age}\nYour weight is: {weight} ");

            }
            catch{Console.WriteLine("Enter correct data and try again");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
