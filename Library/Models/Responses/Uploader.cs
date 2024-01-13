namespace Library.Models;

public class Uploader
{
    [JsonPropertyName("uploader_id")]
    public int UploaderId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("rank")]
    public string Rank { get; set; }
}