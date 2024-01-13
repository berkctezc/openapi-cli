namespace Library.Service.Implementations;

public class OpenApiWrapper : IOpenApiWrapper
{
    private readonly HttpClient _httpClient;

    public OpenApiWrapper(IHttpClientFactory httpClientFactory)
        => _httpClient = httpClientFactory.CreateClient(Constants.ClientName);

    public async Task<SubtitlesResponse> Search(SubtitleRequest request)
    {
        var query = Helpers.ConvertToQueryString(request);

        using var response = await _httpClient.GetAsync($"{Constants.BaseUrl}/subtitles?{query}");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Exception not handled yet");

        var responseContent = await response.Content.ReadAsStreamAsync();

        var responseJson = await JsonSerializer.DeserializeAsync<SubtitlesResponse>(responseContent);

        return responseJson;
    }

    public async Task<DownloadResponse> Download(DownloadRequest request)
    {
        var json = JsonSerializer.Serialize(request);

        var postContent = new StringContent(json, Encoding.UTF8, "application/json");

        using var response = await _httpClient.PostAsync($"{Constants.BaseUrl}/download", postContent);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Exception not handled yet");

        var responseContent = await response.Content.ReadAsStreamAsync();

        var responseJson = await JsonSerializer.DeserializeAsync<DownloadResponse>(responseContent);

        return responseJson;

    }
}