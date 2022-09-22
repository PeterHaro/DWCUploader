namespace FilesystemUploader.Models.Generic;

public class AuthResponse
{
    //Try to refresh 5 minutes before the token ACTUALLY expires to avoid 401, but it might happen
    private static readonly TimeSpan Treshold = new(0, 5, 0);
    private int _expiresIn;

    public string AccessToken { get; set; }
    public string TokenType { get; set; }
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

    public string RefreshToken { get; set; }
    public string Scope { get; set; }

    public bool Expired => (Expires - DateTime.UtcNow).TotalSeconds <= Treshold.TotalSeconds;
}