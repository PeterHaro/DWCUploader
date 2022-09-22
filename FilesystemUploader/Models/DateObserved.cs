namespace FilesystemUploader.Models;

//[Sic] Class name for interoperability
public class DateObserved
{
    public string type { get; set; }
    public string value { get; set; }
    public object metadata { get; set; }
    
    /*
     *     "dateObserved": {
        "type": "DateTime",
        "value": "2022-09-16T10:02:00.00Z",
        "metadata": {}
     */
}