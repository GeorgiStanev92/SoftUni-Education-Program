using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[,] field = ReadFieldValues();

        string bombInfo = Console.ReadLine();
        while (bombInfo != "cease fire!")
        {
            string[] bombParameters = bombInfo.Split();
            int targetRow = int.Parse(bombParameters[0]);
            int targetCol = int.Parse(bombParameters[1]);
            int bombPower = bombParameters[2][0];

            BombardField(field, targetRow, targetCol, bombPower);
            bombInfo = Console.ReadLine();
        }

        int destroyedTargets = CountDestroyedTargers(field);
        double totalTargets = field.GetLength(0) * field.GetLength(1);
        double damageDone = 100 * destroyedTargets / totalTargets;

        Console.WriteLine($"Destroyed bunkers: {destroyedTargets}");
        Console.WriteLine($"Damage done: {damageDone:F1} %");
    }

    private static int CountDestroyedTargers(int[,] field)
    {
        int count = 0;

        for (int row = 0; row < field.GetLength(0); row++)
            for (int col = 0; col < field.GetLength(1); col++)
                if (field[row, col] <= 0)
                    count++;

        return count;
    }

    private static void BombardField(int[,] field, int targetRow, int targetCol, int bombPower)
    {
        field[targetRow, targetCol] -= bombPower;

        int secondaryPower = (int)Math.Ceiling(bombPower / 2.0);
        int fieldRowLength = field.GetLength(0);
        int fieldColLength = field.GetLength(1);

        // Upper Row Targets
        if (targetRow - 1 >= 0)
        {
            field[targetRow - 1, targetCol] -= secondaryPower;

            if (targetCol - 1 >= 0)
                field[targetRow - 1, targetCol - 1] -= secondaryPower;

            if (targetRow - 1 >= 0 && targetCol + 1 < fieldColLength)
                field[targetRow - 1, targetCol + 1] -= secondaryPower;
        }

        // Same Row Adjacent Targets
        if (targetCol - 1 >= 0)
            field[targetRow, targetCol - 1] -= secondaryPower;

        if (targetCol + 1 < fieldColLength)
            field[targetRow, targetCol + 1] -= secondaryPower;

        // Down Row Targets 
        if (targetRow + 1 < fieldRowLength)
        {
            field[targetRow + 1, targetCol] -= secondaryPower;

            if (targetCol - 1 >= 0)
                field[targetRow + 1, targetCol - 1] -= secondaryPower;

            if (targetCol + 1 < fieldColLength)
                field[targetRow + 1, targetCol + 1] -= secondaryPower;
        }
    }

    private static int[,] ReadFieldValues()
    {
        int[] dimensions = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int rowLength = dimensions[0];
        int colLength = dimensions[1];

        int[,] field = new int[rowLength, colLength];
        for (int row = 0; row < rowLength; row++)
        {
            int[] colValues = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < colLength; col++)
            {
                field[row, col] = colValues[col];
            }
        }

        return field;
    }
}