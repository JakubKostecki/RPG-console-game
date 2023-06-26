namespace Projekt
{
    public class BleedingAbility : Ability
    {
        public BleedingAbility(string name, int damage, int Cost, int bleedingDuration)
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
                target.IsBleeding = true;
                Console.WriteLine($"{source.Type} używa {this.Name} na {target.Type}. {target.Type} krwawi!");
            }
        }
    }
}