namespace RubberDuckDebuggers;

public class Program
{
    static void Main()
    {
        int[] tasksTimesArray = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int[] tasksNumbersArray = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Queue<int> times = new Queue<int>(tasksTimesArray);
        Stack<int> numbers = new Stack<int>(tasksNumbersArray);

        int darthVaderDucky = 0;
        int thorDucky = 0;
        int bigBlueRubberDucky = 0;
        int smallYellowRubberDucky = 0;
        while (times.Count > 0 && numbers.Count > 0)
        {
            int currentTime = times.Peek();
            int currentTask = numbers.Peek();

            int result = currentTime * currentTask;
            if (result >= 0 && result <= 60)
            {
                darthVaderDucky++;
                times.Dequeue();
                numbers.Pop();
            }
            else if (result >= 61 && result <= 120)
            {
                thorDucky++;
                times.Dequeue();
                numbers.Pop();
            }
            else if (result >= 121 && result <= 180)
            {
                bigBlueRubberDucky++;
                times.Dequeue();
                numbers.Pop();
            }
            else if (result >= 181 && result <= 240)
            {
                smallYellowRubberDucky++;
                times.Dequeue();
                numbers.Pop();
            }
            else if (result >= 241)
            {
                times.Enqueue(times.Dequeue());
                numbers.Push(numbers.Pop() - 2);
            }

        }

        Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
        Console.WriteLine($"Darth Vader Ducky: {darthVaderDucky}");
        Console.WriteLine($"Thor Ducky: {thorDucky}");
        Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueRubberDucky}");
        Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellowRubberDucky}");
    }

}

