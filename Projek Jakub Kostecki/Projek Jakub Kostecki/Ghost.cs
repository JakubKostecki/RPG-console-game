namespace Projekt
{
    public class Ghost : Monster
    {
        public Ghost(string type, int health, int damage, int hitChance, int blockChance, int specialAbilityChance)
        : base(type, health, damage, hitChance, blockChance, specialAbilityChance)
        {
        }

        // Przeciążenie metody UseSpecialAbility dla klasy Paladin
        public override void UseSpecialAbility(Player player)
        {
            Console.WriteLine("Duch nawiedza gracza!!!");
            player.IsHaunted = true;
        }
    }
}