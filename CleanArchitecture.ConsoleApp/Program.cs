using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext dbContext = new();

void QueryStreaming()
{
    var streamers = dbContext.Streamers.ToList();
    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task AddNewRecords()
{

    Streamer streamer = new()
    {
        Nombre = "Amazon Prime",
        Url = "https://www.amazonprime.com"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
{
    new Video
    {
        Nombre = "Batman",
        StreamerId = streamer.Id,
    },
    new Video
    {
        Nombre = "Jurassic",
        StreamerId = streamer.Id,
    },
    new Video
    {
        Nombre = "Superman",
        StreamerId = 1,
    }
};

    await dbContext.AddRangeAsync(movies);

    await dbContext.SaveChangesAsync();
}