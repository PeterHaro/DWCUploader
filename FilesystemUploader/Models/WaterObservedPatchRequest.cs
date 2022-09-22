namespace FilesystemUploader.Models;

public class WaterObservedPatchRequest
{
    public string dateObserved { get; set; }
    public string flow { get; set; }

    public string GenerateRequstString()
    {
        // Need both a date and flowrate to patch the model
        if (string.IsNullOrEmpty(dateObserved) || string.IsNullOrEmpty(flow))
        {
            return "";
        }
        string retval = "{";
        retval += "\"dateObserved\": {\"type\": \"DateTime\", \"value\": " + $"\"{dateObserved}\"" + "},";
        retval += "\"flow\": \"Number\", \"value\": " + $"{flow}" + "}}";
        
        return retval;
    }
}