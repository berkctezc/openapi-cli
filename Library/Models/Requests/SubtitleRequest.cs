namespace Library.Models.Requests;

public class SubtitleRequest
{
    [JsonPropertyName("season_number")] public ushort SeasonNumber { get; set; } = 1;
    [JsonPropertyName("episode_number")] public ushort EpisodeNumber { get; set; } = 1;
    [JsonPropertyName("type")] public string? Type { get; set; } = "Episode";
    [JsonPropertyName("query")] public string Query { get; set; }
    [JsonPropertyName("languages")] public string? Languages { get; set; } = "en";
    [JsonPropertyName("machine_translated")] public bool? MachineTranslated { get; set; } = false;
    [JsonPropertyName("ai_translated")] public bool? AiTranslated { get; set; } = false;
    [JsonPropertyName("order_by")] public string? OrderBy { get; set; } = "download_count";
    [JsonPropertyName("order_direction")] public string? OrderDirection { get; set; } = "desc";
}