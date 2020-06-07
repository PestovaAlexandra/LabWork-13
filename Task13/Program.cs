using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary10;
namespace Task13
{
    class Program
    {
        public static void MainMenu()
        {
            Console.WriteLine("1. Часть 1 \n2. Часть 2\n3. Выход");
        }
        public static void Part1Menu()
        {
            Console.WriteLine("1. Создать и заполнить коллекцию\n 2. Добавить элементы\n 3. Удалить элементы\n 4. Сортировка элементов по заданному полю\n 5. Очистить коллекцию\n 6. Распечатать коллекцию\n 7. Назад");
        }
        static int Natural(out int a)
        {
            a = 0;
            bool ok = true;
            do
            {
                try
                {
                    a = int.Parse((Console.ReadLine()));
                    if (a < 0)
                    {
                        ok = false;
                        Console.WriteLine("Введите натуральное число");
                    }
                }
                catch
                {
                    Console.WriteLine("Введите натуральное число от 1 до 3");
                }
            } while (!ok);
            return a;
        }
        static int Input(out int a, int down, int up)
        {
            a = 0;
            bool ok = true;
            do
            {
                try
                {
                    a = int.Parse((Console.ReadLine()));
                    if (a < 0)
                    {
                        ok = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Введите натуральное число от 1 до 3");
                }
            } while (!ok || a < down || a > up);
            return a;
        }
        static void Main(string[] args)
        {
            MyCollection collection = null;

            int choice = 0;

            do
            {
                MainMenu();
                Input(out choice, 1, 3);
                switch (choice)
                {
                    case 1:
                        {
                            do
                            {
                                Part1Menu();
                                int size = 0;
                                Input(out choice, 1, 8);
                                switch (choice)
                                {
                                    case 1:
                                        {
                                            collection = new MyCollection();
                                            Console.WriteLine("Введите количество элементов в списке");
                                            collection.CreateCollection(Natural(out size));
                                            Console.WriteLine($"Коллекция из {size} элементов создана");

                                        }
                                        break;
                                    case 2:
                                        {
                                            Console.WriteLine("1. Добавить рандомные элементы(несколько) 2. Добавить определенный элемент(1)");
                                            switch (Input(out choice, 1, 9))
                                            {
                                                case 1: //InsertRandom
                                                    {
                                                        if (collection == null)
                                                            Console.WriteLine("Список не создан");
                                                        else
                                                        {
                                                            Console.WriteLine("Введите количество вставляемых элементов");
                                                            collection.AddSome(Natural(out size));
                                                            Console.WriteLine("Элемент добавлен");
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        if (collection == null)
                                                            Console.WriteLine("Список не создан");
                                                        else
                                                        {
                                                            Console.WriteLine("Введите значение");
                                                            Console.WriteLine("Введите имя");
                                                            string name = Console.ReadLine();
                                                            Console.WriteLine("Введите возраст");
                                                            int age = int.Parse(Console.ReadLine());
                                                            Console.WriteLine("Введите стаж");
                                                            int exp = int.Parse(Console.ReadLine());

                                                            Employee one = new Employee(name, age, exp);
                                                            collection.AddObject(one);
                                                            Console.WriteLine("Элемент добавлен");
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        {
                                            Console.WriteLine("1. Удалить элемент по индексу 2. Удалить элемент по значению");
                                            switch (Input(out choice, 1, 9))
                                            {
                                                case 1: //InsertRandom
                                                    {
                                                        if (collection == null)
                                                            Console.WriteLine("Список не создан");
                                                        else
                                                        {
                                                            Console.WriteLine("Введите номер удаляемого элемента");
                                                            collection.DeleteIndex(Natural(out size));
                                                            Console.WriteLine("Элемент удален");
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        if (collection == null)
                                                            Console.WriteLine("Список не создан");
                                                        else
                                                        {
                                                            Console.WriteLine("Введите значение");
                                                            Console.WriteLine("Введите имя");
                                                            string name = Console.ReadLine();
                                                            Console.WriteLine("Введите возраст");
                                                            int age = int.Parse(Console.ReadLine());
                                                            Console.WriteLine("Введите стаж");
                                                            int exp = int.Parse(Console.ReadLine());

                                                            Employee one = new Employee(name, age, exp);
                                                            collection.DeleteObject(one);
                                                            Console.WriteLine("Элемент удален");
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        {
                                            if(collection == null)
                                                Console.WriteLine("Список не создан");
                                            else
                                            {
                                                string str = "";
                                                Console.WriteLine("Выбирите и введите по какому признаку отсортировать коллекцию: Name, Age, Experience");
                                                str = Console.ReadLine();
                                                collection.Print();
                                                collection.Sort(str);
                                                Console.WriteLine("Сортировка произведена");
                                                collection.Print();

                                            }
                                        }
                                        break;
                                    case 5:
                                        {
                                            collection.DeleteAll();
                                        }
                                        break;
                                    case 6:
                                        {
                                            if (collection == null)
                                                Console.WriteLine("Список не создан");
                                            else
                                            {
                                                Console.WriteLine($"Коллекция элементов");
                                                collection.Print();
                                            }
                                        }
                                        break;
                                }
                            } while (choice != 7);
                        }
                        break;
                    case 2:
                        {
                            MyNewCollection FirstCollection = new MyNewCollection("First collection");
                            MyNewCollection SecondCollection = new MyNewCollection("Second collection");
                            Journal FirstJournal = new Journal();
                            Journal SecondJournal = new Journal();

                            //Подписки
                            FirstCollection.CollectionCountChanged += FirstJournal.CollectionCountChanged;
                            FirstCollection.CollectionReferenceChanged += FirstJournal.CollectionReferenceChanged;
                            FirstCollection.CollectionReferenceChanged += SecondJournal.CollectionReferenceChanged;
                            SecondCollection.CollectionReferenceChanged += SecondJournal.CollectionReferenceChanged;

                            //Добавление в 1 список
                            FirstCollection.Add(new Employee("Пестова Александра", 19,1));
                            FirstCollection.Add(new Employee("Мазилова Арина", 23, 4));
                            FirstCollection.Add(new Employee("Гаврилова Ирина", 34, 7));

                            FirstCollection.AddDefaults();
                            FirstCollection.AddDefaults();

                            FirstCollection.Remove(2);
                            //FirstCollection.Remove(1);
                            Employee one = new Employee("Бритни Спирс", 29, 12);
                            FirstCollection[0] = one;
                            FirstCollection[1] = new Employee("Меня добавили", 29, 1);
                            Console.WriteLine(FirstJournal.ToString());

                            Console.WriteLine("\nВторая коллекция \n ");
                            //Добавление во 2
                            SecondCollection.Add(new Employee("Коронка", 23, 2));
                            SecondCollection.Add(new Worker("Солнышко", 10000000,200000,"ОАО Небесные светила"));
                            SecondCollection.Add(new Employee("Юлия Силина", 39, 10));
                            SecondCollection.Add(new Worker("Мистер Смитт", 65, 32, "Голливуд"));
                            SecondCollection.Remove(3);
                            SecondCollection[2] = new Worker("Гарри Поттер", 20, 8, "Хогвартс");
                            Console.WriteLine(SecondJournal.ToString());
                        }
                        break;
                }
            }
            while (choice != 3);

            Console.ReadKey();
        }
    }
}
