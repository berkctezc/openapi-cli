namespace Library.Models.Requests;

public class LoginResponse
{
    [JsonPropertyName("user")]
    public User User { get; set; }

    [JsonPropertyName("token")]
    public string Token { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }
}