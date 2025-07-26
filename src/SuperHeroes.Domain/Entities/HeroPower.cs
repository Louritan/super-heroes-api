namespace SuperHeroes.Domain.Entities
{
    public class HeroPower
    {
        public int HeroId { get; set; }
        public SuperHero SuperHero { get; set; } = null!;
        public int PowerId { get; set; }
        public SuperPower SuperPower { get; set; } = null!;
    }
}
