namespace EstructurasLineales
{
    public class MyStack<T>:MyLinkedList<T>
    {
        public MyLinkedList<T> Stack ;
        public MyStack(): base (){
            this.Stack = new MyLinkedList<T>();
        }
        public void Push(T data){
            AddToBeginning(data);
        }
        public T Pop(){
            T value=Remove(0);
            return value;
        }
        public T Peek(){
            return GetValue(0);
        }
    }
}