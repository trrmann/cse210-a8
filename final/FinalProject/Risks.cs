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
        internal void Add(Plan plan)
        {
            Console.WriteLine($"\nAdd a Risk ({plan.GetNameForMenus()})");
            Risk risk = new Risk(true);
            if (Keys.Contains(risk.Key))
            {
                Console.WriteLine($"{risk.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Remove(risk.Key);
                    Add(risk.Key, risk);
                }
            }
            else
            {
                Add(risk.Key, risk);
            }
        }
        internal Risk Select(Plan plan, Boolean ensureResult = false)
        {
            if (Count == 0)
            {
                if (ensureResult)
                {
                    Add(plan);
                    return this.First().Value;
                }
                else
                {
                    return null;
                }
            }
            else if (Count == 1) return this.First().Value;
            else
            {
                int option = 0;
                Dictionary<int, Risk> optionMap = new();
                while (option < 1)
                {
                    int counter = 1;
                    optionMap = new();
                    foreach (String key in Keys)
                    {
                        this[key].Display(counter);
                        optionMap.Add(counter, this[key]);
                        counter++;
                    }
                    Console.Write("Select a templateTask");
                    String response = IApplication.READ_RESPONSE();
                    try
                    {
                        option = int.Parse(response);
                    }
                    catch
                    {
                        option = -1;
                    }
                    if (!optionMap.Keys.Contains(option)) option = -1;
                }
                return optionMap[option];
            }
        }
        internal void Copy(Plan plan)
        {
            Console.WriteLine($"\nCopy a Risk ({plan.GetNameForMenus()})");
            Risk risk = Select(plan);
            if (risk is not null)
            {
                Console.WriteLine();
                risk.Display();
                Risk newrisk = new Risk(risk);
                newrisk.Name = "";
                newrisk.RequestName();
                if (Keys.Contains(newrisk.Key))
                {
                    Console.WriteLine($"{newrisk.Name.Value} already defined.");
                    Console.Write("overwrite (y/n)");
                    String response = IApplication.READ_RESPONSE().ToLower();
                    if (IApplication.YES_RESPONSE.Contains(response))
                    {
                        Remove(newrisk.Key);
                        Add(newrisk.Key, newrisk);
                    }
                }
                else
                {
                    Add(newrisk.Key, newrisk);
                }
            }
        }
        internal void Edit(Plan plan)
        {
            Console.WriteLine($"\nEdit a Risk ({plan.GetNameForMenus()})");
            Risk risk = Select(plan);
            if (risk is not null)
            {
                Console.WriteLine();
                risk.Display();
                Console.Write("\nrename (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.Name = "";
                    risk.RequestName();
                }
                Console.Write("\nchange description (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.Description = "";
                    risk.RequestDescription();
                }
                Console.Write("\nchange severity (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.Severity = "";
                    risk.RequestSeverity();
                }
            }
        }
        internal void RemoveRisk(Plan plan)
        {
            Console.WriteLine($"\nRemove a Risk ({plan.GetNameForMenus()})");
            Risk risk = Select(plan);
            if (risk is not null) Remove(risk.Key);
        }
        internal void Display(Plan plan)
        {
            Console.WriteLine($"\nDisplay Risks ({plan.GetNameForMenus()})\n");
            foreach (String key in Keys)
            {
                this[key].Display();
            }
        }
        internal void Export(Plan plan)
        {
            Console.WriteLine($"\nExport Risks ({plan.GetNameForMenus()})\n");
            JsonRisks risks = new(this);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
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

        internal Risks Import(Plan plan)
        {
            Console.WriteLine($"\nImport Risks ({plan.GetNameForMenus()})\n");
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
        internal Risk CreateRisk(String riskName, String riskDescription, String severity)
        {
            return new(riskName, riskDescription, severity);
        }
    }
}