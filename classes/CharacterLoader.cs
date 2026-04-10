using System;

namespace MarvelRivalsRandomizer
{
    public List<Character> LoadCharacters()
    {
        List<Character> characterList;
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "character_list.txt"); // AppDomain.CurrentDomain.BaseDirectory is where the compiled program is actually running
        string[] lines = File.ReadAllLines(path);                                                                   // it is something like bin/Debug/net8.0/, so the three ".." take us back to the top-level directory where we can access character list
        foreach(string line in lines)
        {
            Character character = new Character();
            string[] nameRole = line.Split(",");
            string charName = nameRole[0];
            Role charRole = Enum.Parse<Role>(nameRole[1]);
            character.name = charName;
            character.role = charRole;
            character.imagePath = $"images/{nameRole[0].Replace(" ", "-").ToLower()}.jpg";
            characterList.Add(character);
        }
        return characterList;
    }
}