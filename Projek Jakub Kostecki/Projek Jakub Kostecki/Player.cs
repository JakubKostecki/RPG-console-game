
namespace Projekt
{
    public class Player : Character
    {
        public int MaxHealth { get; set; }
        public int MaxStamina {  get; set; } 
        public int Experience { get; set; }
        public int Stamina { get; set; }
        public bool IsBleeding { get; set; }
        public bool IsHaunted { get; set; }

        public Attack StrongAttack { get; set; }
        public Attack MediumAttack { get; set; }
        public Attack WeakAttack { get; set; }
        public Ability CurrentAbility { get; set; }
        public Potion CurrentPotion { get; set; }

        public Player(string type, int health, int damage, int stamina, int blockChance, int experience, int maxHealth, int maxStamina)
        : base(type, health, damage, blockChance)
        {
            Stamina = stamina;
            Experience = experience;
            IsBleeding = false;
            IsHaunted = false;
            MaxHealth = maxHealth;
            MaxStamina = maxStamina;
            this.StrongAttack = new Attack("Silny atak", 3, 30, 200);
            this.MediumAttack = new Attack("Średni atak", 2, 50, 100);
            this.WeakAttack = new Attack("Słaby atak", 1, 70, 50);
            this.CurrentAbility = null;
            this.CurrentPotion = null;
            MaxHealth = maxHealth;
            MaxStamina = maxStamina;
        }

        public void ResetStats() 
        {
            Health = MaxHealth;
            Stamina = MaxStamina;
            IsBleeding = false;
            IsHaunted = false;
        }

        public void Attack(Character target, AttackType attackType)
        {
            // Wybieramy atak na podstawie attackType
            Attack attack;
            switch (attackType)
            {
                case AttackType.Strong:
                    attack = this.StrongAttack;
                    break;
                case AttackType.Medium:
                    attack = this.MediumAttack;
                    break;
                case AttackType.Weak:
                    attack = this.WeakAttack;
                    break;
                default:
                    throw new ArgumentException("Nieznany typ ataku");
            }

            // Sprawdzamy, czy gracz ma wystarczająco dużo staminy do wykonania ataku
            if (Stamina < attack.StaminaCost)
            {
                Console.WriteLine("Nie masz wystarczająco dużo staminy do wykonania tego ataku!");
                return;
            }

            // Generujemy losową liczbę
            Random random = new Random();
            int hitRoll = random.Next(1, 101);

            // Sprawdzamy, czy nasz atak jest skuteczny
            if (hitRoll <= attack.HitChance - target.BlockChance)
            {
                // Jeśli tak, zmniejszamy zdrowie naszego celu o ilość obrażeń
                target.Health -= attack.DamageMultiplier * Damage;
                Console.WriteLine($"{this.Type} zadaje {attack.DamageMultiplier * Damage} obrażeń {target.Type}owi. Pozostałe zdrowie {target.Type}a: {target.Health}");
            }
            else
            {
                // Jeśli nie, nasz atak jest nieskuteczny
                Console.WriteLine($"{this.Type} nie trafia {target.Type}a");
            }

            // Odejmujemy staminę niezależnie od wyniku ataku
            Stamina -= attack.StaminaCost;
        }

        public void UseAbility(Character target)
        {
            if (this.CurrentAbility != null)
            {
                this.CurrentAbility.Use(this, target);
            }
            else
            {
                Console.WriteLine("Gracz nie ma aktualnie wybranej umiejętności");
            }
            this.CurrentAbility = null;
        }

        public void UsePotion()
        {
            if (this.CurrentPotion != null)
            {
                this.CurrentPotion.Use(this);
            }
            else
            {
                Console.WriteLine("Gracz nie ma aktualnie wybranej mikstury");
            }
            this.CurrentPotion = null;
        }

        public void Rest() 
        {
            if (Stamina + 250 >= MaxStamina) 
            {
                Stamina = MaxStamina;
            }
            else
            {
                Stamina += 250;
            }
            
            Console.WriteLine("Gracz odpoczywa i odzyskuje 250 pkt. staminy");
        }

        public void Bleeding() 
        {
            if (IsBleeding == true)
                Health -= 20;
        }
    }
}
