using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonRole : JsonDescribedObject
    {
        protected Role _role { get { return (Role)base._describedObject; } set { base._describedObject = value; } }
        public JsonRole() : base(new(), "") { }
        [JsonConstructor]
        public JsonRole(JsonName Name, String Description) : base(Name, Description) { }
        public JsonRole(Role role) : base((DescribedObject)role) { }
        public static implicit operator JsonRole(Role role)
        {
            return new(role);
        }
        public static implicit operator Role(JsonRole role)
        {
            return role._role;
        }

        /**
        public static explicit operator JsonRole(JsonDescribedObject v)
        {
            throw new NotImplementedException();
        }
        /**/

        internal override JsonDescribedObject Convert<JsonDescribedObject>()
        {
            JsonRole jsonRole = (JsonRole)this;
            JsonDescribedObject json = new();
            json.NameObject = jsonRole.NameObject;
            return json;
        }
    }
    public class Role : DescribedObject
    {
        public Role(String roleName, String roleDescription)
        {
            Init(roleName, roleDescription);
        }
        public Role(Boolean empty=true)
        {
            Init(empty);
        }
        public Role(Role role)
        {
            Init(role);
        }
        public Role(ThingName executiveRoleName)
        {
            Init(executiveRoleName);
        }

        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the role name.");
        }
        protected override void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the role description.");
        }
        protected void Init(String roleName, String roleDescription, Boolean empty = true)
        {
            switch(roleName)
            {
                case "":
                    Init(false);
                    break;
                default:
                    Name = new ThingName(roleName);
                    Description = roleDescription;
                    break;
            }
        }
        private void Init(Role role)
        {
            Name = role.Name;
            Description = role.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override Role CreateCopy(String newName)
        {
            Role result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}