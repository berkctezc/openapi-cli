namespace Library.Models.Responses;

public class Attributes
{
    [JsonPropertyName("subtitle_id")] public string SubtitleId { get; set; }

    [JsonPropertyName("language")] public string Language { get; set; }

    [JsonPropertyName("download_count")] public int DownloadCount { get; set; }

    [JsonPropertyName("new_download_count")]
    public int NewDownloadCount { get; set; }

    [JsonPropertyName("hearing_impaired")] public bool HearingImpaired { get; set; }

    [JsonPropertyName("hd")] public bool Hd { get; set; }

    [JsonPropertyName("fps")] public double Fps { get; set; }

    [JsonPropertyName("votes")] public int Votes { get; set; }

    [JsonPropertyName("ratings")] public double Ratings { get; set; }

    [JsonPropertyName("from_trusted")] public bool FromTrusted { get; set; }

    [JsonPropertyName("foreign_parts_only")]
    public bool ForeignPartsOnly { get; set; }

    [JsonPropertyName("upload_date")] public DateTime UploadDate { get; set; }

    [JsonPropertyName("ai_translated")] public bool AiTranslated { get; set; }

    [JsonPropertyName("machine_translated")]
    public bool MachineTranslated { get; set; }

    [JsonPropertyName("release")] public string Release { get; set; }

    [JsonPropertyName("comments")] public string Comments { get; set; }

    [JsonPropertyName("legacy_subtitle_id")]
    public int LegacySubtitleId { get; set; }

    [JsonPropertyName("legacy_uploader_id")]
    public int LegacyUploaderId { get; set; }

    [JsonPropertyName("uploader")] public Uploader Uploader { get; set; }

    [JsonPropertyName("feature_details")] public FeatureDetails FeatureDetails { get; set; }

    [JsonPropertyName("url")] public string Url { get; set; }

    [JsonPropertyName("related_links")] public List<RelatedLink> RelatedLinks { get; set; }

    [JsonPropertyName("files")] public List<File> Files { get; set; }
}