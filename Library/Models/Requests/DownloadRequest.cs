namespace Library.Models;

public class DownloadRequest
{
    [JsonPropertyName("file_id")]
    public long FileId { get; set; } = 1;
    [JsonPropertyName("sub_format")]
    public string SubFormat { get; set; } = "srt";
    [JsonPropertyName("file_name")]
    public string? FileName { get; set; } = "my_subtitle";
}