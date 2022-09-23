using System.Text.Json.Serialization;

namespace FilesystemUploader.Models.Generic;

public class AuthResponse
{
    //Try to refresh 5 minutes before the token ACTUALLY expires to avoid 401, but it might happen
    private static readonly TimeSpan Treshold = new(0, 5, 0);
    private int _expiresIn;

    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
    [JsonPropertyName("expires_in")]
    public DateTime Expires { get; set; }
    public int ExpiresIn
    {
        get => _expiresIn;
        set
        {
            _expiresIn = value;
            Expires = DateTime.UtcNow.AddSeconds(_expiresIn);
        } 
    }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
    [JsonPropertyName("scope")]
    public string Scope { get; set; }

    public bool Expired => (Expires - DateTime.UtcNow).TotalSeconds <= Treshold.TotalSeconds;
}