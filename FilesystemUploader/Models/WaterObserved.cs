using System.Text.Json.Serialization;
using FilesystemUploader.Models.Generic;

namespace FilesystemUploader.Models;

public class WaterObserved
{
    private string _id;
    private string _type;
    private string _source;
    private string _dateCreated;
    private string _dateObserved;
    private double _flow;
    private double _height;
    private double _dischargeAmount;
    public Location _location; // This is public due to the fact that I wont bother writing a custom serializer

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

    public double Flow
    {
        get => _flow;
        set => _flow = value;
    }

    public double Height
    {
        get => _height;
        set => _height = value;
    }

    public double DischargeAmount
    {
        get => _dischargeAmount;
        set => _dischargeAmount = value;
    }

    public Location Location
    {
        get => _location;
        set => _location = value ?? throw new ArgumentNullException(nameof(value));
    }

    public class WaterObservedBuilder
    {
        private string _id;
        private string _type;
        private string _source;
        private string _dateCreated;
        private string _dateObserved;
        private double _flow;
        private double _height;
        private double _dischargeAmount;
        private Location _location;

        public WaterObservedBuilder()
        {
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

        public double Flow
        {
            get => _flow;
            set => _flow = value;
        }

        public double Height
        {
            get => _height;
            set => _height = value;
        }

        public double DischargeAmount
        {
            get => _dischargeAmount;
            set => _dischargeAmount = value;
        }

        public Location Location1
        {
            get => _location;
            set => _location = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}