namespace SuperHeroes.Communication.Requests
{
    public class RequestSuperHeroJson
    {
        public string Name { get; set; } = string.Empty;
        public string HeroName { get; set; } = string.Empty;
        public List<int> SuperPowerIds { get; set; } = [];
        public DateTime BirthDate { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
    }
}
