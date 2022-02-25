using System.Text.Json.Serialization;

namespace FilesystemUploader.Models.Generic;

public class Location
{
    [JsonInclude]
    public string _type;
    [JsonInclude]
    public double[] _coordinates;

    public Location(string type, double[] coordinates)
    {
        _type = type;
        _coordinates = coordinates;
    }

    public new string GetType()
    {
        return _type;
    }

    public double[] GetCoordinates()
    {
        return _coordinates;
    }
}