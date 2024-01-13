var builder = CoconaApp.CreateBuilder();
var services = builder.Services;

services.AddHttpClient(Constants.ClientName, client =>
{
    client.DefaultRequestHeaders.Add("User-Agent", Constants.UserAgent);
    client.DefaultRequestHeaders.Add("Api-Key", Constants.ApiKey);
});

services.AddScoped<IOpenSubtitlesWrapper, OpenSubtitlesWrapper>();

var app = builder.Build();

app.AddCommand("bulk", async (IOpenSubtitlesWrapper openSubtitlesWrapper, [Option] string token, [Option] string name, [Option] ushort season, [Option] string range, [Option] string? path, [Option] string? language = "en") =>
{
    var rangeShort = range.Split('-').Select(ushort.Parse);

    var episodeList = Enumerable.Range(rangeShort.FirstOrDefault(), rangeShort.LastOrDefault() - rangeShort.FirstOrDefault() + 1);

    var request = new SubtitleMultiRequest
    {
        SeasonNumber = season,
        Query = name,
        EpisodeList = episodeList.Select(x => (ushort) x)
    };

    var dto = await openSubtitlesWrapper.SearchMulti(request);
    var downloadResponse = await openSubtitlesWrapper.DownloadMulti(dto, token, path);

    Console.WriteLine(dto);
    Console.WriteLine(downloadResponse);
});


app.AddCommand("guided", () =>
{
    //TODO
});


app.AddCommand("login", async (IOpenSubtitlesWrapper openSubtitlesWrapper, [Option] string username, [Option] string password) =>
{
    var loginResponse = await openSubtitlesWrapper.Login(username, password);

    Console.WriteLine("Token:");
    Console.WriteLine(loginResponse.Token);
});

app.Run();