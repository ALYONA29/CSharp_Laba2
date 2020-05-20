using System;
using System.Collections.Generic;
using System.Numerics;

namespace LAB7_demo_
{
    class Program
    {
        static void Main(string[] args)
        {
			List<Rational> nums = new List<Rational>()
			{
				new Rational(10, 13),
				new Rational(21),
				Rational.Parse("a", "-5/6"),
				Rational.Parse("b", "13"),
				Rational.Parse("b", "0/2"),
				Rational.Parse("c", "4 17/28"),
				Rational.Parse("d", "-4 1/5"),
				Rational.Parse("e", "0.155"),
				Rational.Parse("f", "0.5(3)"),
				Rational.Parse("f", "1.291(6)"),
				Rational.Parse("0.(36)"),
				Rational.Parse("0.919"),
				Rational.Parse("-3/9"),
				Rational.Parse("2.57(3)"),
				Rational.Parse("-10 10/11"),
			};
			while (true)
			{
				Console.WriteLine("Выберите действие:");
				Console.WriteLine("1) Показать все числа");
				Console.WriteLine("2) Показать все числа в определенном формате");
				Console.WriteLine("3) Добавить число");
				Console.WriteLine("4) Удалить число");
				Console.WriteLine("5) Удалить все числа");
				Console.WriteLine("6) Сортировать");
				Console.WriteLine("7) Сложение");
				Console.WriteLine("8) Вычитание");
				Console.WriteLine("9) Умножение");
				Console.WriteLine("10) Деление");
				Console.WriteLine("11) Сравнение");
				Console.WriteLine("12) выход");
				Console.WriteLine();
				int choice;
				while (!Int32.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 12)
				{
					Console.WriteLine("Неверный ввод, пожалуйста, попробуйте снова");
				}
				switch (choice)
				{
					case 1:
					{
						Console.WriteLine("Все числа:");
						for (int i = 0; i < nums.Count; i++)
						{
							Console.WriteLine(i + 1 + ") " + nums[i]);
						}
						break;
					}
					case 2:
					{
						Console.WriteLine("Выберите формат:");
						Console.WriteLine("a) m/n");
						Console.WriteLine("b) m/n or n");
						Console.WriteLine("c) a m/n");
						Console.WriteLine("d) c or b");
						Console.WriteLine("e) Непериодическая дробь");
						Console.WriteLine("f) Периодическая или непериодическая дробь");
						Console.WriteLine("long) Целое число");
						Console.WriteLine("dec) Десятичная дробь");
						string chosen = Console.ReadLine();
						Console.WriteLine();
						if (chosen == "a" || chosen == "b" || chosen == "c" || chosen == "d" || chosen == "e" || chosen == "f")
						{
							Console.WriteLine("Все числа:");
							for (int i = 0; i < nums.Count; i++)
							{
								Console.WriteLine(i + 1 + ") " + nums[i].ToString(chosen));
							}
						}
						else if (chosen == "long")
						{
							Console.WriteLine("Все числа:");
							for (int i = 0; i < nums.Count; i++)
							{
								Console.WriteLine(i + 1 + ") " + (long)nums[i]);
							}
						}
						else if (chosen == "dec")
						{
							Console.WriteLine("Все числа:");
							for (int i = 0; i < nums.Count; i++)
							{
								Console.WriteLine(i + 1 + ") " + (decimal)nums[i]);
							}
						}
						else
						{
							Console.WriteLine("Такого формата нет");
						}
						break;
					}
					case 3:
					{
						Console.WriteLine("Пожалуйста, введите рациональное число в любом формате");
						Rational a;
						if (!Rational.TryParse(Console.ReadLine(), out a))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
						}
						else
						{
							nums.Add(a);
							Console.WriteLine("Успешно");
						}
						break;
					}
					case 4:
					{
						Console.WriteLine("Пожалуйста, введите рациональное число в любом формате");
						Rational a;
						if (!Rational.TryParse(Console.ReadLine(), out a))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
						}
						else if (nums.Remove(a))
						{
							Console.WriteLine("Успешно");
						}
						else
						{
							Console.WriteLine("Такое число не найдено");
						}
						break;
					}
					case 5:
					{
						nums.Clear();
						Console.WriteLine("Успешно");
						break;
					}
					case 6:
					{
						nums.Sort();
						Console.WriteLine("Успешно");
						break;
					}
					case 7:
					{
						Console.WriteLine("Пожалуйста, введите первое рациональное число в любом формате");
						Rational first;
						if (!Rational.TryParse(Console.ReadLine(), out first))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
							continue;
						}
						Console.WriteLine("Пожалуйста, введите второе рациональное число в любом формате");
						Rational second;
						if (!Rational.TryParse(Console.ReadLine(), out second))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
							continue;
						}
						Console.WriteLine();
						if (second > 0)
						{
							Console.WriteLine(first + " + " + second + " = " + (first + second));
						}
						else
						{
							Console.WriteLine(first + " + (" + second + ") = " + (first + second));
						}
						break;
					}
					case 8:
					{
						Console.WriteLine("Пожалуйста, введите первое рациональное число в любом формате");
						Rational first;
						if (!Rational.TryParse(Console.ReadLine(), out first))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
							continue;
						}
						Console.WriteLine("Пожалуйста, введите второе рациональное число в любом формате");
						Rational second;
						if (!Rational.TryParse(Console.ReadLine(), out second))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
							continue;
						}
						Console.WriteLine();
						if (second > 0)
						{
							Console.WriteLine(first + " - " + second + " = " + (first - second));
						}
						else
						{
							Console.WriteLine(second + " - (" + second + ") = " + (first - second));
						}
						break;
					}
					case 9:
					{
						Console.WriteLine("Пожалуйста, введите первое рациональное число в любом формате");
						Rational first;
						if (!Rational.TryParse(Console.ReadLine(), out first))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
							continue;
						}
						Console.WriteLine("Пожалуйста, введите второе рациональное число в любом формате");
						Rational second;
						if (!Rational.TryParse(Console.ReadLine(), out second))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
							continue;
						}
						Console.WriteLine();
						if (second > 0)
						{
							Console.WriteLine(first + " * " + second + " = " + (first * second));
						}
						else
						{
							Console.WriteLine(first + " * (" + second + ") = " + (first * second));
						}
						break;
					}
					case 10:
					{
						Console.WriteLine("Пожалуйста, введите первое рациональное число в любом формате");
						Rational first;
						if (!Rational.TryParse(Console.ReadLine(), out first))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
							continue;
						}
						Console.WriteLine("Пожалуйста, введите второе рациональное число в любом формате");
						Rational second;
						if (!Rational.TryParse(Console.ReadLine(), out second))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
							continue;
						}
						Console.WriteLine();
						if (second > 0)
						{
							if (second == 0)
							{
								Console.WriteLine("Деление на ноль недоступно");
							}
							else
							{
								Console.WriteLine(first + " / " + second + " = " + (first / second));
							}
						}
						else
						{
							if (second == 0)
							{
					     		Console.WriteLine("Деление на ноль недоступно");
							}
							else
							{
								Console.WriteLine(first + " / (" + second + ") = " + (first / second));
							}
						}
						break;
					}
					case 11:
					{
						Console.WriteLine("Пожалуйста, введите первое рациональное число в любом формате");
						Rational first;
						if (!Rational.TryParse(Console.ReadLine(), out first))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
							continue;
						}
						Console.WriteLine("Пожалуйста, введите второе рациональное число в любом формате");
						Rational second;
						if (!Rational.TryParse(Console.ReadLine(), out second))
						{
							Console.WriteLine("Ошибка, невозможно преобразовать в рациональное число");
							continue;
						}
						Console.WriteLine();
						if (first > second)
						{
							Console.WriteLine(first + " > " + second);
							Console.WriteLine(first.ToString("d") + " > " + second.ToString("d"));
							Console.WriteLine(first.ToString("f") + " > " + second.ToString("f"));
						}
						else if (first < second)
						{
							Console.WriteLine(first + " < " + second);
							Console.WriteLine(first.ToString("d") + " < " + second.ToString("d"));
							Console.WriteLine(first.ToString("f") + " < " + second.ToString("f"));
						}
						else
						{
							Console.WriteLine(first + " = " + second);
							Console.WriteLine(first.ToString("d") + " = " + second.ToString("d"));
							Console.WriteLine(first.ToString("f") + " = " + second.ToString("f"));
						}
						break;
					}
					default:
					{
						return;
					}
				}
				Console.WriteLine();
			}

		}
	}
}
