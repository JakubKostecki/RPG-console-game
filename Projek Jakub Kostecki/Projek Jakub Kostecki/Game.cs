using System.Collections;
using System.Threading;

namespace Projekt
{
    public class Game
    {
        public bool IsRunning { get; set; }

        public Game()
        {
            IsRunning = true;
        }

        public void Run(Player Player)
        {
            while (IsRunning)
            {
                MonsterGenerator monsterGenerator = new MonsterGenerator();
                List<Monster> Monsters = new List<Monster>();
                Monsters = monsterGenerator.GenerateMonsters();
                List<Monster> deadMonsters = new List<Monster>();
                foreach (var monster in Monsters)
                {

                    while (true)
                    {
                        Player.Bleeding();
                        GameStatus.DisplayCharacterStats(monster, Player);
                        if (Player.Health <= 0)
                        {
                            IsRunning = false;
                            Console.WriteLine("Gracz umarł, koniec gry!");
                            break;
                        }

                        Console.WriteLine($"Tura {Player.Type}.");
                        Console.WriteLine("1: Atakuj silnym atakiem\n2: Atakuj średnim atakiem\n3: Atakuj słabym atakiem\n4: Użyj umiejętności\n5: Użyj mikstury\n6: Odpocznij");
                        int choice;

                        if (Player.IsHaunted)
                        {
                            Random random = new Random();
                            choice = random.Next(1, 7); // Losuje liczbę między 1 a 6.
                            Player.IsHaunted = false;
                        }
                        else
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }



                        switch (choice)
                            {
                                case 1:
                                    Player.Attack(monster, AttackType.Strong);
                                    break;
                                case 2:
                                    Player.Attack(monster, AttackType.Medium);
                                    break;
                                case 3:
                                    Player.Attack(monster, AttackType.Weak);
                                    break;
                                case 4:
                                    Player.UseAbility(monster);
                                    break;
                                case 5:
                                    Player.UsePotion();
                                    break;
                                case 6:
                                    Player.Rest();
                                    break;
                                default:
                                    Console.WriteLine("Nieznana komenda");
                                    break;
                            }


                        if (monster.Health <= 0)
                        {
                            Console.WriteLine($"{monster.Type} umarł!");

                            Loot loot = new Loot(Loot.LootType.StatBoost, 10); // Zawsze generuj wzmacniacz statystyk o wartości 10
                            loot.GenerateLootChoices(Player);

                            Player.ResetStats();

                            deadMonsters.Add(monster);
                            break;
                        }

                        Console.WriteLine($"Tura {monster.Type}a.");
                        MonsterTurn turn = new MonsterTurn(monster);
                        turn.Execute(Player);
                        turn = null;

                        if (Player.Health <= 0)
                        {
                            IsRunning = false;
                            Console.WriteLine("Gracz umarł, koniec gry!");
                            break;
                        }
                    }

                }
                Boss boss = new Boss("Najstraszniejszy Boss", 1000, 200, 30, 4, 1000, 0);
                while (boss.Health > 0 && Player.Health > 0)
                {
                    GameStatus.DisplayCharacterStats(boss, Player);
                    Console.WriteLine($"Tura {Player.Type}.");
                    Console.WriteLine("1: Atakuj silnym atakiem\n2: Atakuj średnim atakiem\n3: Atakuj słabym atakiem\n4: Użyj umiejętności\n5: Użyj mikstury\n6: Odpocznij");
                    int choice;
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Player.Attack(boss, AttackType.Strong);
                            break;
                        case 2:
                            Player.Attack(boss, AttackType.Medium);
                            break;
                        case 3:
                            Player.Attack(boss, AttackType.Weak);
                            break;
                        case 4:
                            Player.UseAbility(boss);
                            break;
                        case 5:
                            Player.UsePotion();
                            break;
                        case 6:
                            Player.Rest();
                            break;
                        default:
                            Console.WriteLine("Nieznana komenda");
                            break;
                    }

                    Console.WriteLine($"Tura {boss.Type}a.");
                    boss.ExecuteStrategy(Player);
                    boss.CheckHealthAndChangeStrategy();
                    if (Player.Health <= 0)
                    {
                        IsRunning = false;
                        Console.WriteLine("Gracz umarł, koniec gry!");
                        break;
                    }
                }
                if (boss.Health <= 0)
                {
                    Console.WriteLine($"{boss.Type} został pokonany! Wygrałeś grę!");
                }

                IsRunning = false; // Koniec gry

                foreach (var deadMonster in deadMonsters)
                {
                    Monsters.Remove(deadMonster);
                }

                if (deadMonsters.Count == Monsters.Count)
                {
                    IsRunning = false;
                    Console.WriteLine("Wszystkie potwory pokonane, koniec gry!");
                }
            }
        }
    }
}
