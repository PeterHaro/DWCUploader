﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using FilesystemUploader.Models.SmartModels;
//
//    var smartModelContainer = SmartModelContainer.FromJson(jsonString);

namespace FilesystemUploader.Models.SmartModels
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SmartModelContainer
    {
        [JsonProperty("$schema")]
        public Uri Schema { get; set; }

        [JsonProperty("$id")]
        public Uri Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("definitions")]
        public Definitions Definitions { get; set; }
    }

    public partial class Definitions
    {
        [JsonProperty("EntityIdentifierType")]
        public EntityIdentifierType EntityIdentifierType { get; set; }

        [JsonProperty("email")]
        public DateObserved Email { get; set; }

        [JsonProperty("userAlias")]
        public Tag UserAlias { get; set; }

        [JsonProperty("tag")]
        public Tag Tag { get; set; }

        [JsonProperty("timeInstant")]
        public DateObserved TimeInstant { get; set; }

        [JsonProperty("dateObserved")]
        public DateObserved DateObserved { get; set; }

        [JsonProperty("dateYearLess")]
        public DateYearLess DateYearLess { get; set; }

        [JsonProperty("GSMA-Commons")]
        public GsmaCommons GsmaCommons { get; set; }

        [JsonProperty("Location-Commons")]
        public LocationCommons LocationCommons { get; set; }

        [JsonProperty("PhysicalObject-Commons")]
        public PhysicalObjectCommons PhysicalObjectCommons { get; set; }

        [JsonProperty("DateTime-Commons")]
        public DateTimeCommons DateTimeCommons { get; set; }

        [JsonProperty("Contact-Commons")]
        public ContactCommons ContactCommons { get; set; }

        [JsonProperty("Person-Commons")]
        public PersonCommons PersonCommons { get; set; }

        [JsonProperty("Extensible-Commons")]
        public ExtensibleCommons ExtensibleCommons { get; set; }

        [JsonProperty("TimeSeriesAggregation")]
        public TimeSeriesAggregation TimeSeriesAggregation { get; set; }
    }

    public partial class ContactCommons
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public ContactCommonsProperties Properties { get; set; }
    }

    public partial class ContactCommonsProperties
    {
        [JsonProperty("contactPoint")]
        public ContactPoint ContactPoint { get; set; }
    }

    public partial class ContactPoint
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("properties")]
        public ContactPointProperties Properties { get; set; }
    }

    public partial class ContactPointProperties
    {
        [JsonProperty("contactType")]
        public Tag ContactType { get; set; }

        [JsonProperty("email")]
        public Id Email { get; set; }

        [JsonProperty("telephone")]
        public Tag Telephone { get; set; }

        [JsonProperty("name")]
        public Tag Name { get; set; }

        [JsonProperty("url")]
        public DateObserved Url { get; set; }
    }

    public partial class Tag
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class Id
    {
        [JsonProperty("$ref")]
        public string Ref { get; set; }
    }

    public partial class DateObserved
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class DateTimeCommons
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("properties")]
        public DateTimeCommonsProperties Properties { get; set; }

        [JsonProperty("openingHours")]
        public Tag OpeningHours { get; set; }
    }

    public partial class DateTimeCommonsProperties
    {
        [JsonProperty("openingHoursSpecification")]
        public OpeningHoursSpecification OpeningHoursSpecification { get; set; }
    }

    public partial class OpeningHoursSpecification
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("items")]
        public OpeningHoursSpecificationItems Items { get; set; }

        [JsonProperty("minItems")]
        public long MinItems { get; set; }
    }

    public partial class OpeningHoursSpecificationItems
    {
        [JsonProperty("properties")]
        public ItemsProperties Properties { get; set; }
    }

    public partial class ItemsProperties
    {
        [JsonProperty("opens")]
        public Closes Opens { get; set; }

        [JsonProperty("closes")]
        public Closes Closes { get; set; }

        [JsonProperty("dayOfWeek")]
        public DayOfWeek DayOfWeek { get; set; }

        [JsonProperty("validFrom")]
        public Closes ValidFrom { get; set; }

        [JsonProperty("validThrough")]
        public Closes ValidThrough { get; set; }
    }

    public partial class Closes
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }
    }

    public partial class DayOfWeek
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("enum")]
        public List<string> Enum { get; set; }
    }

    public partial class DateYearLess
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }
    }

    public partial class EntityIdentifierType
    {
        [JsonProperty("anyOf")]
        public List<AnyOf> AnyOf { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class AnyOf
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("minLength", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinLength { get; set; }

        [JsonProperty("maxLength", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxLength { get; set; }

        [JsonProperty("pattern", NullValueHandling = NullValueHandling.Ignore)]
        public string Pattern { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }
    }

    public partial class ExtensibleCommons
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public ExtensibleCommonsProperties Properties { get; set; }
    }

    public partial class ExtensibleCommonsProperties
    {
        [JsonProperty("Addressable")]
        public Addressable Addressable { get; set; }

        [JsonProperty("Extensible")]
        public Extensible Extensible { get; set; }
    }

    public partial class Addressable
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("properties")]
        public AddressableProperties Properties { get; set; }
    }

    public partial class AddressableProperties
    {
        [JsonProperty("href")]
        public DateObserved Href { get; set; }

        [JsonProperty("id")]
        public Tag Id { get; set; }
    }

    public partial class Extensible
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("properties")]
        public ExtensibleProperties Properties { get; set; }

        [JsonProperty("dependencies")]
        public Dependencies Dependencies { get; set; }
    }

    public partial class Dependencies
    {
        [JsonProperty("@schemaLocation")]
        public List<string> SchemaLocation { get; set; }
    }

    public partial class ExtensibleProperties
    {
        [JsonProperty("@schemaLocation")]
        public DateObserved SchemaLocation { get; set; }

        [JsonProperty("@baseType")]
        public Tag BaseType { get; set; }

        [JsonProperty("@type")]
        public Tag Type { get; set; }
    }

    public partial class GsmaCommons
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public GsmaCommonsProperties Properties { get; set; }
    }

    public partial class GsmaCommonsProperties
    {
        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("dateCreated")]
        public DateObserved DateCreated { get; set; }

        [JsonProperty("dateModified")]
        public DateObserved DateModified { get; set; }

        [JsonProperty("source")]
        public Tag Source { get; set; }

        [JsonProperty("name")]
        public Tag Name { get; set; }

        [JsonProperty("alternateName")]
        public Tag AlternateName { get; set; }

        [JsonProperty("description")]
        public Tag Description { get; set; }

        [JsonProperty("dataProvider")]
        public Tag DataProvider { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("seeAlso")]
        public SeeAlso SeeAlso { get; set; }
    }

    public partial class Owner
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("items")]
        public Id Items { get; set; }
    }

    public partial class SeeAlso
    {
        [JsonProperty("oneOf")]
        public List<SeeAlsoOneOf> OneOf { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class SeeAlsoOneOf
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("minItems", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinItems { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public Closes Items { get; set; }

        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }
    }

    public partial class LocationCommons
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public LocationCommonsProperties Properties { get; set; }
    }

    public partial class LocationCommonsProperties
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("areaServed")]
        public Tag AreaServed { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("properties")]
        public AddressProperties Properties { get; set; }
    }

    public partial class AddressProperties
    {
        [JsonProperty("streetAddress")]
        public Tag StreetAddress { get; set; }

        [JsonProperty("addressLocality")]
        public Tag AddressLocality { get; set; }

        [JsonProperty("addressRegion")]
        public Tag AddressRegion { get; set; }

        [JsonProperty("addressCountry")]
        public Tag AddressCountry { get; set; }

        [JsonProperty("postalCode")]
        public Tag PostalCode { get; set; }

        [JsonProperty("postOfficeBoxNumber")]
        public Tag PostOfficeBoxNumber { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("oneOf")]
        public List<LocationOneOf> OneOf { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class LocationOneOf
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("required")]
        public List<RequiredElement> OneOfRequired { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("properties")]
        public OneOfProperties Properties { get; set; }
    }

    public partial class OneOfProperties
    {
        [JsonProperty("type")]
        public DayOfWeek Type { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("bbox")]
        public Bbox Bbox { get; set; }
    }

    public partial class Bbox
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("minItems", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinItems { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public AvgOverTime Items { get; set; }
    }

    public partial class AvgOverTime
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }
    }

    public partial class Coordinates
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("minItems", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinItems { get; set; }

        [JsonProperty("items")]
        public CoordinatesItems Items { get; set; }
    }

    public partial class CoordinatesItems
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("minItems", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinItems { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public ItemsItems Items { get; set; }
    }

    public partial class ItemsItems
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("minItems", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinItems { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public Bbox Items { get; set; }
    }

    public partial class PersonCommons
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public PersonCommonsProperties Properties { get; set; }
    }

    public partial class PersonCommonsProperties
    {
        [JsonProperty("person")]
        public Person Person { get; set; }
    }

    public partial class Person
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("properties")]
        public PersonProperties Properties { get; set; }
    }

    public partial class PersonProperties
    {
        [JsonProperty("additionalName")]
        public Tag AdditionalName { get; set; }

        [JsonProperty("familyName")]
        public Tag FamilyName { get; set; }

        [JsonProperty("givenName")]
        public Tag GivenName { get; set; }

        [JsonProperty("telephone")]
        public Tag Telephone { get; set; }

        [JsonProperty("email")]
        public Id Email { get; set; }
    }

    public partial class PhysicalObjectCommons
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public PhysicalObjectCommonsProperties Properties { get; set; }
    }

    public partial class PhysicalObjectCommonsProperties
    {
        [JsonProperty("color")]
        public Tag Color { get; set; }

        [JsonProperty("image")]
        public DateObserved Image { get; set; }

        [JsonProperty("annotations")]
        public Annotations Annotations { get; set; }
    }

    public partial class Annotations
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("items")]
        public AvgOverTime Items { get; set; }
    }

    public partial class TimeSeriesAggregation
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("properties")]
        public TimeSeriesAggregationProperties Properties { get; set; }
    }

    public partial class TimeSeriesAggregationProperties
    {
        [JsonProperty("avgOverTime")]
        public AvgOverTime AvgOverTime { get; set; }

        [JsonProperty("minOverTime")]
        public AvgOverTime MinOverTime { get; set; }

        [JsonProperty("maxOverTime")]
        public AvgOverTime MaxOverTime { get; set; }

        [JsonProperty("instValue")]
        public AvgOverTime InstValue { get; set; }
    }

    public enum TypeEnum { Number, String };

    public enum RequiredElement { Coordinates, Type };

    public partial class SmartModelContainer
    {
        public static SmartModelContainer FromJson(string json) => JsonConvert.DeserializeObject<SmartModelContainer>(json, FilesystemUploader.Models.SmartModels.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SmartModelContainer self) => JsonConvert.SerializeObject(self, FilesystemUploader.Models.SmartModels.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                RequiredElementConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "number":
                    return TypeEnum.Number;
                case "string":
                    return TypeEnum.String;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Number:
                    serializer.Serialize(writer, "number");
                    return;
                case TypeEnum.String:
                    serializer.Serialize(writer, "string");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class RequiredElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(RequiredElement) || t == typeof(RequiredElement?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "coordinates":
                    return RequiredElement.Coordinates;
                case "type":
                    return RequiredElement.Type;
            }
            throw new Exception("Cannot unmarshal type RequiredElement");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (RequiredElement)untypedValue;
            switch (value)
            {
                case RequiredElement.Coordinates:
                    serializer.Serialize(writer, "coordinates");
                    return;
                case RequiredElement.Type:
                    serializer.Serialize(writer, "type");
                    return;
            }
            throw new Exception("Cannot marshal type RequiredElement");
        }

        public static readonly RequiredElementConverter Singleton = new RequiredElementConverter();
    }
}
