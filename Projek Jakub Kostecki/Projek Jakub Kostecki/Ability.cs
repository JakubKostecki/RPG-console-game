namespace Projekt
{
    public class Ability
    {
        public string Name { get; set; }
        public int Cost { get; set; }  // koszt staminy
        public int Damage { get; set; }  // ilość obrażeń zadawanych przez zdolność

        // Konstruktor klasy
        public Ability(string name, int cost, int damage)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
        }

        // Metoda do używania zdolności na postaci
        public virtual void Use(Player user, Character target) {
        }
    }
}