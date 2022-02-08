using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRutasPrototipo.Arboles
{
    public class ArbolAVL<T> where T:IComparable
    {
        public NodoAVL<T> root;
        private int cantidadNodos=0;

        public ArbolAVL()
        {
            root = null;
        }
        public int CantidadNodos { get => cantidadNodos; set => this.cantidadNodos = value; }
        public void clearAll()
        {
            root = null;
        }
        public void Insert(T key)
        {
            root = insertAVL(root, key);
            cantidadNodos++;
        }
        private NodoAVL<T> insertAVL(NodoAVL<T> nodoActual, T key)
        {
            if (nodoActual == null)
            {
                return (new NodoAVL<T>(key));
            }

            if (key.CompareTo(nodoActual.GetKey()) < 0)
            {
                nodoActual.left = insertAVL(nodoActual.left, key);
            }
            else if (key.CompareTo(nodoActual.GetKey()) > 0)
            {
                nodoActual.right = insertAVL(nodoActual.right, key);
            }
            else
            {// Si la clave esta duplicada retorna el mismo nodo encontrado
                return nodoActual;
            }
            //Actualizacion de la altura
            nodoActual.altura = 1 +
                    Math.Max(getAltura(nodoActual.left), getAltura(nodoActual.right));

            // Se obtiene el factor de equilibrio
            int fe = getFactorEquilibrio(nodoActual);

            // Caso Rotacion Simple a la derecha
            if (fe > 1 && key.CompareTo(nodoActual.left.GetKey()) < 0)
            {
                return rightRotate(nodoActual);
            }
            // Caso Rotacion Simple a la izquierda
            if (fe < -1 && key.CompareTo(nodoActual.right.GetKey()) > 0)
            {
                return leftRotate(nodoActual);
            }

            if (fe > 1 && key.CompareTo(nodoActual.left.GetKey()) > 0)
            {
                nodoActual.left = leftRotate(nodoActual.left);
                return rightRotate(nodoActual);
            }

            // Caso Rotacion Doble Derecha Izquierda

            if (fe < -1 && key.CompareTo(nodoActual.right.GetKey()) < 0)
            {
                nodoActual.right = rightRotate(nodoActual.right);
                return leftRotate(nodoActual);
            }

            return nodoActual;
        }
        //---búsqueda de un elemento en el AVL
        public NodoAVL<T> BuscarNodo(T elemento)
        {
            return BuscaEnAVL(root, elemento);
        }

        //Búsqueda recursiva en un AVL
        private NodoAVL<T> BuscaEnAVL(NodoAVL<T> nodoActual, T elemento)
        {
            if (nodoActual == null)
            {
                return null;
            }
            else if (elemento.CompareTo(nodoActual.GetKey()) == 0)
            {
                return nodoActual;
            }
            else if (elemento.CompareTo(nodoActual.GetKey()) < 0)
            {
                nodoActual.left.father = nodoActual;
                return BuscaEnAVL(nodoActual.left, elemento);
            }
            else
            {
                nodoActual.right.father = nodoActual;
                return BuscaEnAVL(nodoActual.right, elemento);
            }
        }

        // Rotar hacia la derecha
        private NodoAVL<T> rightRotate(NodoAVL<T> nodoActual)
        {
            NodoAVL<T> nuevaRaiz = nodoActual.left;
            NodoAVL<T> temp = nuevaRaiz.right;
            nuevaRaiz.right = nodoActual;
            nodoActual.left = temp;
            nodoActual.altura = Math.Max(getAltura(nodoActual.left), getAltura(nodoActual.right)) + 1;
            nuevaRaiz.altura = Math.Max(getAltura(nuevaRaiz.left), getAltura(nuevaRaiz.right)) + 1;

            return nuevaRaiz;
        }
        // Rotar hacia la izquierda
        private NodoAVL<T> leftRotate(NodoAVL<T> nodoActual)
        {
            NodoAVL<T> nuevaRaiz = nodoActual.right;
            NodoAVL<T> temp = nuevaRaiz.left;
            nuevaRaiz.left = nodoActual;
            nodoActual.right = temp;
            nodoActual.altura = Math.Max(getAltura(nodoActual.left), getAltura(nodoActual.right)) + 1;
            nuevaRaiz.altura = Math.Max(getAltura(nuevaRaiz.left), getAltura(nuevaRaiz.right)) + 1;

            return nuevaRaiz;
        }
        //Obtiene el peso de un arbol dado
        private int getAltura(NodoAVL<T> nodoActual)
        {
            if (nodoActual == null)
            {
                return 0;
            }
            return nodoActual.altura;
        }
        // Obtiene el factor de equilibrio de un nodo
        private int getFactorEquilibrio(NodoAVL<T> nodoActual)
        {
            if (nodoActual == null)
            {
                return 0;
            }

            return getAltura(nodoActual.left) - getAltura(nodoActual.right);
        }
        public NodoAVL<T> FindMax(NodoAVL<T> node)
        {
            NodoAVL<T> aux = node;

            while (aux.right != null)
            {
                aux = aux.right;
            }
            return aux;
        }
        public NodoAVL<T> FindMin(NodoAVL<T> node)
        {
            NodoAVL<T> aux = node;

            while (aux.left != null)
            {
                aux = aux.left;
            }
            return aux;
        }
        public void mostrarArbolAVL()
        {
            Console.WriteLine("Arbol AVL");
            showTree(root, 0);
        }

        private void showTree(NodoAVL<T> nodo, int depth)
        {
            if (nodo.right != null)
            {
                showTree(nodo.right, depth + 1);
            }
            for (int i = 0; i < depth; i++)
            {
                Console.Write("    ");
            }
            Console.WriteLine("(" + nodo.GetKey() + ")");

            if (nodo.left != null)
            {
                showTree(nodo.left, depth + 1);
            }
        }
        public void eliminar(T key)
        {
            root = eliminarAVL(root, key);
        }

        private NodoAVL<T> eliminarAVL(NodoAVL<T> nodoActual, T key)
        {
            if (nodoActual == null)
                return nodoActual;

            if (key.CompareTo(nodoActual.GetKey()) < 0)
            {
                nodoActual.left = eliminarAVL(nodoActual.left, key);
            }
            else if (key.CompareTo(nodoActual.GetKey()) > 0)
            {
                nodoActual.right = eliminarAVL(nodoActual.right, key);
            }
            else
            {
                //El nodo es igual a la clave, se elimina
                //Nodo con un unico hijo o es hoja
                if ((nodoActual.left == null) || (nodoActual.right == null))
                {
                    NodoAVL<T> temp = null;
                    if (temp == nodoActual.left)
                    {
                        temp = nodoActual.right;
                    }
                    else
                    {
                        temp = nodoActual.left;
                    }

                    // Caso que no tiene hijos
                    if (temp == null)
                    {
                        nodoActual = null;//Se elimina dejandolo en null
                    }
                    else
                    {
                        //Caso con un hijo
                        nodoActual = temp;//Elimina el valor actual reemplazandolo por su hijo
                    }
                }
                else
                {
                    //Nodo con dos hijos, se busca el predecesor
                    NodoAVL<T> temp = FindMax(nodoActual.left);

                    //Se copia el dato del predecesor
                    nodoActual.SetKey(temp.GetKey())  ;

                    //Se elimina el predecesor
                    nodoActual.left = eliminarAVL(nodoActual.left, temp.GetKey());
                }
            }

            //Si solo tiene un nodo
            if (nodoActual == null)
                return nodoActual;

            //Actualiza altura
            nodoActual.altura = Math.Max(getAltura(nodoActual.left), getAltura(nodoActual.right)) + 1;

            //Calcula factor de equilibrio (FE)
            int fe = getFactorEquilibrio(nodoActual);

            if (fe > 1 && getFactorEquilibrio(nodoActual.left) >= 0)
            {
                return rightRotate(nodoActual);
            }
            if (fe < -1 && getFactorEquilibrio(nodoActual.right) <= 0)
            {
                return leftRotate(nodoActual);
            }

            if (fe > 1 && getFactorEquilibrio(nodoActual.left) < 0)
            {
                nodoActual.left = leftRotate(nodoActual.left);
                return rightRotate(nodoActual);
            }
            if (fe < -1 && getFactorEquilibrio(nodoActual.right) > 0)
            {
                nodoActual.right = rightRotate(nodoActual.right);
                return leftRotate(nodoActual);
            }

            return nodoActual;
        }
        


    }
}
