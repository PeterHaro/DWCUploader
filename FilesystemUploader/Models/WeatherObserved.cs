using FilesystemUploader.Models.Generic;

namespace FilesystemUploader.Models;

public class WeatherObserved
{
    private string _id;
    private string _type;
    private string _source;
    private string _dateCreated;
    private string _dateObserved;
    private double _temperature;
    private double _precipitation;
    private double _windDirection;
    private double _windSpeed;
    private Location _location;

    public WeatherObserved(string id, string type, string source, string dateCreated, string dateObserved, double temperature, double precipitation, double windDirection, double windSpeed, Location location)
    {
        _id = id;
        _type = type;
        _source = source;
        _dateCreated = dateCreated;
        _dateObserved = dateObserved;
        _temperature = temperature;
        _precipitation = precipitation;
        _windDirection = windDirection;
        _windSpeed = windSpeed;
        _location = location;
    }

    public string Id
    {
        get => _id;
        set => _id = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Type
    {
        get => _type;
        set => _type = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Source
    {
        get => _source;
        set => _source = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DateCreated
    {
        get => _dateCreated;
        set => _dateCreated = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DateObserved
    {
        get => _dateObserved;
        set => _dateObserved = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Temperature
    {
        get => _temperature;
        set => _temperature = value;
    }

    public double Precipitation
    {
        get => _precipitation;
        set => _precipitation = value;
    }

    public double WindDirection
    {
        get => _windDirection;
        set => _windDirection = value;
    }

    public double WindSpeed
    {
        get => _windSpeed;
        set => _windSpeed = value;
    }

    public Location Location
    {
        get => _location;
        set => _location = value ?? throw new ArgumentNullException(nameof(value));
    }
}