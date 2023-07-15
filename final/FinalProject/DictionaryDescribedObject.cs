using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonDictionaryDescribedObject<JDO> where JDO : JsonDescribedObject, new()
    {
        protected DictionaryDescribedObject<DescribedObject> DictionaryDescribedObject { get; set; }
        [JsonInclude]
        [JsonPropertyName("DictionaryDescribedObject")]
        public Dictionary<String, JDO> Dictionary
        {
            get
            {
                return DictionaryDescribedObject.Convert<JDO>();
            }
            set
            {
                Dictionary<String, JDO> obj = new();
                if (DictionaryDescribedObject is null) DictionaryDescribedObject = Convert(obj);
                DictionaryDescribedObject = DictionaryDescribedObject.Convert(value);
            }
        }
        [JsonConstructor]
        public JsonDictionaryDescribedObject(Dictionary<String, JDO> dictionary)
        {
            Dictionary = dictionary;
        }
        public JsonDictionaryDescribedObject(DictionaryDescribedObject<DescribedObject> dictionaryNamedObjectWithDetail)
        {
            DictionaryDescribedObject = dictionaryNamedObjectWithDetail;
        }

        public JsonDictionaryDescribedObject()
        {
        }
        internal static DictionaryDescribedObject<DescribedObject> Convert(Dictionary<String, JDO> value)
        {
            DictionaryDescribedObject<DescribedObject> result = new DDO<DescribedObject>();
            foreach (String key in value.Keys)
            {
                result.Add(key, value[key]);
            }
            return result;
        }
        private class DDO<DO> : DictionaryDescribedObject<DO> where DO : DescribedObject
        {
            internal DDO()
            {
            }
            internal override DO CreateNewDescribedObject(bool empty = true)
            {
                throw new NotImplementedException();
            }

            internal override DO CreateNewDescribedObject(string objectName, string objectDescription)
            {
                throw new NotImplementedException();
            }
        }
    }
    public abstract class DictionaryDescribedObject<DO> : Dictionary<String, DO> where DO : DescribedObject
    {
        internal DictionaryDescribedObject<DO> Convert<JNOD>(Dictionary<string, JNOD> value) where JNOD : JsonDescribedObject
        {
            Clear();
            foreach(String key in value.Keys)
            {
                DO obj = (DO)value[key];
                Add(key, obj);
            }
            return this;
        }
        internal Dictionary<String, JDO> Convert<JDO>() where JDO : JsonDescribedObject, new()
        {
            Dictionary<String, JDO> result = new();
            foreach(String key in Keys)
            {
                JsonDescribedObject json = JsonDescribedObject.Convert(this[key]);
                JDO obj = (JDO)json.Convert<JDO>();
                result.Add(key, obj);
            }
            return result;
        }
        protected virtual void Init(Boolean empty = true)
        {
            //base.Init(empty);
        }
        internal abstract DO CreateNewDescribedObject(Boolean empty = true);
        internal abstract DO CreateNewDescribedObject(string objectName, string objectDescription);
        internal virtual void DisplayDescribedObjectAlreadyExists(DO describedObject)
        {
            Console.WriteLine($"Described object {describedObject.ToNameString()} already exists.");
        }
        internal virtual void DisplayDescribedObjectCopyMessage()
        {
            Console.WriteLine("\nCopy described object");
        }
        internal virtual void DisplayDescribedObjectSelectObjectMessage()
        {
            Console.WriteLine($"Select the described object to copy.");
        }
        internal virtual void DisplayDescribedObjectNameMessage()
        {
            Console.WriteLine($"\nEnter the name of the copied object.");
        }
        internal virtual void DisplayDescribedObjectAlreadyExistsMessage(DO describedObject)
        {
            DisplayDescribedObjectAlreadyExists(describedObject);
            Console.Write("overwrite?");
        }
        internal virtual void DisplayDescribedObjectListMessage()
        {
            Console.WriteLine("\nList described objects");
        }
        internal virtual void DisplayDescribedObjectRemoveMessage()
        {
            Console.WriteLine("\nRemove described object");
        }
        internal virtual void DisplayDescribedObjectNoneOptionMessage()
        {
            Console.WriteLine("0)  None.");
        }
        internal virtual void DisplayDescribedObjectSelectObjectToRemoveMessage()
        {
            Console.WriteLine("Select the described object to remove.");
        }
        internal virtual void DisplayDescribedObjectEditMessage()
        {
            Console.WriteLine("\nEdit described object");
        }
        internal virtual void DisplayDescribedObjectExportMessage()
        {
            Console.WriteLine("\nExport described objects");
        }
        internal virtual void DisplayDescribedObjectImportMessage()
        {
            Console.WriteLine("\nImport described objects");
        }
        internal virtual void Display(int option = -1)
        {
            //base.Display(option);
        }
        internal /*virtual*/ void Add()
        {
            DO describedObject = CreateNewDescribedObject(false);
            Add(describedObject);
        }
        internal /*virtual*/ void Add(string objectName, string objectDescription)
        {
            DO describedObject = CreateNewDescribedObject(objectName, objectDescription);
            Add(describedObject);
        }
        internal /*virtual*/ void Add(DO describedObject)
        {
            if (Keys.Contains(describedObject.Key))
            {
                DisplayDescribedObjectAlreadyExists(describedObject);
                Console.Write("overwrite?");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Remove(describedObject.Key);
                    Add(describedObject.Key, describedObject);
                }
            }
            else Add(describedObject.Key, describedObject);
        }
        internal /*virtual*/ String Find(DO describedObject)
        {
            foreach (String key in Keys)
            {
                if (this[key] == describedObject) return key;
            }
            return null;
        }
        internal /*virtual*/ Boolean Contains(DO describedObject)
        {
            return Find(describedObject) != null;
        }
        internal /*virtual*/ String Find(String objectName)
        {
            foreach (String key in Keys)
            {
                if (this[key].ToNameString() == objectName) return key;
            }
            return null;
        }
        internal /*virtual*/ Boolean Contains(String objectName)
        {
            return Find(objectName) != null;
        }
        internal /*virtual*/ void Copy()
        {
            Dictionary<int, String> optionMap = new();
            int option = 0;
            while (option == 0)
            {
                DisplayDescribedObjectCopyMessage();
                int counter = 1;
                foreach (String objectKey in Keys)
                {
                    this[objectKey].Display(true, false, counter);
                    optionMap.Add(counter, objectKey);
                    counter++;
                }
                DisplayDescribedObjectSelectObjectMessage();
                String response = IApplication.READ_RESPONSE().ToLower();
                try
                {
                    option = int.Parse(response);
                }
                catch
                {
                    option = 0;
                }
                if (!optionMap.ContainsKey(option)) option = 0;
            }
            DO sourceObject = this[optionMap[option]];
            DisplayDescribedObjectNameMessage();
            String newName = IApplication.READ_RESPONSE();
            DO describedObject = (DO)sourceObject.CreateCopy(newName);
            if (Keys.Contains(describedObject.Key))
            {
                DisplayDescribedObjectAlreadyExistsMessage(describedObject);
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Remove(describedObject.Key);
                    Add(describedObject.Key, describedObject);
                }
            }
            else Add(describedObject.Key, describedObject);
        }
        internal /*virtual*/ void List()
        {
            DisplayDescribedObjectListMessage();
            int counter = 1;
            foreach (String objectKey in Keys)
            {
                DO describedObject = this[objectKey];
                describedObject.Display(true, true, counter);
                counter++;
            }
        }
        internal /*virtual*/ void Remove()
        {
            Dictionary<int, String> optionMap = new();
            int option = -1;
            while (option == -1)
            {
                DisplayDescribedObjectRemoveMessage();
                int counter = 1;
                DisplayDescribedObjectNoneOptionMessage();
                foreach (String roleKey in Keys)
                {
                    this[roleKey].Display(true, false, counter);
                    optionMap.Add(counter, roleKey);
                    counter++;
                }
                if (optionMap.Count > 0)
                {
                    DisplayDescribedObjectSelectObjectToRemoveMessage();
                    String response = IApplication.READ_RESPONSE().ToLower();
                    try
                    {
                        option = int.Parse(response);
                    }
                    catch
                    {
                        option = -1;
                    }
                }
                else option = 0;
                if (!optionMap.ContainsKey(option)) option = 0;
            }
            if (option > 0)
            {
                Remove(optionMap[option]);
            }
        }
        internal virtual void Edit()
        {
            DisplayDescribedObjectEditMessage();
        }
        internal virtual void Export(Dictionary<String, DO> describedObject)
        {
            DisplayDescribedObjectExportMessage();
            String jsonString = JsonSerializer.Serialize<Dictionary<String, DO>>(describedObject);
            Console.WriteLine("Enter the filename to export to.");
            String response = IApplication.READ_RESPONSE();
            File.WriteAllText(response, jsonString);
            /*TODO - Export*/
        }
        internal virtual void Import(Dictionary<String, DO> describedObject)
        {
            DisplayDescribedObjectImportMessage();
            Console.WriteLine("Enter the filename to import from.");
            String response = IApplication.READ_RESPONSE();
            String jsonString = File.ReadAllText(response);
            describedObject = JsonSerializer.Deserialize<Dictionary<String, DO>>(jsonString);
            /*TODO - Import*/
        }
    }
}