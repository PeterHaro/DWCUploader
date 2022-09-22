namespace FilesystemUploader.Models;

public class WolfgangWaterObserved
{
    public string id { get; set; }
    public string type { get; set; }
    public DateObserved dateObserved { get; set; } //Name [sic] for interoperability
    public Flow flow { get; set; } //Name [sic] for interoperability

    public string GetDateField()
    {
        return dateObserved.value;
    }

    public double GetFlowValue()
    {
        return flow.value;
    }
}