namespace Projekt
{
    public class Boss : Monster
    {
        private IBossStrategy strategy;

        public int MaxHealth { get; set; } 

        public Boss(string type, int health, int damage,int hitChance, int blockChance, int maxHealth, int specialAbilityChance)
            : base(type, health, damage, hitChance, blockChance, specialAbilityChance)
        {
            MaxHealth = maxHealth;
            strategy = new AttackStrategy(); // startujemy z strategią ataku
        }

        public void ExecuteStrategy(Player player)
        {
            strategy.ExecuteTurn(this, player);
        }

        public void CheckHealthAndChangeStrategy()
        {
            if (Health <= MaxHealth * 0.5 && strategy is AttackStrategy)
            {
                strategy = new HealLifeStealStrategy();
            }
            else if (Health > MaxHealth * 0.5 && strategy is HealLifeStealStrategy)
            {
                strategy = new AttackStrategy();
            }
        }

        
    }


}
