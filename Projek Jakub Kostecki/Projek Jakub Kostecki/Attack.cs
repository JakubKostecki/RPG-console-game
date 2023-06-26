namespace Projekt
{
    public class Attack
    {
        public string Type { get; private set; }
        public int DamageMultiplier { get; private set; }
        public int HitChance { get; private set; }
        public int StaminaCost { get; private set; }

        public Attack(string type, int damageMultiplier, int hitChance, int staminaCost)
        {
            Type = type;
            DamageMultiplier = damageMultiplier;
            HitChance = hitChance;
            StaminaCost = staminaCost;
        }
    }
}