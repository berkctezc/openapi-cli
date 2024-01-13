namespace Library.Service.Abstractions;

public interface IOpenSubtitlesWrapper
{
    Task<LoginResponse> Login(string username, string password);
    Task<SubtitlesResponse> Search(SubtitleRequest request);
    Task<List<DownloaderDto>> SearchMulti(SubtitleMultiRequest request);
    Task<DownloadResponse> Download(DownloadRequest request, string token);
    Task<bool> DownloadMulti(IEnumerable<DownloaderDto> dtos, string token, string? path);
}