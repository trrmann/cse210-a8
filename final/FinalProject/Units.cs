using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonUnits : JsonDictionaryDescribedObject<JsonUnit>
    {
        private Units _units { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Units")]
        public JsonDictionaryDescribedObject<JsonUnit> Units
        {
            get
            {
                JsonDictionaryDescribedObject<JsonUnit> dictionary = new(Convert(_units));
                foreach (String key in DictionaryDescribedObject.Keys)
                {
                    dictionary.Dictionary.Add(key, (JsonUnit)(Unit)DictionaryDescribedObject[key]);
                }
                return dictionary;
            }
            set
            {
                DictionaryDescribedObject.Clear();
                foreach (String key in value.Dictionary.Keys)
                {
                    DictionaryDescribedObject.Add(key, (Unit)value.Dictionary[key]);
                }
            }
        }
        public JsonUnits() : base(new Dictionary<String, JsonUnit>()) { }
        [JsonConstructor]
        public JsonUnits(JsonDictionaryDescribedObject<JsonUnit> Units) : base(new Dictionary<String, JsonUnit>())
        {
            this.Units = Units;
        }
        public JsonUnits(Units units) : base(new Dictionary<String, JsonUnit>())
        {
            _units = units;
        }
        public static implicit operator JsonUnits(Units units)
        {
            return new(units);
        }
        public static implicit operator Units(JsonUnits units)
        {
            return units._units;
        }
        internal static Dictionary<String, JsonUnit> Convert(Units value)
        {
            Dictionary<String, JsonUnit> result = new();
            foreach (String key in value.Keys)
            {
                result.Add(key, value[key]);
            }
            return new(result);
        }
    }
    public class Units : DictionaryDescribedObject<Unit>
    {
        internal override Unit CreateNewDescribedObject(Boolean empty = true)
        {
            return new(empty);
        }
        internal override Unit CreateNewDescribedObject(string unitName, string unitDescription)
        {
            return new(unitName, unitDescription);
        }
        internal override void DisplayDescribedObjectAlreadyExists(Unit unit)
        {
            Console.WriteLine($"_unit {unit.ToNameString()} already exists.");
        }
        internal override void DisplayDescribedObjectCopyMessage()
        {
            Console.WriteLine("\nCopy unit");
        }
        internal override void DisplayDescribedObjectSelectObjectMessage()
        {
            Console.WriteLine($"Select the unit to copy.");
        }
        internal override void DisplayDescribedObjectNameMessage()
        {
            Console.WriteLine($"\nEnter the name of the copied unit.");
        }
        internal override void DisplayDescribedObjectAlreadyExistsMessage(Unit unit)
        {
            Console.WriteLine($"_unit {unit.ToNameString()} already exists.");
            Console.Write("overwrite?");
        }
        internal override void DisplayDescribedObjectListMessage()
        {
            Console.WriteLine("\nList units");
        }
        internal override void DisplayDescribedObjectRemoveMessage()
        {
            Console.WriteLine("\nRemove unit");
        }
        internal override void DisplayDescribedObjectNoneOptionMessage()
        {
            Console.WriteLine("0)  None.");
        }
        internal override void DisplayDescribedObjectSelectObjectToRemoveMessage()
        {
            Console.WriteLine($"Select the unit to remove.");
        }
        internal override void DisplayDescribedObjectEditMessage()
        {
            Console.WriteLine("\nEdit units");
        }
        internal override void DisplayDescribedObjectExportMessage()
        {
            Console.WriteLine("\nExport units");
        }
        internal override void DisplayDescribedObjectImportMessage()
        {
            Console.WriteLine("\nImport units");
        }
        internal override void Edit()
        {
            base.Edit();
        }
    }
}