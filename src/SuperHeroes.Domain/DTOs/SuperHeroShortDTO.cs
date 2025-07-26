namespace SuperHeroes.Domain.DTOs
{
    public class SuperHeroShortDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HeroName { get; set; } = string.Empty;
        public List<SuperPowerShortDTO> SuperPowers { get; set; } = [];
    }
}
