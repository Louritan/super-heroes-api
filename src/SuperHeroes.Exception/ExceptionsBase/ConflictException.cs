using System.Net;

namespace SuperHeroes.Exception.ExceptionsBase
{
    public class ConflictException : SuperHeroesException
    {
        public ConflictException(string message) : base(message) { }

        public override int StatusCode => (int)HttpStatusCode.Conflict;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
