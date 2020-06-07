using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary10;

namespace Task13
{
    class JournalEntry
    {
        public string NameCollection;
        public string TypeChange;
        public Employee ChangedEmployee;


        public JournalEntry(string name, string changes, Employee one)
        {
            this.NameCollection = name;
            this.TypeChange = changes;
            this.ChangedEmployee = one;
        }

        //public JournalEntry(CollectionHandlerEventArgs args)
        //{
        //    CollectionId = args.CollectionId;
        //    Changes = args.Changes;
        //    ChangePerson = args.ChangedPerson;
        //}

        public override string ToString()
        {
            return $"JournalEntry: {NameCollection} || {TypeChange} || {ChangedEmployee.ToString()}";
        }
    }
}
