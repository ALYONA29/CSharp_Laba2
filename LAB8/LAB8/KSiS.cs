using System;
using System.Collections.Generic;
using System.Text;

namespace LAB8
{
    class KSiS : Student, IGroupOperations
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
        protected string monitor;
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
        public delegate void Groups(string message);
        public event AccountHandler Sort;
        public delegate decimal Max(KSiS students, int size);
        public event Max Maximum;
        public delegate decimal Minimum1(KSiS students, int size);
        public event Minimum1 Min1;
        delegate void GetMessage();

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
        public string Monitor
        {
            get
            {
                return monitor;
            }
            set
            {
                monitor = value;
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
        private static void Show_Message(GetMessage _del)
        {
            _del?.Invoke();
        }
        private static void NoMonitor()
        {
            Console.WriteLine("Нет такой группы");
        }
        private static void HaveMonitor()
        {
            Console.WriteLine("Данные старосты ещё не были введены");
        }
        public void SortByGroups(object obj, int size)
        {
            KSiS studs = (KSiS)obj;
            KSiS temp;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (studs[i].group > studs[j].group)
                    {
                        temp = studs[i];
                        studs[i] = studs[j];
                        studs[j] = temp;
                    }
                }
            }
            studs.Sort = delegate (string mes)
            {
                Console.WriteLine(mes);
            };
            studs.Sort?.Invoke($"Отсортировано");
        }
        public bool MonitorCheck(object obj, int size, int groupe)
        {
            KSiS studs = (KSiS)obj;
            for (int i = 0; i < size; i++)
            {
                if (studs[i].monitor == "да" && studs[i].group == group)
                {
                    return true;
                }
            }
            return false;
        }
        public void FindMonitor(object obj, int size, int choice)
        {
            bool check1 = false;
            bool check2 = false;
            KSiS studs = (KSiS)obj;
            for (int i = 0; i < size; i++)
            {
                if (studs[i].group == choice)
                {
                    if (studs[i].monitor == "да")
                    {
                        studs[i].Print();
                        check2 = true;
                    }
                    check1 = true;
                }
            }
            if (check1 == false && check2 == false)
            {
                Show_Message(NoMonitor);
            }
            else if (check1 == true && check2 == false)
            {
                Show_Message(HaveMonitor);
            }
        }
        public override int Compare(object obj1, object obj2)
        {
            KSiS m1 = (KSiS)obj1;
            KSiS m2 = (KSiS)obj2;
            return String.Compare(m1.recover, m2.recover);
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
            students.Sort = mes => Console.WriteLine(mes);
            students.Sort?.Invoke($"Отсортировано");
            students.Sort = mes => Console.WriteLine(mes);
            students.Sort?.Invoke($"Максимальный средний балл : ");
            students.Maximum = (x, y) =>
            {
                decimal max = 0;
                for (int i = 0; i < y; i++)
                {
                    if (x[i].current.Total() > max)
                    {
                        max = x[i].current.Total();
                    }
                }
                return max;
            };
            decimal res = students.Maximum.Invoke(students, size);
            Console.WriteLine(res);
        }
        public override void SearchBySurname(int size, string choice)
        {
            int checker = 0;
            for (int i = 0; i < size; i++)
            {
                if (stud[i].surname == choice)
                {
                    stud[i].Print();
                    checker++;
                }
            }
            if (checker == 0)
            {
                Console.WriteLine("Нет такого личного дела");
            }
        }
        public bool IsMonitor(int index)
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
            bool check = true;
            int buf = deleteCheck + count;
            Console.WriteLine("Личное дело номер " + buf);
            this.ide = buf;
            string input;
            while (check)
            {
                try
                {
                    Console.WriteLine("Введите фамилию : ");
                    input = Console.ReadLine();
                    if (!CheckStr(input))
                    {
                        throw new Exception("неверный ввод");
                    }
                    check = false;
                    this.surname = input;
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
                    Console.WriteLine("Введите имя : ");
                    input = Console.ReadLine();
                    if (!CheckStr(input))
                    {
                        throw new Exception("неверный ввод");
                    }
                    check = false;
                    this.name = input;
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
                    Console.WriteLine("Введите отчество : ");
                    input = Console.ReadLine();
                    if (!CheckStr(input))
                    {
                        throw new Exception("неверный ввод");
                    }
                    check = false;
                    this.patronymic = input;
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
                    Console.WriteLine("Введите возраст : ");
                    string choiceInputAge = Console.ReadLine();
                    int ageChoice;
                    if (!(Int32.TryParse(choiceInputAge, out ageChoice)))
                    {
                        throw new Exception("не является числом");
                    }
                    if (ageChoice >= 150)
                    {
                        throw new Exception("слишком большое число");
                    }
                    if (ageChoice <= 0)
                    {
                        throw new Exception("отрицательное число");
                    }
                    check = false;
                    this.age = ageChoice;
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
                    Console.WriteLine("Введите рост : ");
                    string choiceInputHeight = Console.ReadLine();
                    decimal heightChoice;
                    if (!(Decimal.TryParse(choiceInputHeight, out heightChoice)))
                    {
                        throw new Exception("не является числом");
                    }
                    if (heightChoice >= 300)
                    {
                        throw new Exception("слишком большое число");
                    }
                    if (heightChoice <= 0)
                    {
                        throw new Exception("отрицательное число");
                    }
                    check = false;
                    this.height = heightChoice;
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
                    Console.WriteLine("Введите вес : ");
                    string choiceInputWeight = Console.ReadLine();
                    decimal weightChoice;
                    if (!(Decimal.TryParse(choiceInputWeight, out weightChoice)))
                    {
                        throw new Exception("не является числом");
                    }
                    if (weightChoice >= 300)
                    {
                        throw new Exception("слишком большое число");
                    }
                    if (weightChoice <= 0)
                    {
                        throw new Exception("отрицательное число");
                    }
                    check = false;
                    this.weight = weightChoice;
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
                    Console.WriteLine("Введите пол : ");
                    Console.WriteLine("1 - мужской");
                    Console.WriteLine("2 - женский");
                    string choiceInputPol = Console.ReadLine();
                    int polChoice;
                    if (!(Int32.TryParse(choiceInputPol, out polChoice)))
                    {
                        throw new Exception("не является целым числом");
                    }
                    if (polChoice >= 3)
                    {
                        throw new Exception("число больше 2");
                    }
                    if (polChoice <= 0)
                    {
                        throw new Exception("не натуральное число");
                    }
                    check = false;
                    if (polChoice == 1)
                    {
                        this.pol = "мужской";
                    }
                    if (polChoice == 2)
                    {
                        this.pol = "женский";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
            this.faculty = Faculties.ФКСиС;
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
                    Console.WriteLine("Выберите специальность : ");
                    Console.WriteLine("1) ИиТП");
                    Console.WriteLine("2) ПОИТ");
                    Console.WriteLine("3) ВМСиС");
                    Console.WriteLine("4) ЭМС");
                    string inputChoice = Console.ReadLine();
                    int choice;
                    if (!(Int32.TryParse(inputChoice, out choice)))
                    {
                        throw new Exception("не является целым числом");
                    }
                    if (choice >= 5)
                    {
                        throw new Exception("число больше 4");
                    }
                    if (choice <= 0)
                    {
                        throw new Exception("не натуральное число");
                    }
                    check = false;
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
            check = true;
            while (check)
            {
                try
                {
                    Console.WriteLine("Введите группу : ");
                    string choiceInputGroup = Console.ReadLine();
                    int groupChoice;
                    if (!(Int32.TryParse(choiceInputGroup, out groupChoice)))
                    {
                        throw new Exception("не является целым числом");
                    }
                    if (groupChoice >= 10000)
                    {
                        throw new Exception("слишком большое число");
                    }
                    if (groupChoice <= 0)
                    {
                        throw new Exception("отрицательное число");
                    }
                    check = false;
                    this.group = groupChoice;
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
                    Console.WriteLine("Введите средний балл за первый семестр : ");
                    string choiceInputGroup = Console.ReadLine();
                    decimal firstChoice;
                    if (!(Decimal.TryParse(choiceInputGroup, out firstChoice)))
                    {
                        throw new Exception("не является числом");
                    }
                    if (firstChoice > 10)
                    {
                        throw new Exception("средний балл не может быть больше 10");
                    }
                    if (firstChoice <= 0)
                    {
                        throw new Exception("отрицательное число");
                    }
                    check = false;
                    current.firstSemester = firstChoice;
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
                    Console.WriteLine("Введите средний балл за второй семестр : ");
                    string choiceInputGroup = Console.ReadLine();
                    decimal secondChoice;
                    if (!(Decimal.TryParse(choiceInputGroup, out secondChoice)))
                    {
                        throw new Exception("не является числом");
                    }
                    if (secondChoice > 10)
                    {
                        throw new Exception("средний балл не может быть больше 10");
                    }
                    if (secondChoice <= 0)
                    {
                        throw new Exception("отрицательное число");
                    }
                    check = false;
                    current.secondSemester = secondChoice;
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
                    Console.WriteLine("Является ли старостой : ");
                    Console.WriteLine("1) Да");
                    Console.WriteLine("2) Нет");
                    string choiceInputMonit = Console.ReadLine();
                    int monitChoice;
                    if (!(Int32.TryParse(choiceInputMonit, out monitChoice)))
                    {
                        throw new Exception("не является целым числом");
                    }
                    if (monitChoice >= 3)
                    {
                        throw new Exception("число больше 2");
                    }
                    if (monitChoice <= 0)
                    {
                        throw new Exception("не натуральное число");
                    }
                    check = false;
                    bool isMonit = IsMonitor(monitChoice);
                    if (isMonit)
                    {
                        this.monitor = "да";
                    }
                    else
                    {
                        this.monitor = "нет";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
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
            students.Sort = delegate (string mes)
            {
                Console.WriteLine(mes);
            };
            students.Sort?.Invoke($"Отсортировано");
            Console.WriteLine("Минимальный возраст : ");
            students.Min1 = (x, y) =>
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
            decimal res = students.Min1.Invoke(students, size);
            Console.WriteLine(res);
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
            Console.WriteLine("Университет : " + IArOperation.university);
            Console.WriteLine("Факультет : " + faculty);
            Console.WriteLine("Курс : " + course);
            Console.WriteLine("Специальность : " + special);
            Console.WriteLine("Восстановившийся" + recover);
            Console.WriteLine("Группа : " + group);
            Console.WriteLine("Староста : " + monitor);
            Console.WriteLine("Средний балл за первый семестр : " + current.firstSemester);
            Console.WriteLine("Средний балл за второй семестр : " + current.secondSemester);
            Console.WriteLine("Итоговый средний балл : " + current.Total());
            Console.WriteLine("---------------------------------");
        }
    }
}
