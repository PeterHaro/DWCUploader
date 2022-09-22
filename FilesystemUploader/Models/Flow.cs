namespace FilesystemUploader.Models;

public class Flow
{
    public string type { get; set; }
    public double value { get; set; }
    public object metadata { get; set; }
    /*
     *     "flow": {
        "type": "Number",
        "value": 2.531,
        "metadata": {}
    }
     */
}