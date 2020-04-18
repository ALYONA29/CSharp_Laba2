using _ИСП_ЛР3;
using System;

namespace LAB5_ISP_
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stud = new Student();
            KSiS stud1 = new KSiS();
            FITU stud2 = new FITU();
            FRE stud3 = new FRE();
            int choice = 0;
            int i = 0;
            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            while (choice != 3)
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1) Добавить студента в общую базу");
                Console.WriteLine("2) Добавить студента в базу специальности");
                Console.WriteLine("3) Выход");
                string choiceInput = Console.ReadLine();
                while (!(Int32.TryParse(choiceInput, out choice)) || choice <= 0 || choice > 3)
                {
                    Console.WriteLine("Неверный ввод, попробуйте снова : ");
                    choiceInput = Console.ReadLine();
                }
                switch (choice)
                {
                    case 1:
                        bool check = false;
                        while (!check)
                        {
                            stud[i] = new Student();
                            stud[i].Add();
                            i++;
                            Console.WriteLine("1) Добавить");
                            Console.WriteLine("2) Выход");
                            string addInput = Console.ReadLine();
                            int add;
                            while (!(Int32.TryParse(addInput, out add)) || add <= 0 || add > 2)
                            {
                                Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                addInput = Console.ReadLine();
                            }
                            if (add == 1)
                            {
                                check = false;
                            }
                            else
                            {
                                check = true;
                            }
                        }
                        check = false;
                        while (!check)
                        {
                            Console.WriteLine("Выберите действие");
                            Console.WriteLine("1) Сортировать по возрасту");
                            Console.WriteLine("2) Искать по курсу");
                            Console.WriteLine("3) Искать по IDE");
                            Console.WriteLine("4) Печать");
                            Console.WriteLine("5) Выход");
                            string chosen = Console.ReadLine();
                            int choose;
                            while (!(Int32.TryParse(chosen, out choose)) || choose <= 0 || choose > 5)
                            {
                                Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                chosen = Console.ReadLine();
                            }
                            switch(choose)
                            {
                                case 1:
                                    Student.SortByAgeStud(stud, i);
                                    break;
                                case 2:
                                    Console.WriteLine("Введите курс : ");
                                    string courseInput = Console.ReadLine();
                                    int course;
                                    while (!(Int32.TryParse(courseInput, out course)) || course <= 0 || course > 4)
                                    {
                                        Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
                                        courseInput = Console.ReadLine();
                                    }
                                    Student.SearchByCourseStud(stud, i, course);
                                    break;
                                case 3:
                                    Console.WriteLine("Введите IDE : ");
                                    string ideInput = Console.ReadLine();
                                    int ide;
                                    while (!(Int32.TryParse(ideInput, out ide)) || ide <= 0)
                                    {
                                        Console.WriteLine("Неверный ввод IDE, попробуйте снова : ");
                                        ideInput = Console.ReadLine();
                                    }
                                    Student.SearchByIdeStud(stud, i, ide);
                                    break;
                                case 4:
                                    for (int j = 0; j < i; j++)
                                    {
                                        stud[j].Print();
                                    }
                                    break;
                                case 5:
                                    check = true;
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Выберите действие");
                        Console.WriteLine("1) Добавить студента факультета КСиС");
                        Console.WriteLine("2) Добавить студента факультета ФИТУ");
                        Console.WriteLine("3) Добавить студента факультета ФРЭ");
                        Console.WriteLine("4) Выход");
                        int spec;
                        string specInput = Console.ReadLine();
                        while (!(Int32.TryParse(specInput, out spec)) || spec <= 0 || spec > 3)
                        {
                            Console.WriteLine("Неверный ввод, попробуйте снова : ");
                            specInput = Console.ReadLine();
                        }
                        switch(spec)
                        {
                            case 1:
                                bool check1 = false;
                                while (!check1)
                                {
                                    stud1[i1] = new KSiS();
                                    stud[i] = new Student();
                                    stud1[i1].Add();
                                    stud[i] = stud1[i1];
                                    i1++;
                                    i++;
                                    Console.WriteLine("1) Добавить");
                                    Console.WriteLine("2) Выход");
                                    string addInput1 = Console.ReadLine();
                                    int add1;
                                    while (!(Int32.TryParse(addInput1, out add1)) || add1 <= 0 || add1 > 2)
                                    {
                                        Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                        addInput1 = Console.ReadLine();
                                    }
                                    if (add1 == 1)
                                    {
                                        check1 = false;
                                    }
                                    else
                                    {
                                        check1 = true;
                                    }
                                }
                                check = false;
                                while (!check)
                                {
                                    Console.WriteLine("Выберите действие");
                                    Console.WriteLine("1) Сортировать по возрасту");
                                    Console.WriteLine("2) Искать по курсу");
                                    Console.WriteLine("3) Искать по IDE");
                                    Console.WriteLine("4) Печать");
                                    Console.WriteLine("5) Сортировать по среднему баллу");
                                    Console.WriteLine("6) Выход");
                                    string chosen1 = Console.ReadLine();
                                    int choose1;
                                    while (!(Int32.TryParse(chosen1, out choose1)) || choose1 <= 0 || choose1 > 6)
                                    {
                                        Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                        chosen1 = Console.ReadLine();
                                    }
                                    switch (choose1)
                                    {
                                        case 1:
                                            KSiS.SortByAgeStud(stud1, i1);
                                            break;
                                        case 2:
                                            Console.WriteLine("Введите курс : ");
                                            string courseInput = Console.ReadLine();
                                            int course;
                                            while (!(Int32.TryParse(courseInput, out course)) || course <= 0 || course > 4)
                                            {
                                                Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
                                                courseInput = Console.ReadLine();
                                            }
                                            KSiS.SearchByCourseStud(stud1, i1, course);
                                            break;
                                        case 3:
                                            Console.WriteLine("Введите IDE : ");
                                            string ideInput = Console.ReadLine();
                                            int ide;
                                            while (!(Int32.TryParse(ideInput, out ide)) || ide <= 0)
                                            {
                                                Console.WriteLine("Неверный ввод IDE, попробуйте снова : ");
                                                ideInput = Console.ReadLine();
                                            }
                                            KSiS.SearchByIdeStud(stud1, i1, ide);
                                            break;
                                        case 4:
                                            for (int j = 0; j < i1; j++)
                                            {
                                                stud1[j].Print();
                                            }
                                            break;
                                        case 5:
                                            KSiS.SortByGpa(stud1, i1);
                                            break;
                                        case 6:
                                            check = true;
                                            break;
                                    }
                                }
                                break;
                            case 2:
                                bool check2 = false;
                                while (!check2)
                                {
                                    stud2[i2] = new FITU();
                                    stud[i] = new Student();
                                    stud2[i2].Add();
                                    stud[i] = stud2[i2];
                                    i++;
                                    i2++;
                                    Console.WriteLine("1) Добавить");
                                    Console.WriteLine("2) Выход");
                                    string addInput2 = Console.ReadLine();
                                    int add2;
                                    while (!(Int32.TryParse(addInput2, out add2)) || add2 <= 0 || add2 > 2)
                                    {
                                        Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                        addInput2 = Console.ReadLine();
                                    }
                                    if (add2 == 1)
                                    {
                                        check2 = false;
                                    }
                                    else
                                    {
                                        check2 = true;
                                    }
                                }
                                check2 = false;
                                while (!check2)
                                {
                                    Console.WriteLine("Выберите действие");
                                    Console.WriteLine("1) Сортировать по возрасту");
                                    Console.WriteLine("2) Искать по курсу");
                                    Console.WriteLine("3) Искать по IDE");
                                    Console.WriteLine("4) Печать");
                                    Console.WriteLine("5) Сортировать по среднему баллу");
                                    Console.WriteLine("6) Выход");
                                    string chosen2 = Console.ReadLine();
                                    int choose2;
                                    while (!(Int32.TryParse(chosen2, out choose2)) || choose2 <= 0 || choose2 > 6)
                                    {
                                        Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                        chosen2 = Console.ReadLine();
                                    }
                                    switch (choose2)
                                    {
                                        case 1:
                                            FITU.SortByAgeStud(stud2, i2);
                                            break;
                                        case 2:
                                            Console.WriteLine("Введите курс : ");
                                            string courseInput = Console.ReadLine();
                                            int course;
                                            while (!(Int32.TryParse(courseInput, out course)) || course <= 0 || course > 4)
                                            {
                                                Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
                                                courseInput = Console.ReadLine();
                                            }
                                            FITU.SearchByCourseStud(stud2, i2, course);
                                            break;
                                        case 3:
                                            Console.WriteLine("Введите IDE : ");
                                            string ideInput = Console.ReadLine();
                                            int ide;
                                            while (!(Int32.TryParse(ideInput, out ide)) || ide <= 0)
                                            {
                                                Console.WriteLine("Неверный ввод IDE, попробуйте снова : ");
                                                ideInput = Console.ReadLine();
                                            }
                                            FITU.SearchByIdeStud(stud2, i2, ide);
                                            break;
                                        case 4:
                                            for (int j = 0; j < i1; j++)
                                            {
                                                stud2[j].Print();
                                            }
                                            break;
                                        case 5:
                                            FITU.SortByGpa(stud2, i2);
                                            break;
                                        case 6:
                                            check2 = true;
                                            break;
                                    }
                                }
                                break;
                            case 3:
                                bool check3 = false;
                                while (!check3)
                                {
                                    stud3[i3] = new FRE();
                                    stud[i] = new Student();
                                    stud3[i3].Add();
                                    stud[i] = stud3[i3];
                                    i3++;
                                    i++;
                                    Console.WriteLine("1) Добавить");
                                    Console.WriteLine("2) Выход");
                                    string addInput3 = Console.ReadLine();
                                    int add3;
                                    while (!(Int32.TryParse(addInput3, out add3)) || add3 <= 0 || add3 > 2)
                                    {
                                        Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                        addInput3 = Console.ReadLine();
                                    }
                                    if (add3 == 1)
                                    {
                                        check3 = false;
                                    }
                                    else
                                    {
                                        check3 = true;
                                    }
                                }
                                check3 = false;
                                while (!check3)
                                {
                                    Console.WriteLine("Выберите действие");
                                    Console.WriteLine("1) Сортировать по возрасту");
                                    Console.WriteLine("2) Искать по курсу");
                                    Console.WriteLine("3) Искать по IDE");
                                    Console.WriteLine("4) Печать");
                                    Console.WriteLine("5) Сортировать по среднему баллу");
                                    Console.WriteLine("6) Выход");
                                    string chosen3 = Console.ReadLine();
                                    int choose3;
                                    while (!(Int32.TryParse(chosen3, out choose3)) || choose3 <= 0 || choose3 > 6)
                                    {
                                        Console.WriteLine("Неверный ввод, попробуйте снова : ");
                                        chosen3 = Console.ReadLine();
                                    }
                                    switch (choose3)
                                    {
                                        case 1:
                                            FRE.SortByAgeStud(stud3, i3);
                                            break;
                                        case 2:
                                            Console.WriteLine("Введите курс : ");
                                            string courseInput = Console.ReadLine();
                                            int course;
                                            while (!(Int32.TryParse(courseInput, out course)) || course <= 0 || course > 4)
                                            {
                                                Console.WriteLine("Неверный ввод курса, попробуйте снова : ");
                                                courseInput = Console.ReadLine();
                                            }
                                            FRE.SearchByCourseStud(stud3, i3, course);
                                            break;
                                        case 3:
                                            Console.WriteLine("Введите IDE : ");
                                            string ideInput = Console.ReadLine();
                                            int ide;
                                            while (!(Int32.TryParse(ideInput, out ide)) || ide <= 0)
                                            {
                                                Console.WriteLine("Неверный ввод IDE, попробуйте снова : ");
                                                ideInput = Console.ReadLine();
                                            }
                                            FRE.SearchByIdeStud(stud3, i3, ide);
                                            break;
                                        case 4:
                                            for (int j = 0; j < i3; j++)
                                            {
                                                stud3[j].Print();
                                            }
                                            break;
                                        case 5:
                                            FRE.SortByGpa(stud3, i3);
                                            break;
                                        case 6:
                                            check3 = true;
                                            break;
                                    }
                                }
                                break;
                        }
                        break;
                }
            }
        }
    }
}
