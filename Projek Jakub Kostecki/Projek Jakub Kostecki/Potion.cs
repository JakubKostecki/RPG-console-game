namespace Projekt
{
    public class Potion
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        
        public Potion(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public virtual void Use(Player user) {
            Console.WriteLine("Nie masz w ekwipunku żadnej mikstury");
        }
    }
}
