namespace Projekt
{
    namespace Projekt
    {
        public class BossLifeStealAbility : LifeStealAbility
        {
            // Konstruktor klasy
            public BossLifeStealAbility(string name, int cost, int damage, int healing) : base(name, cost, damage, healing)
            {
            }

            // Przeciążenie metody Use specjalnie dla Bossa
            public override void Use(Player target, Character user)
            {
                // Atakowanie celu i kradzież zdrowia
                target.Health -= Damage;
                user.Health += Healing;
                Console.WriteLine($"{user.Type} użył {Name} na {target.Type}. {target.Type} stracił {Damage} zdrowia, a {user.Type} odzyskał {Healing} zdrowia.");
            }
        }
    }
}
