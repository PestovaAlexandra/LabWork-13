using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft;
using MyClassLibrary10;
namespace Task13
{
    class MyNewCollection:MyCollection
    {
        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args); //Делегат
        public event CollectionHandler CollectionCountChanged; //Событие на добавление-удаление элементов
        public event CollectionHandler CollectionReferenceChanged; //Событие когда одной из ссылок, входящих в коллекцию, присваивается новое значение
        public string NameCollection { get; set; } //•	открытое автореализуемое свойство типа string с названием коллекции
        public MyCollection myCollection = new MyCollection();
        public MyNewCollection(string nameCollection = "No name collection") //конструктор для создания коллекции и присвоения ей имени
        {
            myCollection = new MyCollection();
            this.NameCollection = nameCollection;
        }
        public Employee this[int index] //Индексатор
        {
            set
            {
                myCollection[index] = value;
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(this.NameCollection, "changed", myCollection[index]));
                
            }
            get
            { 
           
                return myCollection[index];
            }
        }
       

        //обработчик события CollectionCountChanged
        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(source, args);
        }
        //обработчик события OnCollectionReferenceChanged
        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(source, args);
        }

        public bool AddDefaults() //добавление рандомного элемента
        {
            Employee one = new Employee();//Поля объекта заполнились с помощью датчика случайных чисел
            this.Add(one);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(NameCollection, "add random", myCollection[myCollection.Count - 1]));
            return true;
        }
        public bool Remove(int index) //Удаление элемента по индексу
        {
            if (index < 0 || index >=myCollection.Count)
                return false;
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(NameCollection, "delete", myCollection[index-1]));
            myCollection.RemoveAt(index-1);
            return true;
        }

        public bool Add(Employee one) //Добавление определенного элемента в конец списка
        {
            myCollection.Add(one);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(NameCollection, "add", myCollection[myCollection.Count - 1]));
            return true;
        }

        
        
    }

}

