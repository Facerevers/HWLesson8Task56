// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

void MinimumSum(int[] mas2)
{
    int min = 0;
    for (int i = 0; i < mas2.Length; i ++)
    {
        for (int j = 1; j < mas2.Length; j++)
        {
            if (mas2[i] > mas2[j]) {min = j+1;}
        }
    }
    Console.WriteLine($"Номер строки с минимальной суммой элементов: {min}");
}

int[] FindSum(int[,] mas, int rows, int columns)
{
    int[] mas2 = new int[rows];
    int sum = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            sum = sum + mas[i,j];
            mas2[i] = sum;
        }
        sum = 0;
    }
    return mas2;
}

void PrintMas(int[,] mas)
{
    for (int i = 0; i < mas.GetLength(0); i++)
    {
        for (int j = 0; j < mas.GetLength(1); j++)
        {
            Console.Write($"{mas[i,j]}\t");
        }
        Console.WriteLine();
    }
}

int[,] GenerateMas(int rows, int columns, int numMin, int numMax)
{
    int[,] mas = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            mas[i,j] = new Random().Next(numMin, numMax);
        }
    }
    return mas;
}

int GetInput(string text)
{
    Console.WriteLine(text);
    return Convert.ToInt32(Console.ReadLine());
}

int rows = GetInput("Введите количество строк в массиве: ");
int columns = GetInput("Введите количество строк в массиве: ");
int numMin = GetInput("Введите минимальный элемент массива: ");
int numMax = GetInput("Введите максимальный элемент массива: ");
Console.WriteLine();
int[,] mas = GenerateMas(rows, columns, numMin, numMax);
PrintMas(mas);
Console.WriteLine();
//int[,] mas2 = OrderingRowsToMin(mas, rows, columns);
int[] mas2 = FindSum(mas, rows, columns);
MinimumSum(mas2);