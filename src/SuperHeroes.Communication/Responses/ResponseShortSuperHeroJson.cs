namespace SuperHeroes.Communication.Responses
{
    public class ResponseShortSuperHeroJson
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HeroName { get; set; } = string.Empty;
        public List<ResponseShortSuperPowerJson> SuperPowers { get; set; } = [];
    }
}
