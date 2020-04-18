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
            Console.WriteLine("Введите фамилию : ");
            string input = Console.ReadLine();
            while (!CheckStr(input))
            {
                Console.WriteLine("Введите данные снова");
                input = Console.ReadLine();
            }
            this.surname = input;
            Console.WriteLine("Введите имя : ");
            input = Console.ReadLine();
            while (!CheckStr(input))
            {
                Console.WriteLine("Введите данные снова");
                input = Console.ReadLine();
            }
            this.name = input;
            Console.WriteLine("Введите отчество : ");
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
                Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
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
    class KSiS : Student
    {
        public enum Specials
        {
            ИиТП,
            ПОИТ,
            ВМСиС,
            ЭВС
        }
        protected int group;
        protected Specials special;
        protected struct Gpa
        {
            public decimal firstSemester;
            public decimal secondSemester;
            public decimal Total()
            {
                return (firstSemester + secondSemester) / 2;
            }
        }

        Gpa current;

        public KSiS[] stud = new KSiS[50];

        public new KSiS this[int index]
        {
            get

            {
                return stud[index];
            }

            set
            {
                stud[index] = value;
            }
        }
        public int Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }

        public Specials Spec
        {
            get
            {
                return special;
            }
            set
            {
                special = value;
            }
        }
        public static void SortByGpa(KSiS students, int size)
        {
            KSiS temp;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (students[i].current.Total() > students[j].current.Total())
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }
        public override void Add()
        {
            int buf = deleteCheck + count;
            Console.WriteLine("Личное дело номер " + buf);
            this.ide = buf;
            Console.WriteLine("Введите фамилию : ");
            string input = Console.ReadLine();
            while (!CheckStr(input))
            {
                Console.WriteLine("Введите данные снова");
                input = Console.ReadLine();
            }
            this.surname = input;
            Console.WriteLine("Введите имя : ");
            input = Console.ReadLine();
            while (!CheckStr(input))
            {
                Console.WriteLine("Введите данные снова");
                input = Console.ReadLine();
            }
            this.name = input;
            Console.WriteLine("Введите отчество : ");
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
         
            this.faculty = Faculties.ФКСиС;
            Console.WriteLine("Введите курс : ");
            string choiceInputCourse = Console.ReadLine();
            int courseChoice;
            while (!(Int32.TryParse(choiceInputCourse, out courseChoice)) || courseChoice <= 0 || courseChoice > 5)
            {
                Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
                choiceInputCourse = Console.ReadLine();
            }
            this.course = courseChoice;
            Console.WriteLine("Выберите специальность : ");
            Console.WriteLine("1) ИиТП");
            Console.WriteLine("2) ПОИТ");
            Console.WriteLine("3) ВМСиС");
            Console.WriteLine("4) ЭМС");
            string inputChoice = Console.ReadLine();
            int choice;
            while (!(Int32.TryParse(inputChoice, out choice)) || choice <= 0 || choice > 4)
            {
                Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
                inputChoice = Console.ReadLine();
            }
            switch (choice)
            {
                case 1:
                    this.special = Specials.ИиТП;
                    break;
                case 2:
                    this.special = Specials.ПОИТ;
                    break;
                case 3:
                    this.special = Specials.ВМСиС;
                    break;
                case 4:
                    this.special = Specials.ЭВС;
                    break;
            }
            Console.WriteLine("Введите группу : ");
            string choiceInputGroup = Console.ReadLine();
            int groupChoice;
            while (!(Int32.TryParse(choiceInputGroup, out groupChoice)) || groupChoice <= 0)
            {
                Console.WriteLine("Неверный ввод группы, попробуйте снова : ");
                choiceInputGroup = Console.ReadLine();
            }
            this.group = groupChoice;
            Console.WriteLine("Введите средний балл за первый семестр : ");
            choiceInputGroup = Console.ReadLine();
            int firstChoice;
            while (!(Int32.TryParse(choiceInputGroup, out firstChoice)) || firstChoice <= 0 || firstChoice > 10)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова : ");
                choiceInputGroup = Console.ReadLine();
            }
            current.firstSemester = firstChoice;
            Console.WriteLine("Введите средний балл за второй семестр : ");
            choiceInputGroup = Console.ReadLine();
            int secondChoice;
            while (!(Int32.TryParse(choiceInputGroup, out secondChoice)) || secondChoice <= 0 || secondChoice > 10)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова : ");
                choiceInputGroup = Console.ReadLine();
            }
            current.secondSemester = secondChoice;
            count++;
        }
        public static void SortByAgeStud(KSiS students, int size)
        {
            KSiS temp;
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
        public static void SearchByCourseStud(KSiS students, int size, int choiceCourse)
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
        public static void SearchByIdeStud(KSiS students, int size, int choiceIde)
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
            Console.WriteLine("Специальность : " + special);
            Console.WriteLine("Группа : " + group);
            Console.WriteLine("Средний балл за первый семестр : " + current.firstSemester);
            Console.WriteLine("Средний балл за второй семестр : " + current.secondSemester);
            Console.WriteLine("Итоговый средний балл : " + current.Total());
            Console.WriteLine("---------------------------------");
        }
    }
    class FITU : Student
    {
        public enum Specials
        {
            АСОИ,
            ИИ,
            ПЭ,
            ИТиУвТС
        }
        protected int group;
        protected Specials special;
        protected struct Gpa
        {
            public decimal firstSemester;
            public decimal secondSemester;
            public decimal Total()
            {
                return (firstSemester + secondSemester) / 2;
            }
        }

        Gpa current;

        public FITU[] stud = new FITU[50];

        public new FITU this[int index]
        {
            get

            {
                return stud[index];
            }

            set
            {
                stud[index] = value;
            }
        }
        public int Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }

        public Specials Spec
        {
            get
            {
                return special;
            }
            set
            {
                special = value;
            }
        }
        public static void SortByGpa(FITU students, int size)
        {
            FITU temp;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (students[i].current.Total() > students[j].current.Total())
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }
        public override void Add()
        {
            int buf = deleteCheck + count;
            Console.WriteLine("Личное дело номер " + buf);
            this.ide = buf;
            Console.WriteLine("Введите фамилию : ");
            string input = Console.ReadLine();
            while (!CheckStr(input))
            {
                Console.WriteLine("Введите данные снова");
                input = Console.ReadLine();
            }
            this.surname = input;
            Console.WriteLine("Введите имя : ");
            input = Console.ReadLine();
            while (!CheckStr(input))
            {
                Console.WriteLine("Введите данные снова");
                input = Console.ReadLine();
            }
            this.name = input;
            Console.WriteLine("Введите отчество : ");
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

            this.faculty = Faculties.ФИТУ;
            Console.WriteLine("Введите курс : ");
            string choiceInputCourse = Console.ReadLine();
            int courseChoice;
            while (!(Int32.TryParse(choiceInputCourse, out courseChoice)) || courseChoice <= 0 || courseChoice > 5)
            {
                Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
                choiceInputCourse = Console.ReadLine();
            }
            this.course = courseChoice;
            Console.WriteLine("Выберите специальность : ");
            Console.WriteLine("1) АСОИ");
            Console.WriteLine("2) ИИ");
            Console.WriteLine("3) ПЭ");
            Console.WriteLine("4) ИТиУвТС");
            string inputChoice = Console.ReadLine();
            int choice;
            while (!(Int32.TryParse(inputChoice, out choice)) || choice <= 0 || choice > 4)
            {
                Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
                inputChoice = Console.ReadLine();
            }
            switch (choice)
            {
                case 1:
                    this.special = Specials.АСОИ;
                    break;
                case 2:
                    this.special = Specials.ИИ;
                    break;
                case 3:
                    this.special = Specials.ПЭ;
                    break;
                case 4:
                    this.special = Specials.ИТиУвТС;
                    break;
            }
            Console.WriteLine("Введите группу : ");
            string choiceInputGroup = Console.ReadLine();
            int groupChoice;
            while (!(Int32.TryParse(choiceInputGroup, out groupChoice)) || groupChoice <= 0)
            {
                Console.WriteLine("Неверный ввод группы, попробуйте снова : ");
                choiceInputGroup = Console.ReadLine();
            }
            this.group = groupChoice;
            Console.WriteLine("Введите средний балл за первый семестр : ");
            choiceInputGroup = Console.ReadLine();
            int firstChoice;
            while (!(Int32.TryParse(choiceInputGroup, out firstChoice)) || firstChoice <= 0 || firstChoice > 10)
            {
                Console.WriteLine("Неверный ввод группы, попробуйте снова : ");
                choiceInputGroup = Console.ReadLine();
            }
            current.firstSemester = firstChoice;
            Console.WriteLine("Введите средний балл за второй семестр : ");
            choiceInputGroup = Console.ReadLine();
            int secondChoice;
            while (!(Int32.TryParse(choiceInputGroup, out secondChoice)) || secondChoice <= 0 || secondChoice > 10)
            {
                Console.WriteLine("Неверный ввод группы, попробуйте снова : ");
                choiceInputGroup = Console.ReadLine();
            }
            current.secondSemester = secondChoice;
            count++;
        }
        public static void SortByAgeStud(FITU students, int size)
        {
            FITU temp;
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
        public static void SearchByCourseStud(FITU students, int size, int choiceCourse)
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
        public static void SearchByIdeStud(FITU students, int size, int choiceIde)
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
            Console.WriteLine("Специальность : " + special);
            Console.WriteLine("Группа : " + group);
            Console.WriteLine("Средний балл за первый семестр : " + current.firstSemester);
            Console.WriteLine("Средний балл за второй семестр : " + current.secondSemester);
            Console.WriteLine("Итоговый средний балл : " + current.Total());
            Console.WriteLine("---------------------------------");
        }
    }
    class FRE : Student
    {
        public enum Specials
        {
            МЭ,
            ПМС,
            ЭСБ,
            МиКПРЭС
        }
        protected int group;
        protected Specials special;
        protected struct Gpa
        {
            public decimal firstSemester;
            public decimal secondSemester;
            public decimal Total()
            {
                return (firstSemester + secondSemester) / 2;
            }
        }

        Gpa current;

        public FRE[] stud = new FRE[50];

        public new FRE this[int index]
        {
            get

            {
                return stud[index];
            }

            set
            {
                stud[index] = value;
            }
        }
        public int Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }

        public Specials Spec
        {
            get
            {
                return special;
            }
            set
            {
                special = value;
            }
        }
        public static void SortByGpa(FRE students, int size)
        {
            FRE temp;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (students[i].current.Total() > students[j].current.Total())
                    {
                        temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }
        public override void Add()
        {
            int buf = deleteCheck + count;
            Console.WriteLine("Личное дело номер " + buf);
            this.ide = buf;
            Console.WriteLine("Введите фамилию : ");
            string input = Console.ReadLine();
            while (!CheckStr(input))
            {
                Console.WriteLine("Введите данные снова");
                input = Console.ReadLine();
            }
            this.surname = input;
            Console.WriteLine("Введите имя : ");
            input = Console.ReadLine();
            while (!CheckStr(input))
            {
                Console.WriteLine("Введите данные снова");
                input = Console.ReadLine();
            }
            this.name = input;
            Console.WriteLine("Введите отчество : ");
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
            this.faculty = Faculties.ФРЭ;
            Console.WriteLine("Введите курс : ");
            string choiceInputCourse = Console.ReadLine();
            int courseChoice;
            while (!(Int32.TryParse(choiceInputCourse, out courseChoice)) || courseChoice <= 0 || courseChoice > 5)
            {
                Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
                choiceInputCourse = Console.ReadLine();
            }
            this.course = courseChoice;
            Console.WriteLine("Выберите специальность : ");
            Console.WriteLine("1) МЭ");
            Console.WriteLine("2) ПМС");
            Console.WriteLine("3) ЭСБ");
            Console.WriteLine("4) МиКПРЭС");
            string inputChoice = Console.ReadLine();
            int choice;
            while (!(Int32.TryParse(inputChoice, out choice)) || choice <= 0 || choice > 4)
            {
                Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
                inputChoice = Console.ReadLine();
            }
            switch (choice)
            {
                case 1:
                    this.special = Specials.МЭ;
                    break;
                case 2:
                    this.special = Specials.ПМС;
                    break;
                case 3:
                    this.special = Specials.ЭСБ;
                    break;
                case 4:
                    this.special = Specials.МиКПРЭС;
                    break;
            }
            Console.WriteLine("Введите группу : ");
            string choiceInputGroup = Console.ReadLine();
            int groupChoice;
            while (!(Int32.TryParse(choiceInputGroup, out groupChoice)) || groupChoice <= 0)
            {
                Console.WriteLine("Неверный ввод группы, попробуйте снова : ");
                choiceInputGroup = Console.ReadLine();
            }
            this.group = groupChoice;
            Console.WriteLine("Введите средний балл за первый семестр : ");
            choiceInputGroup = Console.ReadLine();
            int firstChoice;
            while (!(Int32.TryParse(choiceInputGroup, out firstChoice)) || firstChoice <= 0 || firstChoice > 10)
            {
                Console.WriteLine("Неверный ввод группы, попробуйте снова : ");
                choiceInputGroup = Console.ReadLine();
            }
            current.firstSemester = firstChoice;
            Console.WriteLine("Введите средний балл за второй семестр : ");
            choiceInputGroup = Console.ReadLine();
            int secondChoice;
            while (!(Int32.TryParse(choiceInputGroup, out secondChoice)) || secondChoice <= 0 || secondChoice > 10)
            {
                Console.WriteLine("Неверный ввод группы, попробуйте снова : ");
                choiceInputGroup = Console.ReadLine();
            }
            current.secondSemester = secondChoice;
            count++;
        }
        public static void SortByAgeStud(FRE students, int size)
        {
            FRE temp;
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
        public static void SearchByCourseStud(FRE students, int size, int choiceCourse)
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
        public static void SearchByIdeStud(FRE students, int size, int choiceIde)
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
            Console.WriteLine("Специальность : " + special);
            Console.WriteLine("Группа : " + group);
            Console.WriteLine("Средний балл за первый семестр : " + current.firstSemester);
            Console.WriteLine("Средний балл за второй семестр : " + current.secondSemester);
            Console.WriteLine("Итоговый средний балл : " + current.Total());
            Console.WriteLine("---------------------------------");
        }
    }
}

