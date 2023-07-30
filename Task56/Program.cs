// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка


int rows, cols;
Console.WriteLine("Здравствуйте. Пожалуйста задайте прямоугольный двумерный массив (кол-во строк = кол-ву столбцов).");
Console.WriteLine("Введите количество строк:");
while (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0)
{
    Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число.");
}

Console.WriteLine("Введите количество столбцов:");
while (!int.TryParse(Console.ReadLine(), out cols) || cols <= 0)
{
    Console.WriteLine("Неверный ввод. Пожалуйста, введите положительное число.");
}

int[,] matrix = GetRndMatrix(rows, cols);
PrintMatrix(matrix);

int minSumRowIndex = FindRowWithMinSum(matrix);

Console.WriteLine($"Строка с наименьшей суммой элементов №{minSumRowIndex + 1} Досвидания!");


static int[,] GetRndMatrix(int rows, int cols)
{
    int[,] matrix = new int[rows, cols];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            matrix[i, j] = new Random().Next(1, 100); 
        }
    }

    return matrix;
}

static void PrintMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);

    Console.WriteLine("Сгенерированный массив:");
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

static int FindRowWithMinSum(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    int minSum = int.MaxValue;
    int minSumRowIndex = -1;

    for (int i = 0; i < rows; i++)
    {
        int currentSum = 0;
        for (int j = 0; j < cols; j++)
        {
            currentSum += matrix[i, j];
        }

        if (currentSum < minSum)
        {
            minSum = currentSum;
            minSumRowIndex = i;
        }
    }

    return minSumRowIndex;
}

