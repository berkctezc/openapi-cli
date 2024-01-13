namespace Library.Models.Requests;

public class SubtitleRequest
{
    [JsonPropertyName("season_number")] public ushort SeasonNumber { get; set; } = 1;
    [JsonPropertyName("episode_number")] public ushort EpisodeNumber { get; set; } = 1;
    [JsonPropertyName("type")] public string? Type { get; set; } = "Episode";
    [JsonPropertyName("query")] public string Query { get; set; }
    [JsonPropertyName("languages")] public string? Languages { get; set; } = "en";
}