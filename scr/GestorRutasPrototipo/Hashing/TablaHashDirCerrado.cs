using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstructurasLineales;

namespace GestorRutasPrototipo.Hashing
{
    public class TablaHashDirCerrado<T> where T : IComparable
    {

        private int size;
        private int elements;
        private ListaParaHash<T>[] lists;
        public TablaHashDirCerrado(int Size)
        {
            this.size = Size;
            lists = new ListaParaHash<T>[size];
            for(int i = 0; i < size; i++)
            {
                lists[i]= new ListaParaHash<T>();
            }
        }
        public int Size { get => size; }
        public int Elements { get => elements; }
        public ListaParaHash<T>[] Lists { get => lists; }

        public void ShowTable()
        {
            for(int i=0; i < size; i++)
            {
                Console.Write("({0}) ", i);
                lists[i].Print();
                Console.WriteLine();
            }
        }
        public int HashFunction(int pKey)
        {
            return pKey % size;
        }
        private int CodigoASCII(string pKey)
        {
            int s = 0;
            int i = 0;
            foreach (var c in pKey)
            {
                if (i % 2 == 0) { s += (int)c; }
                i++;
            }
            return s ;
        }
        public void Insert(int pKey, T value)
        {
            int index=HashFunction(pKey);
            lists[index].AddToEnd(pKey, value);
            elements++;
        }
        public void Insert(String pKey, T value)
        {
            Insert(CodigoASCII(pKey), value);
        }

        public void Delete(int pKey)
        {
            int index = HashFunction(pKey);
            lists[index].Delete(pKey);
        }
        public T Search(int pKey)
        {
            int index = HashFunction(pKey);
            return lists[index].Search(pKey).Value;
        }
        public T Search(String pKey)
        {
            return Search(CodigoASCII(pKey));
        }

    }
}
