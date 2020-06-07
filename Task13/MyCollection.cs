using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary10;

namespace Task13
{
    class MyCollection : Collection<Employee>,IEnumerable<Employee>
    {

        public void CreateCollection (int size)
        {
            for(int i=0;i<size;i++)
            {
                this.Add(MakeObject());
            }
        }
        public static Employee MakeObject()
        {
            Employee one = new Employee();
            return one;
        }
        public void DeleteObject(Employee one)//Удаление элемента по значению
        {
            this.Remove(one);
        }
        public void DeleteIndex(int index)//Удаление элемента по индексу
        {
            this.RemoveAt(index - 1);
        }
        public void DeleteAll()//Удалить все элементы коллекции
        {
            this.Clear();
            Console.WriteLine("Коллекция удалена");
        }
        public void AddSome(int count)//Добавить несколько элементов d rjytw
        {
            for(int i=0; i<count; i++)
            {
                this.Add(MakeObject());
            }
        }
        public void AddObject(Employee one)//Добавление по индексу рандомного элемента
        {
            this.Add(one);
        }
        public int Lenght//длина коллекции
        {
            get
            {
                return Count;
            }
        }
        private bool Compare(Employee emp1, Employee emp2, string property)//Два объекта + выбор по чему сортировать
        {
            switch (property)
            {
                case  "Name":
                    return emp1.Name.CompareTo(emp2.Name) > 0;
                case "Experience":
                    return emp1.Experience > emp2.Experience;
                case "Age":
                    return emp1.Age > emp2.Age;
            }

            return false;
        }

        public void Sort(string property)
        {
            for (int j = 0; j < this.Count; j++)
            {
                for (int i = 0; i < this.Lenght - 1; i++)
                {
                    if (Compare(Items[i], Items[i + 1], property))
                    {
                        Employee temp = Items[i];
                        Items[i] = Items[i + 1];
                        Items[i + 1] = temp;
                    }
                }
            }
        }
        public void Print()
        {
            if (this.Count == 0)
            {
                Console.WriteLine("Коллекция пустая");
            }
            else
            {
                Console.WriteLine();
                for (int i = 0; i < this.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {this[i]} ");
                }
                Console.WriteLine();
            }
        }
        public interface IEnumerator
        {
            bool MoveNext(); // перемещение на одну позицию вперед в контейнере элементов
            object Current { get; }  // текущий элемент в контейнере
            void Reset(); // перемещение в начало контейнера
        }
        public interface IEnumerable
        {
            IEnumerator GetEnumerator();
        }

        

    }
} 



