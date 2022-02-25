namespace FilesystemUploader.Models.Generic;

public class Coordinate
{
    private double _latitude;
    private double _longitude;
    
    public Coordinate(double latitude, double longitude)
    {
        _latitude = latitude;
        _longitude = longitude;
    }
}