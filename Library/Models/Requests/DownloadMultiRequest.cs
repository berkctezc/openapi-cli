namespace Library.Models.Requests;

public class DownloadMultiRequest
{
    public List<long> FileIds { get; set; } = Enumerable.Empty<long>().ToList();
    public string? FileNameBase { get; set; }
    public ushort Season { get; set; }
}