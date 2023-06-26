namespace Projekt
{
    public class Orc : Monster
    {
        public Orc(string type, int health, int damage, int hitChance, int blockChance, int specialAbilityChance)
        : base(type, health, damage, hitChance, blockChance, specialAbilityChance)
        {
        }

        // Przeciążenie metody UseSpecialAbility dla klasy Orc
        public override void UseSpecialAbility(Player player)
        {
            Console.WriteLine("Ork używa szarży i nakłada efekt krwawienia na gracza!");
            player.IsBleeding = true; // Nakładanie efektu krwawienia na gracza
        }
    }
}