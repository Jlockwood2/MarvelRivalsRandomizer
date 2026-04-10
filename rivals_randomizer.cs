using System;

namespace MarvelRivalsRandomizer
{
    class rivals_randomizer
    {
        static int numPlayers;
        static List<Player> playerList; 
        static List<Character> characterList;
        static void Main(string[] args)
        {
            characterList = CharacterLoader.LoadCharacters();
            List<Character> pool = new List<Character>(characterList);
            for(int i = 0; i < numPlayers; i++)
            {
                int index = Random.Shared.Next(0, pool.Count);
                Character chosen = pool[index];
                playerList[i].character = chosen;
            }

        }
    }
}