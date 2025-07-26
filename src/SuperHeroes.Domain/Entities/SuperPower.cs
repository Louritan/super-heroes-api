namespace SuperHeroes.Domain.Entities
{
    public class SuperPower
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<HeroPower> HeroesPowers { get; set; } = [];
    }
}
