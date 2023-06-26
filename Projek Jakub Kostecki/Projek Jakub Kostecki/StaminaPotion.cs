namespace Projekt
{
    internal class StaminaPotion : Potion
    {
        public StaminaPotion(string name, int cost) : base(name, cost){ }

        public override void Use(Player user)
        {
            user.Stamina = user.MaxStamina;
        }
    }
}
