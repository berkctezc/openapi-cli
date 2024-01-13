namespace Library.Service.Abstractions;

public interface IOpenApiWrapper
{
    Task<SubtitlesResponse> Search(SubtitleRequest request);
    Task<DownloadResponse> Download(DownloadRequest request);
}