namespace Projekt {
    public abstract class Monster : Character
    {
        public int SpecialAbilityChance { get; set; }
        public bool IsBleeding { get; set; }

        public int HitChance { get; set; }

        public Monster(string type, int health, int damage, int hitChance, int blockChance, int specialAbilityChance)
        : base(type, health, damage, blockChance)
        {
            SpecialAbilityChance = specialAbilityChance;
            IsBleeding = false;
            HitChance = hitChance;
        }

        public override void Attack(Character target)
        {
            // Generujemy losową liczbę
            Random random = new Random();
            int hitRoll = random.Next(1, 101);

            // Sprawdzamy, czy nasz atak jest skuteczny
            if (hitRoll <= this.HitChance - target.BlockChance)
            {
                // Jeśli tak, zmniejszamy zdrowie naszego celu o ilość obrażeń
                target.Health -= this.Damage;
                Console.WriteLine($"{this.Type} zadaje {this.Damage} obrażeń {target.Type}. Pozostałe zdrowie {target.Type}: {target.Health}");
            }
            else
            {
                // Jeśli nie, nasz atak jest nieskuteczny
                Console.WriteLine($"{this.Type} nie trafia {target.Type}");
            }
        }
        // Metoda reprezentująca specjalną zdolność potwora
        public virtual void UseSpecialAbility(Player player)
        {
            // Przeciąż w klasach dziedziczących
        }

        public void Bleeding() 
        {
            if (IsBleeding)
            {
                Health -= 20;
            }
        }
    }
}