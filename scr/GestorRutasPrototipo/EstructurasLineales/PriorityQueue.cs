using EstructurasLineales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRutasPrototipo.EstructurasLineales
{
    public class PriorityQueue<T>:MyLinkedList<T> where T : IComparable
    {
    public PriorityQueue() : base()
    {   
    }
    public void enqueue(T data)
    {
            if (this.length == 0) { this.AddToEnd(data); }
            else
            {
                if (this.tailNode.data.CompareTo(data) > 0) { this.AddToEnd(data); }
                else
                {
                    if (data.CompareTo(this.headNode.data) > 0) { this.AddToBeginning(data); }
                    else
                    {
                        Node<T> aux = this.GetHeadNode();
                        Node<T> aux2 = aux;
                        while (data.CompareTo(aux.data) < 0)
                        {
                            aux2 = aux;
                            aux = aux.nextNode;

                        }
                        Node<T> temp = new Node<T>(data);
                        temp.nextNode = aux;
                        aux2.nextNode = temp;
                    }
                }
                
            }
        }
    public T dequeue()
    {
        T value = Remove(0);
        return value;
    }
    public T front()
    {
        return GetValue(0);
    }
    public T back()
    {
        return this.GetTailNode().data;
    }
    

    }
}
