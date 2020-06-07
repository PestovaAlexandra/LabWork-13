using MyClassLibrary10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string NameCollection { get; set; }

        public string TypeChange { get; set; }

        public Employee ChangedEmployee { get; set; }

        public CollectionHandlerEventArgs(string name, string typeChange, Employee changed)
        {
            this.NameCollection = name;
            this.TypeChange = typeChange;
            this.ChangedEmployee = changed;
        }

        public override string ToString()
        {
            return $"Param: {NameCollection} || {TypeChange} || {ChangedEmployee.ToString()}";
        }
    }


}


