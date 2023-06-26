using System;

namespace Projekt
{
    class MonsterTurn
    {
        public Monster Monster { get; set; }

        public MonsterTurn(Monster monster) 
        { 
            Monster = monster;
        }

        public void Execute(Player player)
        {
            Random random = new Random();

            Loot[] lootChoices = new Loot[3];

            if (random.Next(4) == 0)
                Monster.UseSpecialAbility(player);
            else
                Monster.Attack(player);
        }

    }
}
