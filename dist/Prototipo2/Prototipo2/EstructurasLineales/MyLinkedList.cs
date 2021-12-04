
namespace EstructurasLineales
{
public class MyLinkedList<T>:OperacionesMyLinkedList<T>
{
    protected Node<T>? headNode;
    protected Node<T>? tailNode;
    protected int length;
    public MyLinkedList() {
        this.headNode = null;
        this.tailNode = null;
        this.length = 0;
    }
  
    public Node<T> GetHeadNode(){return this.headNode;}
    public Node<T> GetTailNode(){return this.tailNode;}
   
    public void Empty(){
        this.headNode.nextNode=null;
    }
    
    public void AddToEnd(T data)
    {
        this.length += 1;
        if (this.headNode == null)
        {
            this.headNode = new Node<T>(data);
            this.tailNode = this.headNode;
        }
        else
        {
            Node<T> node = new Node<T>(data);
            this.tailNode.nextNode=node;
            this.tailNode = node;
        }
    }
        /*public void Sort()
        {
            for (int i=1;i<this.GetLength();i++)
            {
                for (int j = 0; j < this.GetLength()-i; j++)
                    if(EqualityComparer<T>.Default.GreaterThan(this.GetValue(j), this.GetValue(j + 1)) )
                    {

                    }
                    array[j], array[j + 1] = array[j + 1], array[j]
            }
                
        }*/
    
    public virtual void AddToBeginning(T data)
    {
        this.length+=1;
        if(this.headNode==null){
            this.headNode=new Node<T>(data);
        }
        else 
        {
            Node<T> newHead= new Node<T>(data);
            newHead.nextNode=headNode;
            headNode=newHead;
        }
    }
    public void Print()
    {
        if (this.headNode!=null){this.headNode.Print();}
        Console.WriteLine();
    }
    public bool IsEmpty()
    {
        if (this.length == 0) { return true; }
        else { return false; }  
    }
    public void CheckIndex(int index){
        if(index<0||index>=this.length) { throw new ArgumentOutOfRangeException ("Index out of range"); }
    }
    public bool Contains(T data)
    {   if (IsEmpty()==true) 
        {return false;} 
        else
        {
            Node<T> auxNode = headNode;
            while (auxNode != null){
                if (EqualityComparer<T>.Default.Equals(auxNode.data,data)){ return true; }
                else{auxNode=auxNode.nextNode;}
            }
            return false;
        }  
    } 
    public Node<T> Search(T data)
    {
        if (this.IsEmpty()==true){return null;}
        else{
            Node<T> auxNode = headNode;
            while (auxNode != null){
                if (EqualityComparer<T>.Default.Equals(auxNode.data,data)){ return auxNode; }
                else{auxNode=auxNode.nextNode;}
            }
            return null;
        }
    } 
   
    public int GetIndexOf(T data)
    {
        int n=0;
        Node<T> auxNode = headNode;
        while (auxNode != null){
            if (EqualityComparer<T>.Default.Equals(auxNode.data,data)){ return n; }
            else{auxNode=auxNode.nextNode; n++;}
        }
        //Return -1 if not found
        return -1;
        
    }  
    public Node<T> GetNodeOf(int index)
    {   
        CheckIndex(index);
        Node<T> auxNode = null;
        if(index<0){return auxNode;}
        int n = 0;
        auxNode = headNode;
            while (auxNode != null){
                if (n==index){ return auxNode; }
                else{auxNode=auxNode.nextNode;n++; }
            } 
        auxNode=null;
        return auxNode;   
    }
    public T GetValue(int index){
        return GetNodeOf(index).data;
    }
    public int GetLength(){return this.length;}

    public T Remove(int index)
    {
        CheckIndex(index);
        T removedElement;
        if(index==0){
            removedElement=headNode.data;
            headNode=headNode.nextNode;
        }
        else{
            Node<T> aux=headNode;
            for(int i=0;i<index;i++){
                aux=aux.nextNode;
            }
            removedElement=aux.nextNode.data;
            aux.nextNode=aux.nextNode.nextNode;
        }
        this.length--;
        return removedElement;
    }
    }
    
}
