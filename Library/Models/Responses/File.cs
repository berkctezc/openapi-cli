﻿namespace Library.Models;

public class File
{
    [JsonPropertyName("file_id")]
    public int FileId { get; set; }

    [JsonPropertyName("cd_number")]
    public int CdNumber { get; set; }

    [JsonPropertyName("file_name")]
    public string FileName { get; set; }
}