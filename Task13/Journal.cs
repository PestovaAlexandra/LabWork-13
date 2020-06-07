using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13
{
    class Journal
    {
        private List<JournalEntry> journallList ; //Закрытое поле

        public Journal()
        {
            journallList = new List<JournalEntry>();
        }

        public void CollectionCountChanged(object sourse, CollectionHandlerEventArgs e) //обработчик события в классе-получателе, согласованный по сигнатуре с функциональным типом делегата, который задает событие
        {
            JournalEntry journal = new JournalEntry(e.NameCollection, e.TypeChange, e.ChangedEmployee);
            journallList.Add(journal);
        }
        public void CollectionReferenceChanged(object sourse, CollectionHandlerEventArgs e) //обработчик события в классе-получателе, согласованный по сигнатуре с функциональным типом делегата, который задает событие
        {
            JournalEntry journal = new JournalEntry(e.NameCollection, e.TypeChange, e.ChangedEmployee);
            journallList.Add(journal);
        }

        public string Shows(int i) //Вывести один элемент
        {
            string str = "";
            str = journallList[i].NameCollection + " " + journallList[i].TypeChange + " " + journallList[i].ChangedEmployee + "\n";
                 
            return str;
        }

        public override string ToString() //Вывести весь список
        {
            string str = "";
            foreach (JournalEntry item in journallList)
            {
                str += item.NameCollection + " " + item.TypeChange + " " + item.ChangedEmployee.ToString() + "\n";
            }

            return str;
        }
    }
}
