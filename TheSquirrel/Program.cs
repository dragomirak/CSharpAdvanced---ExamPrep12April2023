using System;

namespace TheSquirrel;

public class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string[] directions = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        char[,] field = new char[size, size];
        int currentRow = -1;
        int currentCol = -1;
        int hazelnutsCount = 0;

        for (int row = 0; row < size; row++)
        {
            char[] lineInput = Console.ReadLine().ToCharArray();
            for (int col = 0; col < size; col++)
            {
                field[row, col] = lineInput[col];
                if (field[row, col] == 's')
                {
                    currentRow = row;
                    currentCol = col;
                    field[currentRow, currentCol] = '*';
                }
            }
        }

        bool haselnutsCollected = false;
        for (int i = 0; i < directions.Length; i++)
        {
            string command = directions[i];

            if (currentRow == 0 && command == "up"
                || currentRow == size - 1 && command == "down"
                || currentCol == 0 && command == "left"
                || currentCol == (size - 1) && command == "right")
            {
                Console.WriteLine("The squirrel is out of the field.");
                Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                return;
            }

            if (command == "up" && field[currentRow - 1, currentCol] == 't'
                || command == "down" && field[currentRow + 1, currentCol] == 't'
                || command == "left" && field[currentRow, currentCol - 1] == 't'
                || command == "right" && field[currentRow, currentCol + 1] == 't')
            {
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                return;
            }

            if (command == "up")
            {
                currentRow--;
            }
            else if (command == "down")
            {
                currentRow++;
            }
            else if (command == "left")
            {
                currentCol--;
            }
            else if (command == "right")
            {
                currentCol++;
            }

            if (field[currentRow, currentCol] == '*')
            {
                continue;
            }
            else if (field[currentRow, currentCol] == 'h')
            {
                hazelnutsCount++;
                if (hazelnutsCount == 3)
                {
                    haselnutsCollected = true;
                    field[currentRow, currentCol] = 's';
                    break;
                }

                field[currentRow, currentCol] = '*';
            }
        }

        if (!haselnutsCollected)
        {
            Console.WriteLine("There are more hazelnuts to collect.");
        }
        else
        {
            Console.WriteLine("Good job! You have collected all hazelnuts!");
        }

        Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
    }
}