using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRutasPrototipo.Hashing
{
    public class NodoHash<T> where T : IComparable
    {
        private int key;
        private T? value;
        private NodoHash<T>? next;

        
        public int Key { get => key; set => this.key = value; }
        public T Value { get => value; set => this.value = value; }
        public NodoHash<T> Next { get => next; set => this.next = value; }
        public override string ToString()
        {
            return String.Format("[{0}, {1}]", this.key, this.value);
        }
        public void Print()
        {
            Console.WriteLine(this.value+" - - ");
            if (this.next != null)
            {
                next.Print();
            }
        }
    }
}
