using _ИСП_ЛР3;
using System;
using System.Collections.Generic;
using System.Text;

namespace LAB5_ISP_
{
    class Student : Human
    {
        public enum Faculties
        {
            ФКСиС,
            ФИТУ,
            ФРЭ
        }
        protected string university = "БГУИР";
        protected Faculties faculty;
        protected int course;

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
        public string University
        {
            get
            {
                return university;
            }
            set
            {
                university = value;
            }
        }
        public override void Add()
        {
            base.Add();
            Console.WriteLine("Выберите факультет : ");
            Console.WriteLine("1) ФКСиС");
            Console.WriteLine("2) ФИТУ");
            Console.WriteLine("3) ФРЭ");
            string inputChoice = Console.ReadLine();
            int choice;
            while (!(Int32.TryParse(inputChoice, out choice)) || choice <= 0 || choice > 3)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова : ");
                inputChoice = Console.ReadLine();
            }
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
            Console.WriteLine("Введите курс : ");
            string choiceInputCourse = Console.ReadLine();
            int courseChoice;
            while (!(Int32.TryParse(choiceInputCourse, out courseChoice)) || courseChoice <= 0 || courseChoice > 5)
            {
                Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
                choiceInputCourse = Console.ReadLine();
            }
            this.course = courseChoice;
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
            Console.WriteLine("Университет : " + university);
            Console.WriteLine("Факультет : " + faculty);
            Console.WriteLine("Курс : " + course);
            Console.WriteLine("---------------------------------");
        }
    }
}
