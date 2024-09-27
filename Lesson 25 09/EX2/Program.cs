namespace EX2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Mather.Calculate("2 2 + 1 /"));
        }
    }

    public class Mather
    {
        public static double Calculate(string expression)
        {
            var stack = new Stack<double>();

            foreach (var iten in expression.Split(' '))
            {
                if (double.TryParse(iten, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    if (stack.Count >= 2)
                    {
                        var b = stack.Pop();
                        var a = stack.Pop();

                        switch (iten)
                        {
                            case "+":
                                stack.Push(a + b);
                                break;
                            case "-":
                                stack.Push(a - b);
                                break;
                            case "*":
                                stack.Push(a * b);
                                break;
                            case "/":
                                if (b != 0)
                                    stack.Push(a / b);
                                break;
                            default:
                                throw new InvalidOperationException($"Invalid operator {iten}");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Insufficient operands");
                    }
                }
            }

            if (stack.Count == 1)
            {
                return stack.Pop(); 
            }
            else
            {
                throw new InvalidOperationException("Invalid expression");
            }
        }
    }
}

