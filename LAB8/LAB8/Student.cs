﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LAB8
{
    public interface IArOperation
    {
        void SearchBySurname(int size, string choice);
        bool IsRecovered(int index);
        public const string university = "БГУИР";
    }
    public interface IGroupOperations
    {
        bool IsMonitor(int index);
        bool MonitorCheck(object obj, int size, int group);
        string Monitor { get; set; }
        void SortByGroups(object obj, int size);
        void FindMonitor(object obj, int size, int choice);
    }
    class Student : Human, IArOperation
    {
        public enum Faculties
        {
            ФКСиС,
            ФИТУ,
            ФРЭ
        }
        protected Faculties faculty;
        protected int course;
        protected string recover;

        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;
        public delegate decimal Minimum(Student students, int size);
        public event Minimum Min;

        public Student[] students = new Student[50];

        public new Student this[int index]
        {
            get

            {
                return students[index];
            }

            set
            {
                students[index] = value;
            }
        }
        public int Course
        {
            get
            {
                return course;
            }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("Курс указан неверно");
                }
                else if (value > 5)
                {
                    Console.WriteLine("Курс указан неверно");
                }
                else
                {
                    course = value;
                }
            }
        }

        public Faculties Faculty
        {
            get
            {
                return faculty;
            }
            set
            {
                faculty = value;
            }
        }
        public string Recover
        {
            get
            {
                return recover;
            }
            set
            {
                recover = value;
            }
        }
        public virtual int Compare(object obj1, object obj2)
        {
            Student m1 = (Student)obj1;
            Student m2 = (Student)obj2;
            return String.Compare(m1.recover, m2.recover);
        }
        public virtual void SearchBySurname(int size, string choice)
        {
            int checker = 0;
            for (int i = 0; i < size; i++)
            {
                if (students[i].surname == choice)
                {
                    students[i].Print();
                    checker++;
                }
            }
            if (checker == 0)
            {
                Console.WriteLine("Нет такого личного дела");
            }
        }
        public bool IsRecovered(int index)
        {
            if (index == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Add()
        {
            base.Add();
            bool check = true;
            while (check)
            {
                try
                {
                    Console.WriteLine("Выберите факультет : ");
                    Console.WriteLine("1) ФКСиС");
                    Console.WriteLine("2) ФИТУ");
                    Console.WriteLine("3) ФРЭ");
                    string inputChoice = Console.ReadLine();
                    int choice;
                    if (!(Int32.TryParse(inputChoice, out choice)))
                    {
                        throw new Exception("не является целым числом");
                    }
                    if (choice >= 4)
                    {
                        throw new Exception("число больше 3");
                    }
                    if (choice <= 0)
                    {
                        throw new Exception("не натуральное число");
                    }
                    check = false;
                    switch (choice)
                    {
                        case 1:
                            this.faculty = Faculties.ФКСиС;
                            break;
                        case 2:
                            this.faculty = Faculties.ФИТУ;
                            break;
                        case 3:
                            this.faculty = Faculties.ФРЭ;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
            check = true;
            while (check)
            {
                try
                {
                    Console.WriteLine("Введите курс : ");
                    string choiceInputCourse = Console.ReadLine();
                    int courseChoice;
                    if (!(Int32.TryParse(choiceInputCourse, out courseChoice)))
                    {
                        throw new Exception("не является целым числом");
                    }
                    if (courseChoice >= 6)
                    {
                        throw new Exception("есть только 5 курсов");
                    }
                    if (courseChoice <= 0)
                    {
                        throw new Exception("курс не может быть отрицательным числом");
                    }
                    check = false;
                    this.course = courseChoice;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
            check = true;
            while (check)
            {
                try
                {
                    Console.WriteLine("Является ли восстановившимся : ");
                    Console.WriteLine("1) Да");
                    Console.WriteLine("2) Нет");
                    string choiceInputRecover = Console.ReadLine();
                    int recoverChoice;
                    if (!(Int32.TryParse(choiceInputRecover, out recoverChoice)))
                    {
                        throw new Exception("не является целым числом");
                    }
                    if (recoverChoice >= 3)
                    {
                        throw new Exception("число больше 2");
                    }
                    if (recoverChoice <= 0)
                    {
                        throw new Exception("не натуральное число");
                    }
                    check = false;
                    bool isRecoved = IsRecovered(recoverChoice);
                    if (isRecoved)
                    {
                        this.recover = "да";
                    }
                    else
                    {
                        this.recover = "нет";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
        }
        public static void SearchByIdeStud(Student students, int size, int choiceIde)
        {
            int checker = 0;
            for (int i = 0; i < size; i++)
            {
                if (students[i].ide == choiceIde)
                {
                    students[i].Print();
                    checker++;
                }
            }
            if (checker == 0)
            {
                Console.WriteLine("Нет такого личного дела");
            }
        }
        public static void SearchByCourseStud(Student students, int size, int choiceCourse)
        {
            int checker = 0;
            for (int i = 0; i < size; i++)
            {
                if (students[i].course == choiceCourse)
                {
                    students[i].Print();
                    checker++;
                }
            }
            if (checker == 0)
            {
                Console.WriteLine("Нет такого личного дела");
            }
        }
        public static void SortByAgeStud(Student students, int size)
        {
            Student temp;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (students[i].age > students[j].age)
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
            students.Notify = delegate (string mes)
            {
                Console.WriteLine(mes);
            };
            students.Notify?.Invoke($"Отсортировано");
            Console.WriteLine("Минимальный возраст : ");
            students.Min = (x, y) =>
            {
                decimal min = x[0].age;
                for (int i = 1; i < y; i++)
                {
                    if (x[i].age < min)
                    {
                        min = x[i].age;
                    }
                }
                return min;
            };
            decimal res = students.Min.Invoke(students, size);
            Console.WriteLine(res);
        }
        public override void Print()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Номер личного дела : " + ide);
            Console.WriteLine("Фамилия : " + surname);
            Console.WriteLine("Имя : " + name);
            Console.WriteLine("Отчество : " + patronymic);
            Console.WriteLine("Пол : " + pol);
            Console.WriteLine("Возраст : " + age);
            Console.WriteLine("Рост : " + height);
            Console.WriteLine("Вес : " + weight);
            Console.WriteLine("Университет : " + IArOperation.university);
            Console.WriteLine("Факультет : " + faculty);
            Console.WriteLine("Курс : " + course);
            Console.WriteLine("Восстановившийся : " + recover);
            Console.WriteLine("---------------------------------");
        }
    }
}
