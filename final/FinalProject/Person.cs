using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonPerson : JsonNamedObject
    {
        protected Person _person { get { return (Person)_namedObject; } set { _namedObject = value; } }
        /*[JsonInclude]*/
        protected Organization Organization { get { return _person.Organization; } set { _person.Organization = value; } }
        /*[JsonInclude]*/
        protected Team Team { get { return _person.Team; } set { _person.Team = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PersonalRoleKeys")]
        public List<String> PersonalRoleKeys { get { return _person.RoleNames; } set { _person.RoleNames = value; } }
        public JsonPerson() : base((JsonName)null)
        {
            PersonalRoleKeys = new();
            /*Values = organization;*/
            /*Team = team;*/
        }
        [JsonConstructor]
        public JsonPerson(JsonName Name, List<String> Roles/*, Values organization*//*, Team team*/) : base(Name)
        {
            this.PersonalRoleKeys = Roles;
            /*Values = organization;*/
            /*Team = team;*/
        }
        public JsonPerson(Person person) : base((NamedObject)person) { }
        public static implicit operator JsonPerson(Person person)
        {
            return new(person);
        }
        public static implicit operator Person(JsonPerson person)
        {
            return person._person;
        }
    }
    public class Person : NamedObject
    {
        internal List<String> RoleNames { get; set; }
        internal Organization Organization { get; set; }
        internal Team Team { get; set; }
        public Person(Roles roleDefinitions, Boolean empty=true) {
            Init(roleDefinitions, empty);
        }
        public Person(Organization organization, Team team, Boolean empty = true)
        {
            Init(organization, team, empty);
        }

        public Person(Roles roleDefinitions, Organization organization, Team team, PersonName name, Role role) : base(name)
        {
            Init(roleDefinitions, organization, team, name, role);
        }

        public Person(Roles roleDefinitions, Organization organization, Team team, Boolean empty = true)
        {
            Init(roleDefinitions, organization, team, empty);
        }
        protected virtual void Init(Roles roleDefinitions, Boolean empty = true)
        {
            if(empty)
            {
                base.Init(NameType.Person, empty);
                RoleNames = new List<String>();
                Team = new(roleDefinitions, empty);
            }
            else
            {
                base.Init(NameType.Person, empty);
            }
        }
        protected override void Init(Boolean empty = true)
        {
            base.Init(NameType.Person, empty);
            RoleNames = new List<String>();
            Team = new(new(), empty);
        }
        protected void Init(Organization organization, Team team, Boolean empty = true)
        {
            base.Init(NameType.Person, empty);
            Team = team;
            Organization = organization;
            RoleNames = new List<String>();
        }
        protected virtual void Init(Roles roleDefinitions, Organization organization, Team team, bool empty)
        {
            if (empty)
            {
                Init(roleDefinitions, organization, team, "Team Member", null);
            }
            else
            {
                Organization = organization;
                Team = team;
                base.Init(NameType.Person, empty);
                RoleNames = new List<String>();
            }
        }
        protected void Init(Roles definedRoles, Organization organization, Team team, PersonName name, Role role)
        {
            Organization = organization;
            Team = team;
            base.Init(name);
            if(role is not null) RoleNames = new List<String>() { role.Key };
            else RoleNames = new List<String>();
        }
        internal override String ToKeyString()
        {
            if(Team is null) {
                if (Name is null) return "-";
                else return "-" + Name.ToKeyString();
            } else if(Name is null)  return Team.ToKeyString() + "-";
            else return Team.ToKeyString()+"-"+Name.ToKeyString();
        }
        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the persons name.");
        }
        protected override void DisplaySetName()
        {
            Console.WriteLine("\nSet person name");
        }
        protected override void DisplayRequestReSetName()
        {
            Console.WriteLine("\nRename person?");
        }
        protected override void DisplayRequestSetName()
        {
            Console.WriteLine("\nWhat is the name of the person?");
        }
        internal override void Display(int option = -1)
        {
            base.Display(option);
        }
        internal void AddRole(Roles roleDefinitions, String roleKey)
        {
            if(!roleDefinitions.Keys.Contains(roleKey))
            {
                roleDefinitions.Add(roleKey, new(roleKey));
            }
            if (!RoleNames.Contains(roleKey))
            {
                RoleNames.Add(roleKey);
            }
        }

        internal void SetName(String response)
        {
            Name = new PersonName(response);
        }
    }
}