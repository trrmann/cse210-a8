using FinalProject;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonDictionaryNamedObject<JNO> where JNO : JsonNamedObject
    {
        protected DictionaryNamedObject<NamedObject> DictionaryNamedObject { get; set; }
        [JsonInclude]
        [JsonPropertyName("DNODictionary")]
        public Dictionary<String, JNO> Dictionary
        {
            get
            {
                Dictionary<String, JNO> dictionary = new();
                foreach (String key in DictionaryNamedObject.Keys)
                {
                    dictionary.Add(key, (JNO)DictionaryNamedObject[key]);
                }
                return dictionary;
            }
            set
            {
                Dictionary<String, JNO> obj = new();
                if(DictionaryNamedObject is null) DictionaryNamedObject = Convert(obj);
                DictionaryNamedObject.Clear();
                foreach (String key in value.Keys)
                {
                    DictionaryNamedObject.Add(key, value[key]);
                }
            }
        }
        [JsonConstructor]
        public JsonDictionaryNamedObject(Dictionary<String, JNO> dictionary)
        {
            Dictionary = dictionary;
        }
        public JsonDictionaryNamedObject(DictionaryNamedObject<NamedObject> dictionaryNamedObject)
        {
            DictionaryNamedObject = dictionaryNamedObject;
        }
        public static implicit operator JsonDictionaryNamedObject<JNO>(DictionaryNamedObject<NamedObject> dictionaryNamedObject)
        {
            return new(dictionaryNamedObject);
        }
        public static implicit operator DictionaryNamedObject<NamedObject>(JsonDictionaryNamedObject<JNO> dictionaryNamedObject)
        {
            return dictionaryNamedObject.DictionaryNamedObject;
        }
        internal static DictionaryNamedObject<NamedObject> Convert(Dictionary<String, JNO> value)
        {
            DictionaryNamedObject<NamedObject> result = new DNO<NamedObject>();
            foreach(String key in value.Keys)
            {
                result.Add(key, value[key]);
            }
            return result;
        }
        private class DNO<NO> : DictionaryNamedObject<NO> where NO : NamedObject
        {
            internal DNO(){
            }
        }
    }
    public abstract class DictionaryNamedObject<NO> : Dictionary<String, NO> where NO : NamedObject
    {
        protected virtual void Init(Boolean empty = true)
        {
            //base.Init(empty);
        }
        internal virtual void Display(int option = -1)
        {
            //base.Display(option);
        }
        protected virtual void DisplayNameObjectExportMessage()
        {
            Console.WriteLine("\nExport Objects");
        }
        protected virtual void DisplayNameObjectImportMessage()
        {
            Console.WriteLine("\nImport Objects");
        }
        internal virtual void Export(Dictionary<String, NO> namedObjects)
        {
            DisplayNameObjectExportMessage();
            /*TODO - Export*/
            throw new NotImplementedException();
        }
        internal virtual void Import(Dictionary<String, NO> namedObjects)
        {
            DisplayNameObjectImportMessage();
            /*TODO - Import*/
            throw new NotImplementedException();
        }
    }
}