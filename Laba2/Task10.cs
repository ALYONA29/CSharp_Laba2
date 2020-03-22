using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2
{
    class Task10
    {
        public void MethodFromTask10()
        {
            Console.WriteLine("Введите число : ");
            string str = "";
            StringBuilder strb = new StringBuilder(str);
            bool checkPoint = false;
            bool checkSymbol = false;
            bool checkIsEmpty = false;
            bool firstOrLast = false;
            while (checkPoint == false || checkSymbol == false || checkIsEmpty == false || firstOrLast == false)
            {
                str = Console.ReadLine();
                strb = new StringBuilder(str);
                checkPoint = PointCheck(strb);
                checkSymbol = SymbolCheck(strb);
                checkIsEmpty = StrIsEmpty(str);
                firstOrLast = FirstOrLast(strb, str);
                if (checkPoint == false || checkSymbol == false || (firstOrLast == false && checkIsEmpty == true))
                {
                    Console.WriteLine("Неверный ввод, попробуйте снова.");
                }
                if (checkIsEmpty == false)
                {
                    Console.WriteLine("Строка не была введена, пожалуйста, введите.");
                }
            }
            int index = 0;
            decimal num = 0;
            int count = 0;
            for (int i = 0; i < strb.Length; i++)
            {
                if (strb[i] == '.' || strb[i] == ',')
                {
                    index = i;
                    count++;
                    break;
                }
            }
            strb = strb.Replace(".", "");
            strb = strb.Replace(",", "");
            int x = 0;
            if (count == 0)
            {
                for (int i = 0; i < strb.Length; i++)
                {
                    int buf = strb[i] - '0';
                    num += Convert.ToDecimal(buf * Math.Pow(10, strb.Length - i - 1));
                }
            }
            else
            {
                for (int i = 0; i < strb.Length; i++)
                {
                    switch (strb[i])
                    {
                        case '1':
                            x = 1;
                            break;
                        case '2':
                            x = 2;
                            break;
                        case '3':
                            x = 3;
                            break;
                        case '4':
                            x = 4;
                            break;
                        case '5':
                            x = 5;
                            break;
                        case '6':
                            x = 6;
                            break;
                        case '7':
                            x = 7;
                            break;
                        case '8':
                            x = 8;
                            break;
                        case '9':
                            x = 9;
                            break;
                        case '0':
                            x = 10;
                            break;
                    }
                    if (x == 10 && (index - 1 - i) < 0)
                    {
                        continue;
                    }
                    else
                    {
                        num += Convert.ToDecimal(x * Math.Pow(10, index - 1 - i));
                    }
                }
            }
            Console.WriteLine("Вы ввели число : ");
            Console.WriteLine(num);
        }
        static bool SymbolCheck(StringBuilder strb)
        {
            int count = 0;
            for (int i = 0; i < strb.Length; i++)
            {
                if ((strb[i] < '0' || strb[i] > '9') && (strb[i] != ',' && strb[i] != '.'))
                {
                    count++;
                }
            }
            if (count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool PointCheck(StringBuilder strb)
        {
            int count = 0;
            for (int i = 0; i < strb.Length; i++)
            {
                if (strb[i] == '.' || strb[i] == ',')
                {
                    count++;
                }
            }
            if (count > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool StrIsEmpty(string str)
        {
            if (str == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool FirstOrLast(StringBuilder strb, string str)
        {
            if (StrIsEmpty(str) == false)
            {
                return false;
            }
            else if ((strb[0] == ',' || strb[0] == '.') && StrIsEmpty(str) == true)
            {
                return false;
            }
            else if ((strb[strb.Length - 1] == ',' || strb[strb.Length - 1] == '.') && StrIsEmpty(str) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
