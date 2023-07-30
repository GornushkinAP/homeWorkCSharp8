// // Задача 54: Задайте двумерный массив. Напишите программу, 
// // которая упорядочит по убыванию элементы каждой строки двумерного массива.
// // Например, задан массив:
// // 1 4 7 2
// // 5 9 2 3
// // 8 4 2 4
// // В итоге получается вот такой массив:
// // 7 4 2 1
// // 9 5 3 2
// // 8 4 4 2

Console.WriteLine("Доброго времени суток.");
Console.WriteLine("Введите количество строк:");
int rows;
while (!int.TryParse(Console.ReadLine(), out rows))
{
    Console.WriteLine("Ошибка ввода. Введите корректное количество строк: ");
}

Console.WriteLine("Введите количество столбцов:");
int cols;
while (!int.TryParse(Console.ReadLine(), out cols))
{
    Console.WriteLine("Ошибка ввода. Введите корректное количество столбцов: ");
}

int[,] array = FillArray(rows, cols);
Console.WriteLine("Исходный двумерный массив:");
PrintArray(array);

SortRowsDescending(array);
Console.WriteLine("Сортированный массив (в строках элементы по убыванию):");
PrintArray(array);
Console.WriteLine("Bye Bye");

static int[,] FillArray(int rows, int cols)
{
    int[,] array = new int[rows, cols];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            array[i, j] = new Random().Next(1, 100); // Генерируем случайное число от 1 до 99
        }
    }

    return array;
}

static void PrintArray(int[,] array)
{
    int rows = array.GetLength(0);
    int cols = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

static void SortRowsDescending(int[,] array)
{
    int rows = array.GetLength(0);

    for (int i = 0; i < rows; i++)
    {
        int[] row = GetRow(array, i);
        Array.Sort(row, (x, y) => y.CompareTo(x));
        SetRow(array, i, row);
    }
}

static int[] GetRow(int[,] array, int rowIndex)
{
    int cols = array.GetLength(1);
    int[] row = new int[cols];
    for (int j = 0; j < cols; j++)
    {
        row[j] = array[rowIndex, j];
    }
    return row;
}

static void SetRow(int[,] array, int rowIndex, int[] row)
{
    int cols = array.GetLength(1);
    for (int j = 0; j < cols; j++)
    {
        array[rowIndex, j] = row[j];
    }
}

