namespace Library.Service.Implementations;

public class OpenSubtitlesWrapper(IHttpClientFactory httpClientFactory) : IOpenSubtitlesWrapper
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Constants.ClientName);

    public async Task<LoginResponse> Login(string username, string password)
    {
        var json = JsonSerializer.Serialize(new {username, password});

        var postContent = new StringContent(json, Encoding.UTF8, "application/json");

        using var response = await _httpClient.PostAsync($"{Constants.BaseUrl}/login", postContent);
        if (!response.IsSuccessStatusCode)
            throw new Exception("Exception not handled yet");

        var responseContent = await response.Content.ReadAsStreamAsync();

        var responseJson = await JsonSerializer.DeserializeAsync<LoginResponse>(responseContent);

        return responseJson;
    }

    public async Task<SubtitlesResponse> Search(SubtitleRequest request)
    {
        var query = Helpers.CreateQueryString(request);

        using var response = await _httpClient.GetAsync($"{Constants.BaseUrl}/subtitles?{query}");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Exception not handled yet");

        var responseContent = await response.Content.ReadAsStreamAsync();

        var responseJson = await JsonSerializer.DeserializeAsync<SubtitlesResponse>(responseContent);

        return responseJson;
    }

    public async Task<List<DownloaderDto>> SearchMulti(SubtitleMultiRequest request)
    {
        var result = new List<DownloaderDto>();

        foreach (var ep in request.EpisodeList)
        {
            var searchReq = new SubtitleRequest
            {
                SeasonNumber = request.SeasonNumber,
                EpisodeNumber = ep,
                Query = request.Query
            };

            var response = await Search(searchReq);

            result.Add(
                new DownloaderDto
                {
                    FileId = response.Data.FirstOrDefault().Attributes.Files.FirstOrDefault().FileId,
                    Name = request.Query,
                    Season = request.SeasonNumber,
                    Episode = ep
                }
            );
        }

        return result;
    }

    public async Task<DownloadResponse> Download(DownloadRequest request, string token)
    {
        var json = JsonSerializer.Serialize(request);

        var postContent = new StringContent(json, Encoding.UTF8, "application/json");
        var httpMessage = new HttpRequestMessage(HttpMethod.Post, $"{Constants.BaseUrl}/download");
        httpMessage.Headers.Add("Accept", "*/*");
        httpMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        httpMessage.Content = postContent;

        using var response = await _httpClient.SendAsync(httpMessage);
        if (!response.IsSuccessStatusCode)
        {
            var responseError = await response.Content.ReadAsStringAsync();

            throw new Exception(responseError);
        }

        await using var responseContent = await response.Content.ReadAsStreamAsync();

        var responseJson = await JsonSerializer.DeserializeAsync<DownloadResponse>(responseContent);

        return responseJson;
    }

    public async Task<bool> DownloadMulti(IEnumerable<DownloaderDto> request, string token, string? path)
    {
        var slash = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\\" : "/";

        path ??= Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + slash + "subs";

        foreach (var dto in request)
        {
            var seasonStr = dto.Season >= 10 ? dto.Season.ToString() : $"0{dto.Season}";
            var epStr = dto.Season >= 10 ? dto.Season.ToString() : $"0{dto.Episode}";

            var fileName = $"{dto.Name}.S{seasonStr}.E{epStr}";

            var downloadReq = new DownloadRequest
            {
                FileId = dto.FileId,
                FileName = fileName
            };

            var downloadResponse = await Download(downloadReq, token);

            await Helpers.Download(downloadResponse.FileName, path, downloadResponse.Link);
        }

        return true;
    }
}