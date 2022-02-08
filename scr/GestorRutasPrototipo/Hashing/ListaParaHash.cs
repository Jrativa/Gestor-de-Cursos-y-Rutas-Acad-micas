using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRutasPrototipo.Hashing
{
    public class ListaParaHash<T> where T : IComparable
    {
        private NodoHash<T>? head;
        private NodoHash<T>? tail;
        protected int length=0;

        public NodoHash<T> GetHeadNode() { return this.head; }
        public NodoHash<T> GetTailNode() { return this.tail; }
        public int GetLength() { return this.length; }

        public void Print()
        {
            if (this.length == 1) { Console.Write("{0}-->", head); }
            else
            {
                NodoHash<T>? auxiliar = head;
                while (auxiliar != null)
                {
                    Console.Write("{0}-->", auxiliar);
                    auxiliar = auxiliar.Next;
                }
                
            }
            
        }
        //public void Print()
        //{
        //    if (this.head != null) { this.head.Print(); }
        //    Console.WriteLine();
        //}
        public void AddToEnd(int pKey, T pValue)
        {
            this.length += 1;
            if (this.head == null)
            {
                NodoHash<T> node = new();
                node.Key = pKey;
                node.Value = pValue;
                this.head=node;
                this.tail = node;
            }
            else
            {
                NodoHash<T> node = new NodoHash<T>();
                node.Key = pKey;
                node.Value = pValue;
                this.tail.Next = node;
                this.tail = node;
            }
        }
        public void Empty()
        {
            this.head = this.tail = null;
        }
        public bool IsEmpty()
        {
            return this.head == null;
        }
        public NodoHash<T> Search(int pKey)
        {
            if (IsEmpty()) return null;
            NodoHash<T>? auxiliar = head;
            while (auxiliar != null)
            {
                if (auxiliar.Key == pKey) { return auxiliar; }
                auxiliar = auxiliar.Next; 
            }
            return null;
        }
        public int SearchIndex(int pKey)
        {
            if (IsEmpty()) return -1;
            int n = 0;
            NodoHash<T>? auxiliar = head;
            while (auxiliar != null)
            {
                if (auxiliar.Key == pKey) { return n; }
                auxiliar = auxiliar.Next;
                n++;
            }
            return -1;
        }
        public NodoHash<T> FindPreviousNode(int pKey)
        {
            NodoHash<T>? auxiliar = head;
            while (auxiliar!=null && auxiliar.Next.Key !=pKey)
            {
                auxiliar = auxiliar.Next;
            }
            return auxiliar;
        }
        public void Delete(int pKey)
        {
            if(IsEmpty()) return;
            NodoHash<T> anterior =FindPreviousNode(pKey);
            NodoHash<T> borrado = Search(pKey);
            if (borrado==null) return;
            anterior.Next=borrado.Next;
            borrado.Next=null;
            this.length--;
        }
        public void Add(int pWhere,int pKey, T pValue )
        {
            NodoHash<T>? auxiliar=Search(pWhere);
            if(auxiliar==null) return;
            NodoHash<T> node = new NodoHash<T>();
            node.Key = pKey;
            node.Value = pValue;
            node.Next = auxiliar.Next;
            auxiliar.Next=node;
        }
        public void AddToBeginning( int pKey, T pValue)
        {

            if (this.head == null)
            {
                this.head.Value = pValue;
                this.head.Key = pKey;
                this.tail = this.head;
            }
            else
            {
                NodoHash<T> node = new NodoHash<T>();
                node.Key = pKey;
                node.Value = pValue;
                node.Next = head;
                this.head = node;
            }
        }
        public NodoHash<T> GetByIndex(int pIndex)
        {
            NodoHash<T>? auxiliar = head;
            int index = -1;
            while (auxiliar != null)
            {
                index++;
                if(index==pIndex) return auxiliar;
                auxiliar= auxiliar.Next;
            }
            return null;

        }
        public int this[int pIndex]
        {
            get
            {
                NodoHash<T>? auxiliar = GetByIndex(pIndex);
                return auxiliar.Key;
            }
            set 
            {
                NodoHash<T>? auxiliar = GetByIndex(pIndex);
                if (auxiliar != null) { auxiliar.Key = value; }
            }
        }

    }
}
