using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRutasPrototipo.Arboles
{
    internal class BinaryHeap
    {
    }
    class BinaryHeap<T> where T : IComparable
    {
    private static int capacidadPorDefecto = 10;
    private int elementos;
    private T[] heap;
    public BinaryHeap()
    {
        elementos = 0;
        heap  = new T[capacidadPorDefecto + 1]; 
    }
    public BinaryHeap(int capacidad)
    {
        elementos = 0;
        heap  = new T[capacidad + 1];
        }
    public void increaseSize(int capacidad)
    {
        T[] newHeap;
        newHeap = new T[capacidad + 1];
        for (int i = 0; i < heap.Length; i++)
        {
            newHeap[i] = heap[i];
        }
        heap = newHeap;
    }
    public int getNumeroElementos()
    {
        return elementos;
    }
    public void insert(T elemento)
    {
        if (elementos == heap.Length - 1) increaseSize(heap.Length * 2 - 1);
        int hole = ++elementos;
        for (heap[0] = elemento; elemento.CompareTo(heap[hole / 2]) > 0; hole /= 2)
        {
            heap[hole] = heap[hole / 2];
        }
        heap[hole] = elemento;
    }
    public T findMax()
    {
        if (elementos == 0) Console.WriteLine("Heap vacio, no se puede extraer.");
        return heap[1];
    }
    public T deleteMax()
    {
        if (elementos == 0) Console.WriteLine("Heap vacio, no se puede extraer.");
        T maxElem = findMax();
        heap[1] = heap[elementos--];
        percolateDown(1);
        return maxElem;
    }
    private void percolateDown(int hole)
    {
        int hijo;
        T aux = heap[hole];
        for (; hole * 2 <= elementos; hole = hijo)
        {
            hijo = hole * 2;
            if (hijo != elementos && heap[hijo + 1].CompareTo(heap[hijo]) > 0) hijo++;
            if (heap[hijo].CompareTo(aux) < 0) heap[hole] = heap[hijo];
            else break;
        }
        heap[hole] = aux;
    }
        public void showArray()
        {
            Console.WriteLine("--Inicio--");
            for (int i = 0; i < heap.Length; i++)
            {
                Console.Write(heap[i] + "|");
            }
            Console.WriteLine();
            Console.WriteLine("--Fin--");
        }

    }
}
