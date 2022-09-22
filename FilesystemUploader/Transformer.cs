using System.Globalization;
using System.Text.Json;
using FilesystemUploader.Models;
using FilesystemUploader.Models.Generic;
using FilesystemUploader.Models.Input;
using Microsoft.VisualBasic.FileIO;

namespace FilesystemUploader;

public class Transformer
{
    private static string WaterObservedUrn = "urn:ngsi-ld:WaterObserved:";
    private const string WaterObserved = "WaterObserved";
    private const string UrlToEden = nameof(UrlToEden);

    public Transformer()
    {
    }

    public void TestTransformation()
    {
        string inputFileName = "./files/EDEN.csv";
        string outputFolder = "./files/payloads/WaterObserved";
        Directory.CreateDirectory(outputFolder);
        TransformToWaterObserved(inputFileName, outputFolder);

        string alertFile = "./files/Alert_test.json";
        outputFolder = "./files/payloads/WaterQualityObserved";
        Directory.CreateDirectory(outputFolder);
        string gmtTimeZone = "GMT+2";

        //TODO: IF FOLDER PATHS DOES NOT EXIST, CREATE
        TransformToWaterQualityObserved(alertFile, outputFolder, gmtTimeZone);
    }

    // Port from JAVA method
    public void TransformToWaterObserved(string csvInput, string outputFolder)
    {
        List<WaterObserved> waterObservedData = new List<WaterObserved>();
        using TextFieldParser parser = new TextFieldParser(csvInput);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(" ");

        while (!parser.EndOfData)
        {
            string[]? fields = parser.ReadFields();
            double lat = Convert.ToDouble(fields[3]);
            double lon = Convert.ToDouble(fields[4]);
            Location location = new Location("Point", new[] {lat, lon});

            string measurementType = GetMeasurementType(fields[0]);
            double measurementValue = GetMeasurementValue(fields[0]);

            switch (measurementType)
            {
                case "flow":
                    waterObservedData.Add(new WaterObserved
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = WaterObserved,
                        Source = UrlToEden,
                        DateObserved = fields[2],
                        Location = location,
                        Flow = measurementValue
                    });
                    break;
                case "height":
                    waterObservedData.Add(new WaterObserved
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = WaterObserved,
                        Source = UrlToEden,
                        DateObserved = fields[2],
                        Location = location,
                        Height = measurementValue
                    });
                    break;
                case "dischargeAmount":
                    waterObservedData.Add(new WaterObserved
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = WaterObserved,
                        Source = UrlToEden,
                        DateObserved = fields[2],
                        Location = location,
                        DischargeAmount = measurementValue
                    });
                    break;
            }
        }

        // GENERATE JSON OUTPUT
        var options = new JsonSerializerOptions {WriteIndented = true};
        foreach (var wo in waterObservedData)
        {
            File.WriteAllText(outputFolder + "/" + wo.Id + ".json",
                JsonSerializer
                    .Serialize(wo, options)); // Make sure audun wants to do this on a wo by wo meaning
        }
    }

    public List<WaterObservedEden> TransformToFinalModel(string csvInput)
    {
        using TextFieldParser parser = new TextFieldParser(csvInput);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(";");
        List<WaterObservedEden> edenData = new List<WaterObservedEden>();
        while (!parser.EndOfData)
        {
            string[]? fields = parser.ReadFields();
            var id = "";
            DateTime datetime = default;
            var value = "";
            var flowRate = "";
            if (fields[0].StartsWith("WaterObserved"))
            {
                // TODO: TURN INTO FUNCTION
                //TRANSFORM TO WATER OBSERVED
                id = $"{fields[0].Substring(fields[0].IndexOf(':') + 1)}";
                datetime = Convert.ToDateTime(fields[1]);
                value = fields[2];
                flowRate = fields[3];
            }
            else
            {
                Console.WriteLine("WARNING WARNING WARNING!");
                Console.WriteLine("=========================");
                Console.WriteLine("¨                        ");
                Console.WriteLine("Unknown datatype uploaded to the SFTP repository");
                Console.WriteLine("Unknown datatype uploaded to the SFTP repository");
                Console.WriteLine("Unknown datatype uploaded to the SFTP repository");
                Console.WriteLine("¨                        ");
                Console.WriteLine("=========================");
                Console.WriteLine("WARNING WARNING WARNING!");
            }

            if (flowRate.Equals("1"))
            {
                
            }

            WaterObservedEden waterObservedEden = new WaterObservedEden
            {
                id = id,
                type = "WaterObserved",
                dateObserved = new DateObserved
                {
                    type = "DateTime",
                    value = datetime.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    metadata = new object()
                },
                flow = new Flow
                {
                    type = "Number",
                    value = double.Parse(value),
                    metadata = new object()
                }
            };
            edenData.Add(waterObservedEden);
        }
        return edenData;
    }
    
    public string TransformToWaterObservedInMemory(string csvInput)
    {
        List<WaterObserved> waterObservedData = new List<WaterObserved>();
        using TextFieldParser parser = new TextFieldParser(csvInput);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(" ");

        while (!parser.EndOfData)
        {
            string[]? fields = parser.ReadFields();
            double lat = Convert.ToDouble(fields[3]);
            double lon = Convert.ToDouble(fields[4]);
            Location location = new Location("Point", new[] {lat, lon});

            string measurementType = GetMeasurementType(fields[0]);
            double measurementValue = GetMeasurementValue(fields[0]);

            switch (measurementType)
            {
                case "flow":
                    waterObservedData.Add(new WaterObserved
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = WaterObserved,
                        Source = UrlToEden,
                        DateObserved = fields[2],
                        Location = location,
                        Flow = measurementValue
                    });
                    break;
                case "height":
                    waterObservedData.Add(new WaterObserved
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = WaterObserved,
                        Source = UrlToEden,
                        DateObserved = fields[2],
                        Location = location,
                        Height = measurementValue
                    });
                    break;
                case "dischargeAmount":
                    waterObservedData.Add(new WaterObserved
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = WaterObserved,
                        Source = UrlToEden,
                        DateObserved = fields[2],
                        Location = location,
                        DischargeAmount = measurementValue
                    });
                    break;
            }
        }

        // GENERATE JSON OUTPUT
        return JsonSerializer.Serialize<List<WaterObserved>>(waterObservedData);
    }

    public void TransformToWaterQualityObserved(string jsonInput, string outputFolder, string gmtTimeZone)
    {
        var json = File.ReadAllText(jsonInput);
        var alert = Alert.FromJson(json);
        if (alert == null)
        {
            throw new ArgumentException($"Invalid Json file for: {jsonInput}");
        }

        List<MeasurementResult> mr = alert.MeasurementResult;
        double[] coordinates = new double[2];
        coordinates[0] = alert.Latitude;
        coordinates[1] = alert.Longitude;

        Location location = new Location("Point", coordinates);
        List<WaterQualityObserved> waterQualityObserveds = mr.Select(mres => new WaterQualityObserved
            {
                Id = alert.SampleId.ToString(),
                DateObserved = UnixTimeStampToDateTime(alert.Date).ToString(CultureInfo.InvariantCulture),
                Location = location,
                Temperature = alert.Temperature,
                Ecoli = mres.Result
            })
            .ToList();

        var options = new JsonSerializerOptions {WriteIndented = true};
        foreach (var wqo in waterQualityObserveds)
        {
            File.WriteAllText(outputFolder + "/" + wqo.Id + ".json",
                JsonSerializer.Serialize(wqo,
                    options)); // Make sure audun wants to do this on a wqo by wqo meaning
            Console.WriteLine($"Writing file with name: {outputFolder + "/" + wqo.Id + ".json"}");
        }
    }

    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dateTime;
    }

    // TODO: This is mock values until we receive the interpretation from SIAAP
    private string GetMeasurementType(string tagValue)
    {
        if (tagValue.Contains("_Q_"))
        {
            return "flow";
        }

        if (tagValue.Contains("_N_"))
        {
            return "height";
        }

        if (tagValue.Contains("_D_"))
        {
            return "dischargeAmount";
        }

        return "Unknown measurement type";
    }

    private double GetMeasurementValue(string tagValue)
    {
        string value = tagValue.Substring(tagValue.LastIndexOf('=') + 1);
        return double.Parse(value.Replace(",", "."));
    }
}