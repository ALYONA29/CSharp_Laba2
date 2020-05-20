using System;
using System.Collections.Generic;
using System.Text;

namespace LAB5_ISP_
{
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
                Console.WriteLine("Неверный ввод, попробуйте снова : ");
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