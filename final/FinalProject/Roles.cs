using System.Data;
using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonRoles : JsonDictionaryDescribedObject<JsonRole>
    {
        protected Roles _roles { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Roles")]
        public JsonDictionaryDescribedObject<JsonRole> Roles
        {
            get
            {
                Dictionary<String, JsonRole> dict = new();
                foreach (String key in _roles.Keys)
                {
                    Role role = _roles[key];
                    JsonRole json = (JsonRole)role;
                    dict.Add(key, json);
                }
                JsonDictionaryDescribedObject<JsonRole> dictionary = new(dict);
                return dictionary;
            }
            set
            {
                DictionaryDescribedObject.Clear();
                foreach (String key in value.Dictionary.Keys)
                {
                    DictionaryDescribedObject.Add(key, (Role)value.Dictionary[key]);
                }
            }
        }
        public JsonRoles() : base(new Dictionary<String, JsonRole>()) { }
        [JsonConstructor]
        public JsonRoles(JsonDictionaryDescribedObject<JsonRole> Roles) : base(new Dictionary<String, JsonRole>())
        {
            this.Roles = Roles;
        }
        public JsonRoles(Roles roles) : base(new Dictionary<String, JsonRole>())
        {
            _roles = roles;
        }
        public static implicit operator JsonRoles(Roles roles)
        {
            return new(roles);
        }
        public static implicit operator Roles(JsonRoles roles)
        {
            return roles._roles;
        }
    }
    public class Roles : DictionaryDescribedObject<Role>
    {
        internal override Role CreateNewDescribedObject(Boolean empty = true)
        {
            return new(empty);
        }
        internal override Role CreateNewDescribedObject(string roleName, string roleDescription)
        {
            return new(roleName, roleDescription);
        }
        internal override void DisplayDescribedObjectAlreadyExists(Role role)
        {
            Console.WriteLine($"_role {role.ToNameString()} already exists.");
        }
        internal override void DisplayDescribedObjectCopyMessage()
        {
            Console.WriteLine("\nCopy role");
        }
        internal override void DisplayDescribedObjectSelectObjectMessage()
        {
            Console.WriteLine($"Select the role to copy.");
        }
        internal override void DisplayDescribedObjectNameMessage()
        {
            Console.WriteLine($"\nEnter the name of the copied role.");
        }
        internal override void DisplayDescribedObjectAlreadyExistsMessage(Role role)
        {
            Console.WriteLine($"_role {role.ToNameString()} already exists.");
            Console.Write("overwrite?");
        }
        internal override void DisplayDescribedObjectListMessage()
        {
            Console.WriteLine("\nList roles");
        }
        internal override void DisplayDescribedObjectRemoveMessage()
        {
            Console.WriteLine("\nRemove role");
        }
        internal override void DisplayDescribedObjectNoneOptionMessage()
        {
            Console.WriteLine("0)  None.");
        }
        internal override void DisplayDescribedObjectSelectObjectToRemoveMessage()
        {
            Console.WriteLine($"Select the role to remove.");
        }
        internal override void DisplayDescribedObjectEditMessage()
        {
            Console.WriteLine("\nEdit role");
        }
        internal override void DisplayDescribedObjectExportMessage()
        {
            Console.WriteLine("\nExport roles");
        }
        internal override void DisplayDescribedObjectImportMessage()
        {
            Console.WriteLine("\nImport roles");
        }
        internal override void Edit()
        {
            base.Edit();
        }
    }
}