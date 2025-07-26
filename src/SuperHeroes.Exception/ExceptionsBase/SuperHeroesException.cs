namespace SuperHeroes.Exception.ExceptionsBase
{
    public abstract class SuperHeroesException : SystemException
    {
        protected SuperHeroesException(string message) : base(message) { }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}
