namespace Assets.Source.Scripts.Factories
{
    public interface IFactory<T>
    {
        public T Get();
    }
}
