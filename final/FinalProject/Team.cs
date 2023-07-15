using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace FinalProject
{
    internal class JsonTeam : JsonDescribedObject
    {
        protected Team _team {
            get {
                Team team = new Team(new(), true);
                if (base._namedObject is null) base._namedObject = team;
                if (!base._namedObject.GetType().IsInstanceOfType(team.GetType())) base._namedObject = team;
                return (Team)_namedObject;
            } set {
                _describedObject = value;
            } }
        protected JsonOrganization Organization {
            get {
                return _team.Organization;
            } set {
                _team.Organization = value;
            } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Manager")]
        public JsonPerson Manager { get { return _team.Manager; } set { _team.Manager = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("TeamMembers")]
        public Dictionary<String, JsonPerson> Members { get { return Convert(_team.Members); } set { _team.Members = (People)Convert(value); } }
        internal JsonTeam() : base(null, null)
        {
            Manager = null;
            Members = null;
        }
        [JsonConstructor]
        internal JsonTeam(JsonName Name, String Description, JsonPerson Manager, Dictionary<String, JsonPerson> Members) : base(Name, Description)
        {
            this.Manager = Manager;
            this.Members = Members;
        }
        public JsonTeam(Team team) : base((DescribedObject)team) { }
        public static implicit operator JsonTeam(Team team)
        {
            return new(team);
        }
        public static implicit operator Team(JsonTeam team)
        {
            return team._team;
        }
        public static Dictionary<String, JsonPerson> Convert(Dictionary<String, Person> people)
        {
            Dictionary<String, JsonPerson> result = new();
            foreach (String key in people.Keys)
            {
                result.Add(key, people[key]);
            }
            return result;
        }
        public static Dictionary<String, Person> Convert(Dictionary<String, JsonPerson> people)
        {
            Dictionary<String, Person> result = new();
            foreach (String key in people.Keys)
            {
                result.Add(key, people[key]);
            }
            return result;
        }
    }
    public class Team : DescribedObjectDictionary<Person>
    {
        internal Organization Organization { get; set; }
        internal Person Manager { get; set; }
        internal People Members {
            get {
                People result = new();
                foreach(String personKey in Keys)
                {
                    if (!result.Keys.Contains(personKey))
                    {
                        result.Add(personKey, this[personKey]);
                    }
                }
                return result;
            }
            set {
                DescribedObjectDictionaryOfNamedObjects = value;
            }
        }
        protected List<Team> ReportingTeams { get; set; }
        protected List<String> StaffReportingTeamNames { get; set; }
        public People People {
            get
            {
                People result = new ();
                foreach (String personKey in Members.Keys)
                {
                    Person person = Members[personKey];
                    if (!result.Keys.Contains(personKey)) { result.Add(personKey, person); }
                }
                return result;
            }
        }

        //Schedule
        public Team(Roles roleDefinitions, Boolean empty = true)
        {
            Init(roleDefinitions, empty);
        }
        public Team(Roles roleDefinitions, Organization organization, Boolean empty = true)
        {
            Init(roleDefinitions, organization, empty);
        }
        public Team(Roles roleDefinitions, Organization organization, String teamName, Boolean empty = true)
        {
            Init(roleDefinitions, organization, teamName, empty);
        }
        public Team(Roles roleDefinitions, Organization organization, String chiefAdminTeamName, String chiefAdminTeamDescription, String chiefAdminTeamManagerName, Boolean empty=true)
        {
            Init(roleDefinitions, organization, chiefAdminTeamName, chiefAdminTeamDescription, chiefAdminTeamManagerName, empty);
        }
        public Team(Roles roleDefinitions, Organization organization, OrganizationName teamName, String teamDescription, Person teamManager)
        {
            Init(roleDefinitions, organization, teamName, teamDescription, teamManager);
        }
        public Team(Roles roleDefinitions, OrganizationName name, Person teamManager, Boolean empty=true)
        {
            Init(roleDefinitions, name, teamManager, empty);
        }
        protected override void Init(Boolean empty = true)
        {
            if(!empty) Init(new(), empty);
        }
        protected void Init(Roles roleDefinitions, Boolean empty = true)
        {
            Init(roleDefinitions, new(roleDefinitions, empty), empty);
        }
        protected void Init(Roles roleDefinitions, Organization organization, Boolean empty = true)
        {
            PersonName managerName;
            Person teamManager;
            Role managerRole = roleDefinitions["Manager"];
            if (empty)
            {
                Init(roleDefinitions, organization, "Team", empty);
                managerName = new PersonName("Team Manager");
                teamManager = new Person(roleDefinitions, organization, this, managerName, managerRole);
            }
            else
            {
                Organization = organization;
                RequestName(NameType.Organization);
                RequestDescription();
                teamManager = new Person(roleDefinitions, organization, this, empty);
            }
            Manager = teamManager;
            if(!teamManager.RoleNames.Contains(managerRole.ToKeyString())) teamManager.RoleNames.Add(managerRole.ToKeyString());
            if (!DescribedObjectDictionaryOfNamedObjects.Keys.Contains(teamManager.ToKeyString())) DescribedObjectDictionaryOfNamedObjects.Add(teamManager.ToKeyString(), teamManager);
        }
        protected void Init(Roles roleDefinitions, Organization organization, String teamName, Boolean empty = true)
        {
            Init(roleDefinitions, organization, teamName, teamName, "Team Manager", empty);
        }
        protected void Init(Roles roleDefinitions, Organization organization, String teamName, String teamDescription, String teamManagerName, Boolean empty = true)
        {
            Init(roleDefinitions, organization, teamName, teamDescription, new Person(roleDefinitions, organization, this, new PersonName(teamManagerName), roleDefinitions["Manager"]));
            Description = teamDescription;
        }
        protected void Init(Roles roleDefinitions,
            Organization organization,
            OrganizationName teamName,
            String description,
            Person teamManager)
        {
            Name = teamName;
            Description = description;
            Organization = organization;
            Manager = teamManager;
            Manager.Team = this;
            Manager.Organization = organization;
            Add(teamManager.ToKeyString(), teamManager);
        }
        protected void Init(Roles roleDefinitions,
            OrganizationName name,
            Person teamManager,
            Boolean empty = true)
        {
            Name = name;
            Manager = teamManager;
            teamManager.Team = this;
            Add(teamManager.ToKeyString(), teamManager);
        }
        protected void Init(Roles roleDefinitions, Organization organization, String teamName, String description, Person manager, People members, List<Team> teams, List<String> staff, Boolean empty = true)
        {
            if(empty)
            {
                base.Init(NameType.Organization, empty);
                Name = (OrganizationName)teamName;
                Description = description;
                Organization = organization;
                Manager = manager;
                Members = members;
                ReportingTeams = teams;
                StaffReportingTeamNames = staff;
            }
            else
            {
                Name = (OrganizationName)teamName;
                Description = description;
                Organization = organization;
                Manager = manager;
                Members = members;
                ReportingTeams = teams;
                StaffReportingTeamNames = staff;
                base.Init(NameType.Organization, empty);
                Manager.AddRole(roleDefinitions, "Manager");
            }
        }
        internal override String ToKeyString()
        {
            if (Organization is null)
            {
                if (Name is null) return "-";
                else return "-" + Name.ToKeyString();
            }
            else if (Name is null) return Organization.ToKeyString() + "-";
            else return Organization.ToKeyString() + "-" + Name.ToKeyString();
        }
        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the people people.");
        }
        protected override void DisplaySetName()
        {
            Console.WriteLine("\nSet people people");
        }
        protected override void DisplayRequestReSetName()
        {
            Console.WriteLine("\nRename people?");
        }
        protected override void DisplayRequestSetName()
        {
            Console.WriteLine("\nWhat is the people of the people?");
        }
        internal override void Display(int option = -1)
        {
            base.Display(option);
        }
        internal void DisplayTeamName(int counter = -1)
        {
            base.Display(true,false,counter);
        }
        internal void CopyMember(string personKey)
        {
            /*TODO - CopyMember*/
            throw new NotImplementedException();
        }
        internal void RemoveMember(String personKey)
        {
            if(Keys.Contains(personKey)) Remove(personKey);
        }
    }
}