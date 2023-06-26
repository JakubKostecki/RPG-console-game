namespace Projekt
{
    namespace Projekt
    {
        public class HealAbility : Ability
        {
            public int Healing { get; set; }  // ilość zdrowia przywracanego przez zdolność

            // Konstruktor klasy
            public HealAbility(string name, int cost, int healing) : base(name, cost, 0) // Zauważ, że zdolność leczenia nie zadaje obrażeń, więc ustawiamy Damage na 0
            {
                Healing = healing;
            }

            // Metoda do używania zdolności na postaci
            public void Use(Character user)
            {
                    user.Health += Healing;

                Console.WriteLine($"{user.Type} użył {Name} i odzyskał {Healing} zdrowia.");
            }
        }
    }
}
