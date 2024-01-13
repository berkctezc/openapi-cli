var builder = CoconaApp.CreateBuilder();
var services = builder.Services;

services.AddHttpClient(Constants.ClientName);
services.AddScoped<IOpenApiWrapper, OpenApiWrapper>();


var app = builder.Build();

app.AddCommand("bulk",([Option] string name, [Option] string season, [Option] string range, [Option] string? language = "en") =>
{
    var rangeShort = range.Split('-').Select(short.Parse).ToImmutableArray();

    Console.WriteLine("show:{0}, from {1} to {2} of season {3}", name, rangeShort.FirstOrDefault().ToString(), rangeShort.LastOrDefault().ToString(),  season);
});


app.AddCommand("guided", () =>
{

});
var path = Console.ReadLine();

Directory.CreateDirectory(path);
var fileUrl = "https://www.opensubtitles.com/download/ACFCE5AF6C39FABFED8FD088C3DB022A16D0861BF23A4A64A0ACA7B246D63A96ACD590EC46F5FB3A56E0DC194B74BA6E20F0F75D41CB45109EB7600AC4E01614D43E451E4289E51A775B2990DFF47D21E4B74A02A79427F7FEB3208093DDC01A181924CEA050BF50BD05723C1104DC4BE256340DA50D6FB853C2FB669220CE990EC374E2C5AA96030C22885131DFBBCA2B670DB3B51C480680E5BD47B86855CD233166A481DAA325A7EA256ECB31571A95CB67FD857402CB48CAC0EA0BDF4CB6ACED110736AAFDFC3E40A671FB6A36FFB42BC352744BD60BFD221DF8C40591D35289A02A32382424FAB4BFDAAA335A385391CF8EECD589C1D2ECD027EB810DDE60E92BC7F68C086C/subfile/string.srt";

var fileName = fileUrl.Split('/').LastOrDefault();

using var client = new HttpClient();
using var response = await client.GetAsync(fileUrl);
await using var responseStream = await response.Content.ReadAsStreamAsync();

await using var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
await responseStream.CopyToAsync(fileStream);