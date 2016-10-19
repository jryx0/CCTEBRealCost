namespace CCTEB.Real.Cost.Models
{
    interface IMessage
    {
        void copy<F>(Messaging<F> right);
    }


    public class Messaging<T> : IMessage
    {
        public T Value;
        public int retType;
        public string Message;


        public void copy<F>(Messaging<F> right)
        {
            this.Message = right.Message;
            this.retType = right.retType;
        }
    }
}
