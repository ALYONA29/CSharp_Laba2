using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2
{
    class Task15
    {
        public void MethodFromTask15()
        {
            string str1;
            Console.WriteLine("Введите строку, состоящую из строчных английских букв : ");
            str1 = Console.ReadLine();
            while (str1 == "")
            {
                Console.WriteLine("Строка не была введена, введите");
                str1 = Console.ReadLine();
            }
            StringBuilder str2 = new StringBuilder(str1);
            int check = 0;
            int checker = 0;
            for (int i = (str2.Length - 1); i >= 0; i--)
            {
                char buff = str2[i];
                int code = Convert.ToInt32(buff);
                if (code < 'a' || code > 'z')
                {
                    checker++;
                    while (checker > 0)
                    {
                        checker = 0;
                        Console.WriteLine("Неверный ввод строки");
                        str1 = Console.ReadLine();
                        while (str1 == "")
                        {
                            Console.WriteLine("Строка не была введена, введите");
                            str1 = Console.ReadLine();
                        }
                        str2 = new StringBuilder(str1);
                        for (i = (str2.Length - 1); i > 0; i--)
                        {
                            buff = str2[i];
                            code = Convert.ToInt32(buff);
                            if (code < 'a' || code > 'z')
                            {
                                checker++;
                            }
                        }
                    }
                }
            }
            for (int i = (str2.Length - 1); i > 0; i--)
            {
                char buff = str2[i];
                int code = Convert.ToInt32(buff);
                if (str2[i - 1] == 'a' || str2[i - 1] == 'e' || str2[i - 1] == 'y' || str2[i - 1] == 'u' || str2[i - 1] == 'i' || str2[i - 1] == 'o')
                {
                    check++;
                    if (str2[i] == 'z')
                    {
                        str2[i] = 'a';
                    }
                    else
                    {
                        int code_new = code + 1;
                        str2[i] = Convert.ToChar(code_new);
                    }
                }
            }
            if (check == 0)
            {
                Console.WriteLine("Замен нет");
            }
            else
            {
                Console.WriteLine("Новая строка : ");
                for (int j = 0; j < str2.Length; j++)
                {
                    Console.Write(str2[j]);
                }
                Console.WriteLine();
            }
        }
    }
}
