using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2
{
    class Task5
    {
        public void MethodFromTask5()
        {
            int count = 0;
            string str1;
            Console.WriteLine("Введите строку : ");
            str1 = Console.ReadLine();
            while (str1 == "")
            {
                Console.WriteLine("Строка не была введена, введите");
                str1 = Console.ReadLine();
            }
            StringBuilder str2 = new StringBuilder(str1);
            string A = "A";
            int code1 = char.ConvertToUtf32(A, 0);
            string Z = "Z";
            int code2 = char.ConvertToUtf32(Z, 0);
            Console.WriteLine("Заглавные буквы, не входящие в английский алфавит:");
            for (int i = 0; i <= (str2.Length - 1); i++)
            {
                char buff = str2[i];
                int code = Convert.ToInt32(buff);
                if (char.IsUpper(buff))
                {
                    if (code <= code2 && code >= code1)
                    {
                        continue;
                    }
                    else
                    {
                        Console.Write(buff + " ");
                        count++;
                    }
                }
            }
            if (count == 0)
                Console.WriteLine("Нет таких букв");
        }
    }
}
