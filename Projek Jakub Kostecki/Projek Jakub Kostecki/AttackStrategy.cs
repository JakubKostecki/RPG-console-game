using Projekt.Projekt;

namespace Projekt
{
    public class AttackStrategy : IBossStrategy
    {
        public void ExecuteTurn(Boss boss, Player player)
        {
            boss.Attack(player);
            Console.WriteLine($"{boss.Type} wykonuje silny atak!");
        }
    }

    public class HealLifeStealStrategy : IBossStrategy
    {
        public void ExecuteTurn(Boss boss, Player player)
        {
            
            Random random = new Random();

            if (random.Next(2) == 0) // 50% szans
            {
                BossLifeStealAbility lifeSteal = new BossLifeStealAbility("kradzież życia", 0, 50, 50);
                lifeSteal.Use(player, boss);
            }
            else
            {
                HealAbility heal = new HealAbility("Leczenie", 0, 100);
                heal.Use(boss);
            }
        }
    }


}
