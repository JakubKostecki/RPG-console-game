namespace Projekt
{
    public class FireballAbility : Ability
    {
        public FireballAbility(string name, int damage, int Cost, int bleedingDuration)
            : base(name, damage, Cost)
        {
            this.BleedingDuration = bleedingDuration;
        }

        public int BleedingDuration { get; set; }

        public override void Use(Player source, Character target)
        {
            base.Use(source, target);
            if (source.Stamina >= this.Cost)
            {
                target.Health -= 150;
                Console.WriteLine($"{source.Type} używa {this.Name} na {target.Type}. Zadaje 150 obrażeń");
            }
        }
    }
}