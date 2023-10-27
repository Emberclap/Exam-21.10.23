using System;

namespace _02._Fishing_Competition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldSize, fieldSize];

            int currentRowIndex = 0;
            int currentColIndex = 0;
            int fishCollected = 0;

            for (int rows = 0; rows < field.GetLength(0); rows++)
            {
                char[] col = Console.ReadLine().ToArray();

                for (int cols = 0; cols < field.GetLength(1); cols++)
                {
                    
                    field[rows, cols] = col[cols];
                    if (col[cols] == 'S')
                    {
                        currentRowIndex = rows;
                        currentColIndex = cols;
                        field[rows, cols] = '-';
                    }
                }
            }

            string command = string.Empty;

            bool inWhirlpool = false;

            while (!inWhirlpool && (command = Console.ReadLine()) != "collect the nets")
            {
                switch (command)
                {
                    case "up":
                        if (BoundsCheck(currentRowIndex - 1, currentColIndex, field))
                        {
                            currentRowIndex--;
                        }
                        else { currentRowIndex = field.GetLength(0)-1; }
                        (currentRowIndex, currentColIndex, field, fishCollected, inWhirlpool) =
                             PositionActions(currentRowIndex, currentColIndex, field, fishCollected, inWhirlpool);
                        break;
                    case "down":
                        if (BoundsCheck(currentRowIndex + 1, currentColIndex, field))
                        {
                            currentRowIndex++;
                        }
                        else { currentRowIndex = 0; }
                        (currentRowIndex, currentColIndex, field, fishCollected, inWhirlpool) =
                             PositionActions(currentRowIndex, currentColIndex, field, fishCollected, inWhirlpool);
                        break;
                    case "right":
                        if (BoundsCheck(currentRowIndex, currentColIndex + 1, field))
                        {
                            currentColIndex++;
                        }
                        else { currentColIndex = 0; }
                        (currentRowIndex, currentColIndex, field, fishCollected, inWhirlpool) =
                            PositionActions(currentRowIndex, currentColIndex, field, fishCollected, inWhirlpool);
                        break;
                    case "left":
                        if (BoundsCheck(currentRowIndex, currentColIndex - 1, field))
                        {
                            currentColIndex--;
                        }
                        else { currentColIndex = field.GetLength(1)-1; }
                        (currentRowIndex, currentColIndex, field, fishCollected, inWhirlpool) =
                             PositionActions(currentRowIndex, currentColIndex, field, fishCollected, inWhirlpool);
                        break;
                }
            }
            field[currentRowIndex, currentColIndex] = 'S';
            if (inWhirlpool)
            {
                Console.WriteLine($"You fell into a whirlpool!" +
                    $" The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currentRowIndex},{currentColIndex}]");
                return;
            }
            if (fishCollected >= 20)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
            }
            else
            {
                Console.Write("You didn't catch enough fish and didn't reach the quota! ");
                Console.WriteLine($"You need {20 - fishCollected} tons of fish more.");
            }
            if (fishCollected > 0)
            {
                Console.WriteLine($"Amount of fish caught: {fishCollected} tons.");
            }
            if (!inWhirlpool)
            {
                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field.GetLength(1); col++)
                    {
                        Console.Write($"{field[row, col]}");
                    }
                    Console.WriteLine();
                }
            }

        }
        public static Tuple<int,int, char[,], int, bool> PositionActions(int row, int col, char[,] field, int fishCollected, bool whirlpool)
        {
            if (char.IsDigit(field[row, col]))
            {
                int fish = int.Parse(field[row, col].ToString());
                fishCollected += fish;
                field[row, col] = '-';
            }
            else if (field[row, col] == 'W')
            {
                whirlpool = true;
            }
            
            return Tuple.Create(row, col, field, fishCollected, whirlpool);
        }
        public static bool BoundsCheck(int rowIndex, int colIndex, char[,] matrix)
        {
            return (rowIndex >= 0 && colIndex >= 0 && rowIndex < matrix.GetLength(0) && colIndex < matrix.GetLength(1));
        }
    }
}