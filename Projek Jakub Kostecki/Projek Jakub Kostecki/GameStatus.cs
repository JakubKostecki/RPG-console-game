using System;

namespace Projekt
{
    public class GameStatus
    {
        public static void DisplayCharacterStats(Character character, Player player)
        {
            Console.WriteLine($"\n----- Statystyki dla {player.Type} -----\n");
            Console.WriteLine($"Zdrowie: {player.Health}");
            Console.WriteLine($"Siła ataku: {player.Damage}");
            Console.WriteLine($"Stamina: {player.Stamina}");
            if(player.IsBleeding == true)
            {
                Console.WriteLine($"{player.Type} Krwawi");
            }
            if(player.IsHaunted == true)
            {
                Console.WriteLine($"{player.Type} Jest Nawiedzony");
            }
            // Wyświetl statystyki umiejętności i mikstur, jeśli postać je posiada

            Console.WriteLine($"Aktualna umiejętność: {player.CurrentAbility?.Name ?? "Brak"}");
            Console.WriteLine($"Aktualna mikstura: {player.CurrentPotion?.Name ?? "Brak"}");

            Console.WriteLine("\n-----------------------------------------\n");
            Console.WriteLine($"\n----- Statystyki dla {character.Type} -----\n");
            Console.WriteLine($"Zdrowie: {character.Health}");
            if(character.IsBleeding == true)
            {
                Console.WriteLine($"{character.Type} Krwawi");
            }
            Console.WriteLine("\n-----------------------------------------\n");
        }
    }
}
