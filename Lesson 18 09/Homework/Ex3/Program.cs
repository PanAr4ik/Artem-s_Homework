namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {                
                Console.WriteLine("Введите строку: ");
                string str = Console.ReadLine();
                Console.WriteLine(ReverseString(str));                       
        }


        public static string ReverseString(string str)
        {
            if (str.Length <= 1)
                return str;

            return ReverseString(str.Substring(1)) + str[0];
        } 
    }
}
