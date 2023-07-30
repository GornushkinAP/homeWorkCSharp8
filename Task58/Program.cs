// адача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

static void FillMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(1, 10);
        }
    }
}

static void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

static int[,] MultiplyMatrix(int[,] matrix1, int[,] matrix2)
{
    int rows1 = matrix1.GetLength(0);
    int cols1 = matrix1.GetLength(1);
    int rows2 = matrix2.GetLength(0);
    int cols2 = matrix2.GetLength(1);

    if (cols1 != rows2)
    {
        throw new ArgumentException("Невозможно умножить матрицы: количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
    }

    int[,] resultMatrix = new int[rows1, cols2];

    for (int i = 0; i < rows1; i++)
    {
        for (int j = 0; j < cols2; j++)
        {
            int sum = 0;
            for (int k = 0; k < cols1; k++)
            {
                sum += matrix1[i, k] * matrix2[k, j];
            }
            resultMatrix[i, j] = sum;
        }
    }

    return resultMatrix;
}


try
{
    Console.WriteLine("И снова Здравствуйте");
    Console.Write("Введите количество строк первой матрицы: ");
    int rows1 = int.Parse(Console.ReadLine());

    Console.Write("Введите количество столбцов первой матрицы: ");
    int cols1 = int.Parse(Console.ReadLine());

    Console.Write("Введите количество строк второй матрицы: ");
    int rows2 = int.Parse(Console.ReadLine());

    Console.Write("Введите количество столбцов второй матрицы: ");
    int cols2 = int.Parse(Console.ReadLine());

    int[,] matrix1 = new int[rows1, cols1];
    int[,] matrix2 = new int[rows2, cols2];

    FillMatrix(matrix1);
    FillMatrix(matrix2);

    Console.WriteLine("Первая матрица:");
    PrintMatrix(matrix1);

    Console.WriteLine("Вторая матрица:");
    PrintMatrix(matrix2);

    int[,] resultMatrix = MultiplyMatrix(matrix1, matrix2);

    Console.WriteLine("Результат умножения матриц:");
    PrintMatrix(resultMatrix);
    Console.WriteLine("Досвидания!");
}
catch (FormatException)
{
    Console.WriteLine("Ошибка: Некорректный формат ввода числа.");
}
catch (ArgumentException ex)
{
    Console.WriteLine("Ошибка: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Ошибка: " + ex.Message);
}


