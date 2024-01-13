namespace Library.Models.Responses;

public class SubtitlesResponse
{
    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }

    [JsonPropertyName("total_count")] public int TotalCount { get; set; }

    [JsonPropertyName("per_page")] public int PerPage { get; set; }

    [JsonPropertyName("page")] public int Page { get; set; }

    [JsonPropertyName("data")] public List<Datum> Data { get; set; }
}