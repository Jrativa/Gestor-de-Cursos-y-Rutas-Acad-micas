namespace EstructurasLineales
{
    public class MyQueue<T>:MyLinkedList<T>
    {
        public MyLinkedList<T> Stack ;
        public MyQueue(): base (){
            this.Stack = new MyLinkedList<T>();
        }
        public void enqueue(T data){
            AddToEnd(data);
        }
        public T dequeue(){
            T value=Remove(0);
            return value;
        }
        public T front(){
            return GetValue(0);
        }
        public T back(){
            return this.GetTailNode().data;
        }
        public override void AddToBeginning(T data){
            throw new NotImplementedException();
        }
    }
}