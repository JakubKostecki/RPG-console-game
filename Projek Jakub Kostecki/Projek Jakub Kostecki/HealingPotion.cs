namespace Projekt
{
    internal class HealingPotion : Potion
    {
        public int Healing { get; set; }
        public HealingPotion(string name, int cost, int healing) : base(name, cost) 
        {
            Healing = healing;
        }

        public override void Use(Player user)
        {
            if (user.Stamina >= Cost)
            {
                user.Health = user.MaxHealth;

                Console.WriteLine($"{user.Type} użył {Name} wrócił do pełni zdrowia.");
            }
            else
            {
                Console.WriteLine($"{user.Type} nie ma wystarczająco staminy aby użyć {Name}.");
            }
        }
    }
}
