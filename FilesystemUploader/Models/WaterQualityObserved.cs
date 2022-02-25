using FilesystemUploader.Models.Generic;

namespace FilesystemUploader.Models;

public class WaterQualityObserved
{
    private string _id;
    private string _type;
    private string _source;
    private string _dateCreated;
    private string _dateObserved;
    private double _cod;
    private double _conductivity;
    private double _turbidity;
    private double _temperature;
    private double _ecoli;
    private Location _location;

    public WaterQualityObserved()
    {
        
    }
    
    public WaterQualityObserved(string id, string type, string source, string dateCreated, string dateObserved, double cod, double conductivity, double turbidity, double temperature, double ecoli, Location location)
    {
        _id = id;
        _type = type;
        _source = source;
        _dateCreated = dateCreated;
        _dateObserved = dateObserved;
        _cod = cod;
        _conductivity = conductivity;
        _turbidity = turbidity;
        _temperature = temperature;
        _ecoli = ecoli;
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

    public double Cod
    {
        get => _cod;
        set => _cod = value;
    }

    public double Conductivity
    {
        get => _conductivity;
        set => _conductivity = value;
    }

    public double Turbidity
    {
        get => _turbidity;
        set => _turbidity = value;
    }

    public double Temperature
    {
        get => _temperature;
        set => _temperature = value;
    }

    public double Ecoli
    {
        get => _ecoli;
        set => _ecoli = value;
    }

    public Location Location
    {
        get => _location;
        set => _location = value ?? throw new ArgumentNullException(nameof(value));
    }
}