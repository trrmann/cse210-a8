using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonRisks : JsonDictionaryNamedObject<JsonRisk>
    {
        protected Risks Risks { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DNORisks")]
        public new JsonDictionaryNamedObject<JsonRisk> Dictionary
        {
            get
            {
                JsonDictionaryNamedObject<JsonRisk> dictionary = new(Convert(Risks));
                foreach (String key in DictionaryNamedObject.Keys)
                {
                    dictionary.Dictionary.Add(key, (JsonRisk)(Risk)DictionaryNamedObject[key]);
                }
                return dictionary;
            }
            set
            {
                DictionaryNamedObject.Clear();
                foreach (String key in value.Dictionary.Keys)
                {
                    DictionaryNamedObject.Add(key, (Risk)value.Dictionary[key]);
                }
            }
        }
        [JsonConstructor]
        public JsonRisks(JsonDictionaryNamedObject<JsonRisk> dictionary) : base(new Dictionary<String, JsonRisk>())
        {
            Dictionary = dictionary;
        }
        public JsonRisks(Risks risks) : base(new Dictionary<String, JsonRisk>())
        {
            Risks = risks;
        }
        public static implicit operator JsonRisks(Risks risks)
        {
            return new(risks);
        }
        public static implicit operator Risks(JsonRisks risks)
        {
            return risks.Risks;
        }
        internal static JsonDictionaryNamedObject<JsonRisk> Convert(Risks value)
        {
            Dictionary<String, JsonRisk> result = new();
            foreach (String key in value.Keys)
            {
                result.Add(key, value[key]);
            }
            return new(result);
        }
    }
    public class Risks : DictionaryDescribedObject<Risk>
    {
        internal override Risk CreateNewDescribedObject(Boolean empty = true)
        {
            return new(empty);
        }
        internal override Risk CreateNewDescribedObject(String riskName, String riskDescription)
        {
            return CreateRisk(riskName, riskDescription, "");
        }
        internal Risk CreateRisk(String riskName, String riskDescription, String severity)
        {
            return new(riskName, riskDescription, severity);
        }
        internal override void DisplayDescribedObjectAlreadyExists(Risk risk)
        {
            Console.WriteLine($"Risk {risk.ToNameString()} already exists.");
        }
        internal override void DisplayDescribedObjectCopyMessage()
        {
            Console.WriteLine("\nCopy risk");
        }
        internal override void DisplayDescribedObjectSelectObjectMessage()
        {
            Console.WriteLine($"Select the risk to copy.");
        }
        internal override void DisplayDescribedObjectNameMessage()
        {
            Console.WriteLine($"\nEnter the name of the copied risk.");
        }
        internal override void DisplayDescribedObjectAlreadyExistsMessage(Risk risk)
        {
            Console.WriteLine($"Risk {risk.ToNameString()} already exists.");
            Console.Write("overwrite?");
        }
        internal override void DisplayDescribedObjectListMessage()
        {
            Console.WriteLine("\nList risks");
        }
        internal override void DisplayDescribedObjectRemoveMessage()
        {
            Console.WriteLine("\nRemove risk");
        }
        internal override void DisplayDescribedObjectNoneOptionMessage()
        {
            Console.WriteLine("0)  None.");
        }
        internal override void DisplayDescribedObjectSelectObjectToRemoveMessage()
        {
            Console.WriteLine($"Select the risk to remove.");
        }
        internal override void DisplayDescribedObjectEditMessage()
        {
            Console.WriteLine("\nEdit risk");
        }
        internal override void DisplayDescribedObjectExportMessage()
        {
            Console.WriteLine("\nExport risks");
        }
        internal override void DisplayDescribedObjectImportMessage()
        {
            Console.WriteLine("\nImport risks");
        }
        internal override void Edit()
        {
            base.Edit();
        }
    }
}