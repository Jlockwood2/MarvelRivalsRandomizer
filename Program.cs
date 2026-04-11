using MarvelRivalsRandomizer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseStaticFiles(); // this lets your wwwroot files be served

app.MapPost("/randomize", (string[] playerNames) =>
{
    // randomizer logic goes here
    List<Player> playerList = new List<Player>(); 
    List<Character> characterList;
    characterList = CharacterLoader.LoadCharacters();
        List<Character> pool = new List<Character>(characterList);
        for(int i = 0; i < playerNames.Length; i++)
        {   
            int index = Random.Shared.Next(0, pool.Count);
            Character chosen = pool[index];
            Player player = new Player();
            player.name = playerNames[i];
            player.character = chosen;
            playerList.Add(player);
            pool.Remove(chosen);
        }
    return playerList;
});

app.Run();