namespace Library.Models.Requests;

public class SubtitleMultiRequest
{
    public ushort SeasonNumber { get; set; } = 1;
    public ushort EpisodeList { get; set; } = 1;
    [JsonPropertyName("query")]
    public string Query { get; set; }
}