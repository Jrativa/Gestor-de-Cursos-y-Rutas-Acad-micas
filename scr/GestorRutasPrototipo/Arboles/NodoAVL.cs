using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRutasPrototipo.Arboles
{
    public class NodoAVL<T>{
    public int altura;
    protected T key;
    public NodoAVL<T> left;
    public NodoAVL<T> right;
    public NodoAVL<T> father;

        

        public NodoAVL(T d)
    {
        this.key = d;
        this.altura = 1;
    }
        public T GetKey()
        {
            return key;
        }
        public void SetKey(T key)
        {
            this.key=key;
        }
        public T Key { get => key; set => this.key = value; }
    } 
}
