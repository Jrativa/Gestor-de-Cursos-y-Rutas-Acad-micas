namespace EstructurasLineales
{
    interface OperacionesMyLinkedList<T>{
	 public void Empty(); //Empty the list-Vacia la lista
    
    
    public void AddToEnd(T data);//Add data to the end of the list-Agregar datos al final de la lista
    
    public void AddToBeginning(T data);//Add data to the begginig of the list-Agrega datos al principio de la lista
    
    public void Print();//Print the whole list-Imprime la lista completa

    public bool IsEmpty();//Ask if the list is empty-Pregunta si la lista está vacía
    public void CheckIndex(int index); //Check if the index is in range-Verifica que el indice este en rango de la lista
    public bool Contains(T data);//Ask if list contains given data-Pregunta si la lista contiene un dato dado
    public Node<T> Search(T data);// Return the first node that contains the data-Retorna el primer nodo que tenga el dato
    public int GetIndexOf(T data);//Return the index of the first node that contains the data-Retorna el indice del primer nodo que contenga el dato
    public Node<T> GetNodeOf(int index);// Return the node in the given index-Retorna el nodo en el índice dado 
    public T GetValue(int index);//Return the value saved in the given index-Retorna el valor guardado en el índice dado 
    public int GetLength();//Return the length of the list-Retorna la longitud de la lista

    public T Remove(int index);//Remove a value saved in the given index and return it-Remueve el valor guardado en el indice dado y lo retorna
}
}