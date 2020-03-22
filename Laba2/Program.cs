using System;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите задание : ");
            Console.WriteLine("1) Задание 5 : ");
            Console.WriteLine("2) Задание 10 : ");
            Console.WriteLine("3) Задание 15 : ");
            Console.WriteLine("4) Выход : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Task5 task5 = new Task5();
                    task5.MethodFromTask5();
                    break;
                case 2:
                    Task10 task10 = new Task10();
                    task10.MethodFromTask10();
                    break;
                case 3:
                    Task15 task15 = new Task15();
                    task15.MethodFromTask15();
                    break;
                case 4:
                    Console.WriteLine("Программа завершена");
                    break;
                default:
                    Console.WriteLine("Неверный ввод, попробуйте снова");
                    break;
            }

        }
    }
}
