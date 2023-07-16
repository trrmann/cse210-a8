using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonRisks : Dictionary<String, JsonRisk>
    {
        protected Risks _risks {
            get
            {
                Risks risks = new();
                foreach(String key in Keys)
                {
                    risks.Add(key, (Risk)this[key]);
                }
                return risks;
            }
            set
            {
                Clear();
                foreach (String key in value.Keys)
                {
                    Add(key, (JsonRisk)value[key]);
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Risks")]
        public Dictionary<String, JsonRisk> Risks
        {
            get
            {
                return this;
            }
            set
            {
                Clear();
                foreach (String key in value.Keys)
                {
                    Add(key, value[key]);
                }
            }
        }
        public JsonRisks() : base()
        {
            this.Risks = new();
        }
        [JsonConstructor]
        public JsonRisks(Dictionary<String, JsonRisk> Risks) : base()
        {
            this.Risks = Risks;
        }
        public JsonRisks(Risks Risks) : base()
        {
            _risks = Risks;
        }
        public static implicit operator JsonRisks(Risks risks)
        {
            return new(risks);
        }
        public static implicit operator Risks(JsonRisks risks)
        {
            return risks._risks;
        }
        /**
        internal static JsonDictionaryNamedObject<JsonRisk> Convert(Risks value)
        {
            Dictionary<String, JsonRisk> result = new();
            foreach (String key in value.Keys)
            {
                result.Add(key, value[key]);
            }
            return new(result);
        }
        /**/
    }
    public class Risks : Dictionary<String, Risk>
    {
        internal Risk CreateRisk(String riskName, String riskDescription, String severity)
        {
            return new(riskName, riskDescription, severity);
        }

        internal void Export()
        {
            JsonRisks risks = new(this);
            JsonSerializerOptions options = new JsonSerializerOptions {
                WriteIndented = true,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
                MaxDepth = 5
            };
            String json = JsonSerializer.Serialize(risks, options);
            Console.Write("Enter the filename to write to");
            String fileName = IApplication.READ_RESPONSE();
            File.WriteAllText(fileName, json);
        }

        internal Risks Import()
        {
            Console.Write("Enter the filename to read from");
            String fileName = IApplication.READ_RESPONSE();
            String json = File.ReadAllText(fileName);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
                MaxDepth = 5
            };
            JsonRisks risks = JsonSerializer.Deserialize<JsonRisks>(json, options);
            Risks result = (Risks)risks;
            return result;
        }
    }
}