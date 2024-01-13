namespace Library.Models.Requests;

public class SubtitleMultiRequest
{
    public ushort SeasonNumber { get; set; } = 1;
    public IEnumerable<ushort> EpisodeList { get; set; } = Enumerable.Empty<ushort>();
    public string Query { get; set; } = string.Empty;
}