namespace Library.Models.Responses;

public class Datum
{
    [JsonPropertyName("id")] public string Id { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("attributes")] public Attributes Attributes { get; set; }
}