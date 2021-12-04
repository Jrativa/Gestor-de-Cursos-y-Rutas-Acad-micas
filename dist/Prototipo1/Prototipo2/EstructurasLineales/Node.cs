namespace EstructurasLineales
{
        public class Node<T>
    {
        public T data;
        public Node<T>? nextNode;
        public Node(T data)
        {
            this.data=data;
            this.nextNode=null;
        }
        public void Print()
        {
            Console.WriteLine(this.data);
            if(this.nextNode!=null){
            nextNode.Print();}
        } 
        //Add a new node with the data 
        public void AddNode(T data)
        {
            if(this.nextNode==null){this.nextNode=new Node<T>(data);}
            else{nextNode.AddNode(data);}
        }
            
    }
}