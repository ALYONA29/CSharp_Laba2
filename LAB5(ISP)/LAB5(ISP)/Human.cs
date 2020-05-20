using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace _ИСП_ЛР3
{
    abstract class Human
    {
        protected int ide;
        protected string name;
        protected string surname;
        protected string patronymic;
        protected int age;
        protected decimal height;
        protected decimal weight;
        protected string pol;


        public Human[] humans = new Human[50];

        public Human this[int index]
        {
            get

            {
                return humans[index];
            }

            set
            {
                humans[index] = value;
            }
        }

        public static int count = 1;
        public static int deleteCheck = 0;
        public static bool deleteOne = false;
        public int Ide
        {
            get
            {
                return ide;
            }
            set
            {

                ide = count;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }

        public string Patronymic
        {
            get
            {
                return patronymic;
            }
            set
            {
                patronymic = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Возраст указан неверно");
                }
                else
                {
                    age = value;
                }
            }
        }

        public decimal Height
        {
            get
            {
                return height;
            }
            set
            {

                if (value <= 0)
                {
                    Console.WriteLine("Рост указан неверно");
                }
                else
                {
                    height = value;
                }
            }
        }

        public decimal Weight
        {
            get
            {
                return weight;
            }
            set
            {

                if (value <= 0)
                {
                    Console.WriteLine("Вес указан неверно");
                }
                else
                {
                    weight = value;
                }
            }
        }

        public string Pol
        {
            get
            {
                return pol;
            }
            set
            {

                pol = value;
            }
        }

        public virtual void Search(Human humans, int size, int choice)
        {
            int checker = 0;
            for (int i = 0; i < size; i++)
            {
                if (humans[i].age == choice)
                {
                    humans[i].Print();
                    checker++;
                }
            }
            if (checker == 0)
            {
                Console.WriteLine("Нет таких людей");
            }
        }

        public static void Search(Human humans, int size, decimal height)
        {
            int checker = 0;
            for (int i = 0; i < size; i++)
            {
                if (humans[i].height == height)
                {
                    humans[i].Print();
                    checker++;
                }
            }
            if (checker == 0)
            {
                Console.WriteLine("Нет таких людей");
            }
        }

        public static void SortByAge(Human humans, int size)
        {
            Human temp;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (humans[i].age > humans[j].age)
                    {
                        temp = humans[i];
                        humans[i] = humans[j];
                        humans[j] = temp;
                    }
                }
            }
        }

        public static void SortByHeight(Human humans, int size)
        {
            Human temp;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (humans[i].height > humans[j].height)
                    {
                        temp = humans[i];
                        humans[i] = humans[j];
                        humans[j] = temp;
                    }
                }
            }
        }

        public virtual void SearchByIde(Human humans, int size, int choiceIde)
        {
            int checker = 0;
            for (int i = 0; i < size; i++)
            {
                if (humans[i].ide == choiceIde)
                {
                    humans[i].Print();
                    checker++;
                }
            }
            if (checker == 0)
            {
                Console.WriteLine("Нет такого личного дела");
            }
        }

        public abstract void Print();

        public Human()
        {

        }

        public Human(int ide, string surname, string name, string patronymic, string pol, int age, decimal height, decimal weight)
        {
            this.ide = ide;
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.pol = pol;
            this.age = age;
            this.height = height;
            this.weight = weight;
            count++;
        }

        public virtual void Add()
        {
            int buf = deleteCheck + count;
            Console.WriteLine("Личное дело номер " + buf);
            this.ide = buf;
            Console.WriteLine("Введите фамилию(на русском) : ");
            string input = Console.ReadLine();
            while (!CheckStr(input))
            {
                Console.WriteLine("Введите данные снова");
                input = Console.ReadLine();
            }
            this.surname = input;
            Console.WriteLine("Введите имя(на русском) : ");
            input = Console.ReadLine();
            while (!CheckStr(input))
            {
                Console.WriteLine("Введите данные снова");
                input = Console.ReadLine();
            }
            this.name = input;
            Console.WriteLine("Введите отчество(на русском) : ");
            input = Console.ReadLine();
            while (!CheckStr(input))
            {
                Console.WriteLine("Введите данные снова");
                input = Console.ReadLine();
            }
            this.patronymic = input;
            Console.WriteLine("Введите возраст : ");
            string choiceInputAge = Console.ReadLine();
            int ageChoice;
            while (!(Int32.TryParse(choiceInputAge, out ageChoice)) || ageChoice <= 0)
            {
                Console.WriteLine("Неверный ввод возраста, попробуйте снова : ");
                choiceInputAge = Console.ReadLine();
            }
            this.age = ageChoice;
            Console.WriteLine("Введите рост : ");
            string choiceInputHeight = Console.ReadLine();
            decimal heightChoice;
            while (!(Decimal.TryParse(choiceInputHeight, out heightChoice)) || heightChoice <= 0)
            {
                Console.WriteLine("Неверный ввод роста, попробуйте снова : ");
                choiceInputHeight = Console.ReadLine();
            }
            this.height = heightChoice;
            Console.WriteLine("Введите вес : ");
            string choiceInputWeight = Console.ReadLine();
            decimal weightChoice;
            while (!(Decimal.TryParse(choiceInputWeight, out weightChoice)) || weightChoice <= 0)
            {
                Console.WriteLine("Неверный ввод веса, попробуйте снова : ");
                choiceInputWeight = Console.ReadLine();
            }
            this.weight = weightChoice;
            Console.WriteLine("Введите пол : ");
            Console.WriteLine("1 - мужской");
            Console.WriteLine("2 - женский");
            string choiceInputPol = Console.ReadLine();
            int polChoice;
            while (!(Int32.TryParse(choiceInputPol, out polChoice)) || (polChoice != 1 && polChoice != 2))
            {
                Console.WriteLine("Неверный ввод, попробуйте снова : ");
                choiceInputPol = Console.ReadLine();
            }
            if (polChoice == 1)
            {
                this.pol = "мужской";
            }
            if (polChoice == 2)
            {
                this.pol = "женский";
            }
            count++;
        }
        public static void Swap(Human human1, Human human2)
        {
            Human human;
            human = human1;
            human1 = human2;
            human2 = human;

        }
        public static bool CheckStr(string str)
        {
            bool check = false;
            if (str == "")
            {
                Console.WriteLine("Данные не были введены");
                return check;
            }
            int count = 0;
            int len = str.Length;
            for (int i = 0; i < len; i++)
            {
                if ((str[i] >= 'А' && str[i] <= 'Я') || (str[i] >= 'а' && str[i] <= 'я'))
                {
                    count++;
                }
            }
            if (count == len)
            {
                check = true;
            }
            return check;
        }
    }
}