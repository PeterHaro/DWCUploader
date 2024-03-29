﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using FilesystemUploader.Models.Input;
//
//    var alert = Alert.FromJson(jsonString);

namespace FilesystemUploader.Models.Input
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Alert
    {
        [JsonProperty("sample_id")]
        public long SampleId { get; set; }

        [JsonProperty("sn")]
        public string Sn { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("bottle_number")]
        public long BottleNumber { get; set; }

        [JsonProperty("measurement_type_id")]
        public long MeasurementTypeId { get; set; }

        [JsonProperty("measurement_type")]
        public string MeasurementType { get; set; }

        [JsonProperty("calibration_id")]
        public long CalibrationId { get; set; }

        [JsonProperty("calibration")]
        public string Calibration { get; set; }

        [JsonProperty("incubation_time")]
        public long IncubationTime { get; set; }

        [JsonProperty("blank_value")]
        public long BlankValue { get; set; }

        [JsonProperty("blank_1")]
        public long Blank1 { get; set; }

        [JsonProperty("blank_2")]
        public long Blank2 { get; set; }

        [JsonProperty("blank_3")]
        public long Blank3 { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("stopped_date")]
        public long StoppedDate { get; set; }

        [JsonProperty("time_passed")]
        public long TimePassed { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("is_real_gps")]
        public bool IsRealGps { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("battery_level")]
        public double BatteryLevel { get; set; }

        [JsonProperty("gsm_signal")]
        public long GsmSignal { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("is_in_machine")]
        public bool IsInMachine { get; set; }

        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("firmware_version")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("quality_level")]
        public long QualityLevel { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("measurement_result")]
        public List<MeasurementResult> MeasurementResult { get; set; }
    }

    public partial class MeasurementResult
    {
        [JsonProperty("detection")]
        public string Detection { get; set; }

        [JsonProperty("detection_status")]
        public long DetectionStatus { get; set; }

        [JsonProperty("detection_modify_user")]
        public string DetectionModifyUser { get; set; }

        [JsonProperty("detection_modify_time")]
        public long DetectionModifyTime { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("result")]
        public double Result { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class Alert
    {
        public static Alert FromJson(string json) => JsonConvert.DeserializeObject<Alert>(json, FilesystemUploader.Models.Input.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Alert self) => JsonConvert.SerializeObject(self, FilesystemUploader.Models.Input.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
