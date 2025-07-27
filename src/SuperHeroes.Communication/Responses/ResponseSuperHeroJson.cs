namespace SuperHeroes.Communication.Responses
{
    public class ResponseSuperHeroJson
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HeroName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public List<ResponseSuperPowerJson> SuperPowers { get; set; } = [];
    }
}
