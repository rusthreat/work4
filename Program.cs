﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Program
    {
        static string str;
        static Random random = new Random();

        static void Main(string[] args)
        {
            // меню для выбора решения
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите задание:");
                Console.WriteLine("1 - Финансы");
                Console.WriteLine("2 - Треугольник Паскаля");
                Console.WriteLine("3 - Умножение матрицы на число");
                Console.WriteLine("4 - Сложение и вычитание матриц");
                Console.WriteLine("5 - Умножение матриц");
                int item = int.Parse(Console.ReadLine());

                Console.Clear();

                #region Задание 1 - Финансы          
                // Задание 1.
                // Заказчик просит вас написать приложение по учёту финансов
                // и продемонстрировать его работу.
                // Суть задачи в следующем: 
                // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
                // За год получены два массива – расходов и поступлений.
                // Определить прибыли по месяцам
                // Количество месяцев с положительной прибылью.
                // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
                // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
                // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

                // Пример
                //       
                // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
                //     1              100 000             80 000                 20 000
                //     2              120 000             90 000                 30 000
                //     3               80 000             70 000                 10 000
                //     4               70 000             70 000                      0
                //     5              100 000             80 000                 20 000
                //     6              200 000            120 000                 80 000
                //     7              130 000            140 000                -10 000
                //     8              150 000             65 000                 85 000
                //     9              190 000             90 000                100 000
                //    10              110 000             70 000                 40 000
                //    11              150 000            120 000                 30 000
                //    12              100 000             80 000                 20 000
                // 
                // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
                // Месяцев с положительной прибылью: 10
                if (item == 1)
                {
                    Console.WriteLine("1. Финансы");
                    // 1. Формирование массивов доходов и расходов

                    int[] income = new int[12]; // массив доходов
                    int[] expense = new int[12]; // массив расходов

                    for (int i = 0; i < income.Length; i++)      
                    {                                           
                        income[i] = random.Next(9,16) * 10000;
                        expense[i] = random.Next(6,13) * 10000;
                    }                                            

                    // 2. Обработка массивов
                    int[,] profit = new int[2,12]; // массив прибыли

                    // массив месяцев с худшей прибылью
                    //int[,] bad_profit = new int[2,12]; // массив прибыли

                    // Вывод шапки отчета
                    Console.WriteLine("\nМесяц      Доход, тыс. руб.  Расход, тыс. руб.   Прибыль, тыс. руб.");
                    
                    // Счетчик месяцев с положительной прибылью
                    int good_month = 0;
                    
                    for (int i = 0; i < income.Length; i++)      
                    {                                           
                        profit[0,i] = income[i] - expense[i];
                        profit[1,i] = i+1;
                        Console.WriteLine($"{i+1,5}{income[i],21:### ###}{expense[i],19:### ###}{profit[0,i],21:### ###}");
                        if (profit[0,i] > 0)
                        {
                            good_month++;    
                        }
                    }                                            

                    // 3. Вывод показателей
                    Console.WriteLine($"\nМесяцев с положительной прибылью: {good_month}");

                    // Сортировка массива profit по возрастанию прибыли
                    while(true)
                    {
                        bool flag = false;
                        for (int i = 0; i < 12; i++)
                        {
                            if (i == 11)
                            {
                                flag = true;
                            }
                            else if (profit[0,i] > profit[0,i+1])
                            {
                                // меняем местами суммы
                                int r = profit[0,i];
                                profit[0,i] = profit[0,i+1];
                                profit[0,i+1] = r;

                                // меняем местами месяцы
                                r = profit[1,i];
                                profit[1,i] = profit[1,i+1];
                                profit[1,i+1] = r;

                                break;
                            }
                        }
                        if (flag == true)
                        {
                            break;                                    
                        }
                    }

                    // Вывод месяцев с худшей прибылью
                    Console.Write("Худшая прибыль в месяцах: ");
                    int count = 1;
                    int previous_value = -500000;
                    
                    for (int i = 0; i < 12; i++)      
                    {                                           
                        if (i != 0 && previous_value != profit[0,i])
                        {
                            count++;                    
                        }
                        if (count > 3)
                        {
                            break;
                        }
                        else if (i != 0)
                        {
                            Console.Write(", ");
                        }
                        Console.Write($"{profit[1,i]}");

                        previous_value = profit[0,i];
                    }
                }
                #endregion
                
                #region Задание 2 - Треугольник Паскаля
                // * Задание 2
                // Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
                // 
                // При N = 9. Треугольник выглядит следующим образом:
                //                                 1
                //                             1       1
                //                         1       2       1
                //                     1       3       3       1
                //                 1       4       6       4       1
                //             1       5      10      10       5       1
                //         1       6      15      20      15       6       1
                //     1       7      21      35      35       21      7       1
                //                                                              
                //                                                              
                // Простое решение:                                                             
                // 1
                // 1       1
                // 1       2       1
                // 1       3       3       1
                // 1       4       6       4       1
                // 1       5      10      10       5       1
                // 1       6      15      20      15       6       1
                // 1       7      21      35      35       21      7       1
                // 
                // Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля

                else if (item == 2)
                {
                    Console.WriteLine("2. Треугольник Паскаля");
                    Console.WriteLine("\nВведите число строк: ");
                    int n = Convert.ToInt32(Console.ReadLine());

                    // объявление двумерного массива
                    int[][] jaggedArray = new int[n][];
                    
                    // поиск центра 
                    int center = Console.WindowWidth / 2 - 4;

                    // заполнение массива массивов информацией 
                    for (int i = 0; i < n; i++)
                    {
                        // создание одномерного массива - строки
                        jaggedArray[i] = new int[i+1];

                        // установка курсора для вывода результата в виде пирамиды
                        // Console.SetCursorPosition((Console.WindowWidth - (i + 1) * 7) / 2, Console.CursorTop);
                        Console.SetCursorPosition(center-=4, Console.CursorTop);
                        
                        for (int j = 0; j <= i; j++)
                        { 
                            if (j == 0 || j == i)
                            {
                                jaggedArray[i][j] = 1;    
                            }
                            else
                            {
                                jaggedArray[i][j] = jaggedArray[i-1][j-1] + jaggedArray[i-1][j];
                            } 
                            Console.Write($"{jaggedArray[i][j],8:0}");
                        }
                        Console.WriteLine();
                    }
                }
                #endregion

                #region Задание 3.1. Умножение матрицы на число
                // 
                // * Задание 3.1
                // Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
                // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
                // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
                // Добавить возможность ввода количество строк и столцов матрицы и число,
                // на которое будет производиться умножение.
                // Матрицы заполняются автоматически. 
                // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
                //
                // Пример
                //
                //      |  1  3  5  |   |  5  15  25  |
                //  5 х |  4  5  7  | = | 20  25  35  |
                //      |  5  3  1  |   | 25  15   5  |
                //
                
                else if (item == 3)
                {
                    Console.WriteLine("3.1. Умножение матрицы на число");

                    // запрос размера матрицы
                    Console.WriteLine("\nУкажите число строк: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Укажите число столбцов: ");
                    int m = Convert.ToInt32(Console.ReadLine());

                    // объявление начальной матрицы
                    int[][] Array = new int[n][];

                    // объявление итоговой матрицы
                    int[][] Total = new int[n][];
                    // 

                    Console.WriteLine("Укажите число-множитель: ");
                    int a = Convert.ToInt32(Console.ReadLine());

                    // формирование начальной матрицы и итоговой матрицы
                    for (int j = 0; j < n; j++)
                    { 
                        Array[j] = new int[m];
                        Total[j] = new int[m];
                        
                        for (int i = 0; i < m; i++)
                        {
                            Array[j][i] = random.Next(1,10);
                            Total[j][i] = Array[j][i] * a;
                        }
                    }

                    // вывод результата
                    // поиск строки, на которой будет выведен множитель
                    int a_output = (n % 2 == 0)?(n / 2):((n + 1) / 2);

                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine();

                        // вывод множителя
                        if (a_output - 1 == j)
                        {
                            Console.Write($"{a,5:0} * |");
                        }
                        else
                        {
                            Console.Write($"        |");   
                        }

                        // вывод начальной таблицы
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write($"{Array[j][i],3:0}");
                        }
                        
                        if (a_output - 1 == j)
                        {
                            Console.Write($" | = |");
                        }
                        else
                        {
                            Console.Write($" |   |");   
                        }
                        
                        // вывод итоговой таблицы
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write($"{Total[j][i],3:0}");
                        }

                        Console.Write($" |");
                    }
                }
                #endregion

                #region Задание 3.2. Сложение и вычитание матриц
                //
                // ** Задание 3.2
                // Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
                // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
                // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
                // Добавить возможность ввода количество строк и столцов матрицы.
                // Матрицы заполняются автоматически
                // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
                //
                // Пример
                //  |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
                //  |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
                //  |  5  3  1  |   |  3  6  7  |   |  8   9   8  |
                //  
                //  
                //  |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
                //  |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
                //  |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |
                //
                
                else if (item == 4)
                {
                    int n = 0;
                    int m = 0;
                    
                    while (true)
                    {
                        Console.WriteLine("3.2. Сложение и вычитание матриц");
                        
                        // запрос размера матрицы
                        Console.WriteLine("\nУкажите число строк: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Укажите число столбцов: ");
                        m = Convert.ToInt32(Console.ReadLine());

                        if (n != m)
                        {
                            Console.WriteLine("Складывать и вычитать можно только матрицы одинакового размера.");
                            Console.WriteLine("Попробуйте еще раз.\n");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }   
                    
                    // объявление 1-й матрицы
                    int[][] Array1 = new int[n][];

                    // объявление 2-й матрицы
                    int[][] Array2 = new int[n][];

                    // объявление 1-й итоговой матрицы
                    int[][] Total1 = new int[n][];

                    // объявление 2-й итоговой матрицы
                    int[][] Total2 = new int[n][];

                    // формирование матриц
                    for (int j = 0; j < n; j++)
                    { 
                        Array1[j] = new int[m];
                        Array2[j] = new int[m];

                        Total1[j] = new int[m];
                        Total2[j] = new int[m];

                        for (int i = 0; i < m; i++)
                        {
                            Array1[j][i] = random.Next(1,10);
                            Array2[j][i] = random.Next(1,10);
                            
                            // Расчет значений итоговых матриц    
                            Total1[j][i] = Array1[j][i] + Array2[j][i];
                            Total2[j][i] = Array1[j][i] - Array2[j][i];
                        }
                    }

                    // вывод результата
                    // поиск строки, на которой будут выводится знаки
                    int a_output = (n % 2 == 0)?(n / 2):((n + 1) / 2);
                    
                    Console.WriteLine();

                    // вывод операции сложения
                    Console.WriteLine("Сложение:");
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("\n|");
                        
                        // вывод первой начальной матрицы
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write($"{Array1[j][i],3:0}");
                        }
                        
                        // вывод знака сложения
                        if (a_output - 1 == j)
                        {
                            Console.Write(" | + |");
                        }
                        else
                        {
                            Console.Write(" |   |");   
                        }

                        // вывод второй начальной матрицы
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write($"{Array2[j][i],3:0}");
                        }
                        
                        // вывод знака равенства
                        if (a_output - 1 == j)
                        {
                            Console.Write(" | = |");
                        }
                        else
                        {
                            Console.Write(" |   |");   
                        }
                        
                        // вывод итоговой матрицы сложения
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write($"{Total1[j][i],3:0}");
                        }

                        Console.Write($" |");

                    }
                    Console.WriteLine("\n");

                    // вывод операции вычитания
                    Console.WriteLine("Вычитание:");

                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("\n|");
                        
                        // вывод первой начальной матрицы
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write($"{Array1[j][i],3:0}");
                        }
                        
                        // вывод знака вычитания
                        if (a_output - 1 == j)
                        {
                            Console.Write(" | - |");
                        }
                        else
                        {
                            Console.Write(" |   |");   
                        }

                        // вывод второй начальной матрицы
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write($"{Array2[j][i],3:0}");
                        }
                        
                        // вывод знака равенства
                        if (a_output - 1 == j)
                        {
                            Console.Write(" | = |");
                        }
                        else
                        {
                            Console.Write(" |   |");   
                        }
                        
                        // вывод итоговой матрицы вычитания
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write($"{Total2[j][i],3:0}");
                        }

                        Console.Write($" |");
                    }
                }
                #endregion

                #region Задание 3.3. Умножение матриц
                // *** Задание 3.3
                // Заказчику требуется приложение позволяющщее перемножать математические матрицы
                // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
                // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матриц
                // Добавить возможность ввода количество строк и столцов матрицы.
                // Матрицы заполняются автоматически
                // Если по введённым пользователем данным действие произвести нельзя - сообщить об этом
                //  
                //  |  1  3  5  |   |  1  3  4  |   | 22  48  57  |
                //  |  4  5  7  | х |  2  5  6  | = | 35  79  95  |
                //  |  5  3  1  |   |  3  6  7  |   | 14  36  45  |
                //
                //  
                //                  | 4 |   
                //  |  1  2  3  | х | 5 | = | 32 |
                //                  | 6 |  
                //
                
                else if (item == 5)
                {
                    int n1 = 0;
                    int n2 = 0;
                    int m1 = 0;
                    int m2 = 0;
                    
                    while (true)
                    {
                        Console.WriteLine("3.3. Умножение матриц");
                        
                        // запрос размера 1-й матрицы
                        Console.WriteLine("\nУкажите число строк 1-й матрицы: ");
                        n1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Укажите число столбцов 1-матрицы: ");
                        m1 = Convert.ToInt32(Console.ReadLine());

                        // запрос размера 2-й матрицы
                        Console.WriteLine("Укажите число строк 2-й матрицы: ");
                        n2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Укажите число столбцов 2-матрицы: ");
                        m2 = Convert.ToInt32(Console.ReadLine());

                        if (m1 != n2)
                        {
                            Console.WriteLine("Число столбцов 1-й матрицы должно быть равно числу строк 2-й матрицы.");
                            Console.WriteLine("Попробуйте еще раз.\n");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }   
                    
                    // объявление 1-й матрицы
                    int[][] Array1 = new int[n1][];

                    // объявление 2-й матрицы
                    int[][] Array2 = new int[n2][];

                    // объявление итоговой матрицы
                    int[][] Total = new int[n1][];

                    // формирование и вывод 1-й матрицы
                    Console.WriteLine("\nМатрица 1:");
                    for (int j = 0; j < n1; j++)
                    { 
                        Array1[j] = new int[m1];
                        
                        Console.Write("\n|");

                        for (int i = 0; i < m1; i++)
                        {
                            Array1[j][i] = random.Next(1,10);
                            Console.Write($"{Array1[j][i],3:0}");
                        }

                        Console.Write("  |");
                    }

                    // формирование и вывод 2-й матрицы
                    Console.WriteLine("\n\nМатрица 2:");
                    for (int j = 0; j < n2; j++)
                    { 
                        Array2[j] = new int[m2];
                        
                        Console.Write("\n|");

                        for (int i = 0; i < m2; i++)
                        {
                            Array2[j][i] = random.Next(1,10);
                            Console.Write($"{Array2[j][i],3:0}");
                        }

                        Console.Write("  |");
                    }

                    // Вывод результата
                    // Расчет умножения
                    Console.WriteLine("\n\nИтог умножения матриц:");
                    for (int j = 0; j < n1; j++)
                    { 
                        Total[j] = new int[m2];
                        Console.Write("\n|");

                        for (int i = 0; i < m2; i++)
                        {
                            int i2 = 0;
                            int sum = 0;

                            for (int k = 0; k < m1; k++)
                            { 
                                sum = sum + (Array1[j][k] * Array2[k][i]);
                            }
                            
                            Total[j][i] = sum;
                            Console.Write($"{Total[j][i],4:0}");
                        }
                        Console.Write("  |");
                    } 
                }
                #endregion

                else
                {
                    Console.WriteLine("Укажите верное значение");
                    Console.ReadKey();
                    continue;
                }
                
                Console.WriteLine("\n\nВернуться в меню? y/n");
                str = Console.ReadLine();

                if (str == "y")
                {
                    continue;
                }
                else
                {
                    break; 
                }
            }
        }
    }
}