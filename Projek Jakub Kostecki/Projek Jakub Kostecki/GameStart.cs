namespace Projekt
{
    public class GameStart
    {
        public void InitGame()
        {
            Console.WriteLine("Witaj w naszej grze. Wprowadź swoją nazwę:");

            string playerName = Console.ReadLine();

            Player player = new Player(playerName, 100,100,300,0,0,100,300);

            Console.WriteLine($"Cześć, {player.Type}. Wybierz poziom trudności:");
            Console.WriteLine("1. Łatwy");
            Console.WriteLine("2. Średni");
            Console.WriteLine("3. Trudny");

            int difficultyLevel;
            while (true)
            {
                difficultyLevel = Convert.ToInt32(Console.ReadLine());
                if (difficultyLevel >= 1 && difficultyLevel <= 3)
                    break;
                Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
            }

            SetPlayerStatsBasedOnDifficulty(difficultyLevel, player);

            Console.WriteLine("Zaczynamy grę!");

            Game game = new Game();
            game.Run(player);
        }

        private void SetPlayerStatsBasedOnDifficulty(int difficultyLevel, Player player)
        {
            switch (difficultyLevel)
            {
                case 1: // Łatwy
                    player.Health *= 3;
                    player.Damage *= 3;
                    player.Stamina *= 3;
                    player.MaxHealth *= 3;
                    player.MaxStamina *= 3;
                    player.BlockChance *= 3;
                    break;
                case 2: // Średni
                    player.Health *= 2;
                    player.Damage *= 2;
                    player.Stamina *= 2;
                    player.MaxHealth *= 2;
                    player.MaxStamina *= 2;
                    player.BlockChance *= 2;
                    break;
                case 3: // Trudny
                    player.Health = player.Health;
                    player.Damage = player.Damage;
                    player.Stamina = player.Stamina;
                    player.MaxHealth = player.MaxHealth;
                    player.MaxStamina = player.MaxStamina;
                    player.BlockChance = player.BlockChance;
                    break;
            }
        }
    }
}