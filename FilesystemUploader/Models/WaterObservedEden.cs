namespace FilesystemUploader.Models;

// Naming in this class breaks with the c# standard to be interoperable with the datasapecc
public class WaterObservedEden
{
    private string _id;
    public string id
    {
        get => _id;
        set => _id = "urn:ngsi-ld:WaterObserved:" +  value;
    }
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
    
    /*public string type = "WaterObserved"; 
    public string dataProvider { get; set; }
    public string dateObserved { get; set; }
    public string dischargeAmount { get; set; }
    public string flowRate { get; set; }
    
    */
    /*
     * WaterObserved:71:fresnes_choisy;2022/09/13 21:15:00;0,000;0
    WaterObserved:69:seine_valenton_wwtp;2022/09/16 10:02:00;2,534;0

     */
}