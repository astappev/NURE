using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHLb_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите исходный размер массива: ");
            int n = int.Parse(Console.ReadLine());
            int[,] mas = new int[n, n];

            Console.Write("Хотите ввести масив вручную? (Y or N): ");
            string Answer = Console.ReadLine();
            if (Answer[0] == 'Y' || Answer[0] == 'y')
            {
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        Console.Write("Введите элемент для, {0} строки и {1} столбца: ", i + 1, j + 1);
                        mas[i, j] = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.Write("Сгенирированный массив:\n");
                Random random = new Random();
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        mas[i, j] = random.Next(20)-10;
                        Console.Write("{0}\t", mas[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            //1. Подсчитать среднее арифметическое нечетных элементов, расположенных выше главной диагонали.
            int sum = 0, count = 0;
            for (int i = 0; i < n  - 1; ++i)
            for (int j = 0; j < n - i - 1; ++j)
            {
                if (mas[i, j] % 2 != 0)
                {
                    sum += mas[i, j];
                    count++;
                }
            }

            if (count > 0) Console.Write("Среднее арифметическое нечетных элементов, расположенных выше главной диагонали: {0}.\n", sum / count);
            else Console.Write("Нет чисел удовлетворяющих условие.");
        }
    }
}
