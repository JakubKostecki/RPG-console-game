namespace Projekt
{
    public class Paladin : Monster
    {
        public Paladin(string type, int health, int damage, int hitChance, int blockChance, int specialAbilityChance)
        : base(type, health, damage, hitChance, blockChance, specialAbilityChance)
        {
        }

        // Przeciążenie metody UseSpecialAbility dla klasy Paladin
        public override void UseSpecialAbility(Player player)
        {
            Console.WriteLine("Paladyn używa daru łaski i leczy się do pełni zdrowia!");
            Health = Health + 10; // Leczenie paladyna do pełni zdrowia
        }
    }
}
