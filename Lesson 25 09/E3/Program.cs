namespace E3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<(string task, int duration)> taskQueue = new Queue<(string task, int duration)>();

            taskQueue.Enqueue(("Task 1", 1200));
            taskQueue.Enqueue(("Task 2", 500));
            taskQueue.Enqueue(("Task 3", 1600));

            int time = 500;

            while (taskQueue.Count > 0)
            {
                var currentTask = taskQueue.Dequeue();
                string taskName = currentTask.task;
                int remainingTime = currentTask.duration;

                if (remainingTime > time)
                {
                    Console.WriteLine($"{taskName} выполняется в течение {time} мс");
                    Thread.Sleep(time);

                    remainingTime -= time;
                    taskQueue.Enqueue((taskName, remainingTime));
                }
                else
                {
                    Console.WriteLine($"{taskName} выполняется и завершается за {remainingTime} мс");
                    Thread.Sleep(remainingTime);
                }
            }

            Console.WriteLine("Все задачи выполнены!");
        }
    }
}
