namespace Library.Models.Responses;

public class RelatedLink
{
    [JsonPropertyName("label")] public string Label { get; set; }

    [JsonPropertyName("url")] public string Url { get; set; }

    [JsonPropertyName("img_url")] public string ImgUrl { get; set; }
}