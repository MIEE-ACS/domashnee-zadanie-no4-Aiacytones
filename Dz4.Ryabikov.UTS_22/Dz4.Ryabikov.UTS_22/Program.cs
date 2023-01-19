using System;
using System.Globalization;
using System.Linq;

namespace Dz4.Ryabikov.UTS_22
{
    class Programm
    {
        public static int CorrectInt(string b)
        {
            int a;
            do
            {
                if (int.TryParse(b, out a))
                {
                    break;
                }
                Console.WriteLine("Число должно быть целым и положительным");
                b = Console.ReadLine();
            } while (true);
            if (a < 0)
            {
                a = a * -1;
            }
            return a;
        }
        public static void InitArray(int[] arr1)
        {

            Random r = new Random();
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = r.Next(-10, 10);
            }
        }
        public static void PrintArray(int[] arr1)
        {
            string str = string.Join(" ", arr1);
            Console.WriteLine(str);
        }
        public static int Main()
        {
            bool x_1 = true;
            while(x_1 == true)
            {
                Console.Write("Введите длину одномерного массива: ");
                string R = Console.ReadLine();
                int a = CorrectInt(R);
                int[] arr1 = new int[a];
                InitArray(arr1);
                Console.WriteLine("Исходный массив:");
                PrintArray(arr1);
                int temp_1;
                int temp_2;
                bool nal_1 = false;
                Console.WriteLine("Введите диапазон: ");
                while (true)
                {
                    if ((int.TryParse(Console.ReadLine(), out temp_1) && (int.TryParse(Console.ReadLine(), out temp_2))))
                    {
                        if ((temp_1 > 0) && (temp_2 > 0))
                        {
                            if (temp_1 < temp_2)
                            {
                                int c = temp_2 - temp_1 + 1;
                                if ((temp_1 > 0) && (temp_2 < arr1.Length + 1))
                                {
                                    var list_arr2 = arr1.ToList();
                                    var result_arr2 = list_arr2.GetRange(temp_1 - 1, c); //Считаю диапазон от A до B включая концы этого отрезка, в задании конкретно не указано нужно ли включать конечные значения диапазона
                                    var arr2 = result_arr2.ToArray();
                                    Console.WriteLine("");
                                    Console.WriteLine($"Элементы массива лежащие в диапазоне от {temp_1} до {temp_2}:");
                                    Console.WriteLine(string.Join(" ", arr2));
                                    int count = temp_2 - temp_1 + 1;
                                    Console.WriteLine($"Количество элементов массива лежащие в диапазоне от {temp_1} до {temp_2}:\n{count}");
                                    break;
                                }
                                else Console.WriteLine("Укажите промежуток не превыщающий длину массива");
                            }
                            else Console.WriteLine("Вы указали промежуток не по возростанию");
                        }
                        else Console.WriteLine("Укажите промежуток положительным числом числом");
                    }
                    else Console.WriteLine("Укажите промежуток целым числом");
                }
                int max_i = 0;
                int max = 0;
                int sum = 0;
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] >= max)
                    {
                        max_i = i;
                        max = arr1[i];
                        if (arr1[i] == max)
                        {
                            max_i = i;
                        }
                    }
                }
                if (max_i < arr1.Length - 1)
                {
                    for (int i = max_i + 1; i < arr1.Length; i++)
                    {
                        sum = sum + arr1[i];
                    }
                }
                if (max_i == arr1.Length - 1)
                {
                    sum = 0;
                }
                Console.Write("Сумма элементов после максимального элемента: \n");
                Console.WriteLine(sum);
                var sortedA = arr1.OrderBy(Math.Abs).ToArray();
                Console.Write("Элементы массива по убыванию модулей:\n");
                for (int i = 0; i < sortedA.Length; i++)
                {
                    Console.Write(sortedA[i] + " ");
                }
                Console.WriteLine("\n");
                Console.WriteLine("Введите размер прямоугольной матрицы:");
                int A_n;
                int A_m;
                string n = Console.ReadLine();
                string m = Console.ReadLine();
                A_n = CorrectInt(n);
                A_m = CorrectInt(m);
                int A = A_n;
                int B = A_m;
                int[,] matr = new int[A, B];
                Random ran = new Random();
                Console.WriteLine("Исходная матрица:");
                for (int i = 0; i < A; i++)
                {
                    for (int j = 0; j < B; j++)
                    {
                        matr[i, j] = ran.Next(-10, 50);
                        Console.Write("{0}\t", matr[i, j]);
                    }
                    Console.WriteLine();
                }
                int x_2 = 1;
                while (x_2 == 1)
                {
                    Console.WriteLine("Пожалуйста, выберите действие из предложенных: \n1. Сдвинуть элементы вправо. \n2. Сдвинуть элементы вниз.");
                    string choise_ = Console.ReadLine();
                    int choise;
                    choise = CorrectInt(choise_);
                    if (choise == 1)
                    {
                        Console.WriteLine("Введите величину сдвига: ");
                        int k;
                        while (!int.TryParse(Console.ReadLine(), out k))
                            Console.Write("Ошибка! Повторите ввод: ");
                        for (int b = 1; b <= k; b++)
                            for (int i = 0; i < A; i++)
                            {
                                int t = matr[i, B - 1];
                                for (int j = B - 1; j > 0; j--)
                                    matr[i, j] = matr[i, j - 1];
                                matr[i, 0] = t;
                            }
                        Console.WriteLine("Сдвинутая матрица: ");
                        for (int i = 0; i < A; i++)
                        {
                            for (int j = 0; j < B; j++)
                                Console.Write("{0}\t", matr[i, j]);
                            Console.WriteLine();
                        }
                    }
                    else if (choise == 2)
                    {
                        Console.WriteLine("Введите величину сдвига: ");
                        int k;
                        while (!int.TryParse(Console.ReadLine(), out k))
                            Console.Write("Ошибка! Повторите ввод: ");
                        for (int b = 1; b <= k; b++)
                            for (int j = 0; j < B; j++)
                            {
                                int t = matr[A - 1, j];
                                for (int i = A - 1; i > 0; i--)
                                    matr[i, j] = matr[i - 1, j];
                                matr[0, j] = t;
                            }
                        Console.WriteLine("Сдвинутая матрица: ");
                        for (int i = 0; i < A; i++)
                        {
                            for (int j = 0; j < B; j++)
                            Console.Write("{0}\t", matr[i, j]);
                            Console.WriteLine();
                        }
                    }
                    else Console.WriteLine("Пожалуйста, укажите номер из списка");
                    Console.WriteLine("Пожалуйста, выберите действие из предложенных: \n1. Повторить сдвиг. \n2. Выйти.");
                    int.TryParse(Console.ReadLine(), out x_2);
                    if (x_2 == 1)
                    {
                        x_2 = 1;
                    }
                    else if(x_2 == 2)
                    {
                        x_1 = false;
                    }
                }
            }
            return 0;
        }
    }
}