using Projekt;

public class Loot
{
    public enum LootType { StatBoost, Potion, Ability }
    public LootType Type { get; set; }
    public int Value { get; set; }
    public Potion Potion { get; set; }
    public Ability Ability { get; set; }

    public Loot(LootType type, int value)
    {
        Type = type;
        Value = value;
    }

    public Loot(Potion potion)
    {
        Type = LootType.Potion;
        Potion = potion;
    }

    public Loot(Ability ability)
    {
        Type = LootType.Ability;
        Ability = ability;
    }

    public void GenerateLootChoices(Player player)
    {
        Random random = new Random();

        Loot[] lootChoices = new Loot[3];

        // Statystyki
        int value = random.Next(1, 10); // generuj losową wartość statystyki
        lootChoices[0] = new Loot(LootType.StatBoost, value);

        // Mikstura
        // tu losujemy typ mikstury
        Potion potion;
        if (random.Next(2) == 0)
            potion = new HealingPotion("Mikstura lecznicza", 10, 10);
        else
            potion = new StaminaPotion("Mikstura wytrzymałości", 0);
        lootChoices[1] = new Loot(potion);

        // Umiejętność
        // tu losujemy typ umiejętności
        Ability ability;
        if (random.Next(3) == 0)
            ability = new BleedingAbility("krwawy cios", 10, 10, 10);
        else if (random.Next(3) == 1)
            ability = new FireballAbility("kula ognia", 30, 30, 30);
        else
            ability = new LifeStealAbility("Kradziez zycia", 30, 30, 50);
        lootChoices[2] = new Loot(ability);

        Console.WriteLine("Wybierz jedną z poniższych nagród:");
        for (int i = 0; i < 3; i++)
        {
            switch (lootChoices[i].Type)
            {
                case LootType.StatBoost:
                    Console.WriteLine($"{i + 1}: {lootChoices[i].Type}, {lootChoices[i].Value} punktów do statystyk");
                    break;
                case LootType.Potion:
                    Console.WriteLine($"{i + 1}: {lootChoices[i].Type}, {lootChoices[i].Potion.Name}");
                    break;
                case LootType.Ability:
                    Console.WriteLine($"{i + 1}: {lootChoices[i].Type}, {lootChoices[i].Ability.Name}");
                    break;
            }
        }

        int choice;
        while (true)
        {
            choice = Convert.ToInt32(Console.ReadLine()) - 1;
            if (choice >= 0 && choice < 3)
                break;
            Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
        }

        ApplyLoot(lootChoices[choice], player);
    }

    public void ApplyLoot(Loot loot, Player player)
    {
        switch (loot.Type)
        {
            case Loot.LootType.StatBoost:
                player.Damage += loot.Value;
                player.BlockChance += loot.Value;
                player.MaxHealth += loot.Value;
                player.MaxStamina += loot.Value;
                Console.WriteLine($"Zdobyłeś {loot.Value} punktów do statystyk!");
                break;
            case Loot.LootType.Potion:
                player.CurrentPotion = loot.Potion;
                Console.WriteLine($"Zdobyłeś {loot.Potion.Name}!");
                break;
            case Loot.LootType.Ability:
                player.CurrentAbility = loot.Ability;
                Console.WriteLine($"Zdobyłeś {loot.Ability.Name}!");
                break;
        }
    }
}
