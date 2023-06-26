namespace Projekt
{
    public abstract class Character
    {
        public string Type { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public int BlockChance { get; set; }
        public bool IsBleeding { get; set; }

        public Character(string type, int health, int damage, int blockChance)
        {
            Type = type;
            Health = health;
            Damage = damage;
            BlockChance = blockChance;
            IsBleeding = false;
        }

        public virtual void Attack(Character target)
        {
            // Logika ataku
        }

        public void Block()
        {
            // Logika blokowania
        }

        public void ReceiveDamage(int damage)
        {
            // Logika otrzymywania obrażeń
        }
    }
}
