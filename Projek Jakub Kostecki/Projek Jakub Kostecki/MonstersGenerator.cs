namespace Projekt
{
    class MonsterGenerator
    {
        List<Monster> monsterDatabase = new List<Monster>()
        {
            new Orc("Ork", 200,50,50,5,10),
            new Orc("Ork-all-a-Drunk", 100,100,50,5,10),
            new Orc("Ork Warmonger", 300,25,50,5,10),
            new Paladin("Paladyn", 150,50,60,7,10),
            new Paladin("Paladin the Lightbringer", 250,20,100,2,10),
            new Paladin("Paladin the Almighty Consecrator", 200, 100, 50, 2, 10),
            new Ghost("Ghost of Lunatic", 150, 25, 50, 2, 60),
            new Ghost("Ghost of Tsushima", 250, 20, 100, 2, 10),
            new Ghost("Voidwalker the Ghost", 250, 20, 100, 2, 10)
        };

        public List<Monster> GenerateMonsters()
        {
            List<Monster> monstersToEncounter = new List<Monster>();

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int randomMonsterIndex = random.Next(monsterDatabase.Count);
                monstersToEncounter.Add(monsterDatabase[randomMonsterIndex]);
            }
            return monstersToEncounter;
        }

    }
}
