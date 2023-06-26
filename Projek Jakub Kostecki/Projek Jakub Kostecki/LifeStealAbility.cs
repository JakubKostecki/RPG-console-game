namespace Projekt
{
    public class LifeStealAbility : Ability
    {
        public int Healing { get; set; }  // ilość zdrowia przywracanego przez zdolność

        // Konstruktor klasy
        public LifeStealAbility(string name, int cost, int damage, int healing) : base(name, cost, damage)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
            Healing = healing;
        }

        // Metoda do używania zdolności na postaci
        public override void Use(Player user, Character target)
        {
            if (user.Stamina >= Cost)
            {
                target.Health -= Damage;
                user.Health += Healing;
                user.Stamina -= Cost;

                Console.WriteLine($"{user.Type} użył {Name} na {target.Type}. {target.Type} stracił {Damage} zdrowia, a {user.Type} odzyskał {Healing} zdrowia.");
            }
            else
            {
                Console.WriteLine($"{user.Type} nie ma wystarczająco staminy aby użyć {Name}.");
            }
        }
    }
}