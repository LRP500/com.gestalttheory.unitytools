namespace UnityTools.Runtime.Factories
{
    public interface IFactory<out T> where T : class
    {
        public T Create();
    }
    
    public interface IFactory<out T, in U> where T : class
    {
        public T Create(U param);
    }
}