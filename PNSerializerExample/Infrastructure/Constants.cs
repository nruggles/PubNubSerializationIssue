using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace PNSerializerExample.Infrastructure;

public static class Constants
{
    public static JsonSerializerSettings DefaultSettings => new()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy() //intentionally set naming to something besides the default
        },
        DefaultValueHandling = DefaultValueHandling.Populate,
        DateFormatHandling = DateFormatHandling.IsoDateFormat,
        NullValueHandling = NullValueHandling.Ignore,
        Converters = new List<JsonConverter>
        {
            //set default string enum converter so it serializes as string instead of int
            new StringEnumConverter(typeof(SnakeCaseNamingStrategy))
        }
    };
}

