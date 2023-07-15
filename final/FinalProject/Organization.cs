using System.Linq;
using System.Numerics;
using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonOrganization : JsonDescribedObject
    {
        protected Organization _organization { get {
                Organization organization = new Organization();
                if (base._namedObject is null) base._namedObject = organization;
                if (!base._namedObject.GetType().IsInstanceOfType(organization.GetType())) base._namedObject = organization;
                return (Organization)_namedObject;
            } set {
                _describedObject = value;
            } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ChiefAdminstativeTeam")]
        public JsonTeam ChiefAdminstativeTeam {
            get {
                Organization describedObject = new Organization();
                if (_organization is null) _organization = describedObject;
                if (!_organization.GetType().IsInstanceOfType(describedObject.GetType())) _organization = describedObject;
                return _organization.ChiefAdminstativeTeam;
            } set {
                _organization.ChiefAdminstativeTeam = value;
            } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("OrganizationTeams")]
        public Dictionary<String, JsonTeam> Teams { get { return Convert(_organization.Teams); } set { _organization.Teams = Convert(value); } }
        internal JsonOrganization() : base(new(), "")
        {
            ChiefAdminstativeTeam = new();
            Teams = new();
        }
        [JsonConstructor]
        internal JsonOrganization(JsonName Name, String Description, JsonTeam ChiefAdminTeam, Dictionary<String, JsonTeam> Teams) : base(Name, Description)
        {
            this.ChiefAdminstativeTeam= ChiefAdminTeam;
            this.Teams= Teams;
        }
        public JsonOrganization(Organization organization) : base((DescribedObject)organization) { }
        public static implicit operator JsonOrganization(Organization organization)
        {
            return new(organization);
        }
        public static implicit operator Organization(JsonOrganization organization)
        {
            return organization._organization;
        }
        public static Dictionary<String, JsonTeam> Convert(Dictionary<String, Team> team)
        {
            Dictionary<String, JsonTeam> result = new();
            foreach (String key in team.Keys)
            {
                result.Add(key, team[key]);
            }
            return result;
        }
        public static Dictionary<String, Team> Convert(Dictionary<String, JsonTeam> team)
        {
            Dictionary<String, Team> result = new();
            foreach (String key in team.Keys)
            {
                result.Add(key, team[key]);
            }
            return result;
        }
    }
    public class Organization : DescribedObjectDictionaryDescribedObjects<Team>
    {
        private Roles RoleDefinitions { get; set; }
        internal Team ChiefAdminstativeTeam { get; set; }
        internal People People
        {
            get
            {
                People result = new();
                foreach (String teamKey in Keys)
                {
                    Team team = this[teamKey];
                    People subGroup = team.People;
                    foreach (String personKey in subGroup.Keys)
                    {
                        result.Add(personKey, subGroup[personKey]);
                    }
                }
                return result;
            }
        }
        internal Dictionary<String, Team> Teams { get { return Dictionary; } set { Dictionary = value; } }
        public Organization(String organizationName, String organizationDescription, Roles organizationRoleDefinitions, Team organizationChiefAdminTeam)
        {
            Init(organizationName, organizationDescription, organizationRoleDefinitions, organizationChiefAdminTeam);
        }
        public Organization(Roles roleDefinitions, Boolean empty = true)
        {
            Init(roleDefinitions, empty);
        }
        public Organization(Boolean empty = true)
        {
            Init(empty);
        }
        public Organization(Organization organization)
        {
            Init(organization);
        }
        private void Init(Organization organization)
        {
            Init((OrganizationName)organization.Name, organization.Description, organization.RoleDefinitions, organization.ChiefAdminstativeTeam);
        }
        protected override void Init(Boolean empty = true)
        {
            Init(new(), empty);
        }
        protected void Init(Roles roleDefinitions, Boolean empty = true)
        {
            OrganizationName teamName;
            Team team;
            Person teamManager;
            PersonName managerName;
            RoleDefinitions = roleDefinitions;
            ThingName executiveRoleName = new("Executive Officer");
            ThingName managerRoleName = new("Manager");
            ThingName projectManagerRoleName = new("Project Manager");
            Role executiveRole = new Role(executiveRoleName, "Executive role.");
            Role managerRole = new Role(managerRoleName, "Manager role.");
            Role projectManagerRole = new Role(projectManagerRoleName, "Project Manager role.");
            if (!RoleDefinitions.Keys.Contains(executiveRole.ToKeyString())) RoleDefinitions.Add(executiveRole);
            if (!RoleDefinitions.Keys.Contains(managerRole.ToKeyString())) RoleDefinitions.Add(managerRole);
            if (!RoleDefinitions.Keys.Contains(projectManagerRole.ToKeyString())) RoleDefinitions.Add(projectManagerRole);
            OrganizationName executiveBoardName = new OrganizationName("Executive Board");
            PersonName chiefExecutiveName = new PersonName("Chief Executive Officer");
            if (empty)
            {
                Name = new OrganizationName("Organization");
                Description = "Empty Organization";
            }
            else
            {
                RequestName(NameType.Organization);
                RequestDescription();
            }
            Person chiefExecutive = new Person(roleDefinitions, this, null, chiefExecutiveName, executiveRole);
            chiefExecutive.RoleNames.Add(managerRole.ToKeyString());
            Team executiveBoard = new Team(RoleDefinitions, this, executiveBoardName, "Executive team", chiefExecutive);
            if (empty)
            {
                managerName = new PersonName("Team Manager");
                teamName = new OrganizationName("Team");
                teamManager = new Person(roleDefinitions, this, null, managerName, managerRole);
                team = new Team(RoleDefinitions, this, teamName, "Team", teamManager);
            }
            else
            {
                team = new Team(RoleDefinitions, this, empty);
            }
            Init((OrganizationName)Name, Description, RoleDefinitions, executiveBoard, team);
        }

        private void Init(OrganizationName name, String description, Roles roleDefinitions, Team executiveBoard, Team team)
        {
            Name = name;
            Description= description;
            RoleDefinitions = roleDefinitions;
            ChiefAdminstativeTeam = executiveBoard;
            if (!Dictionary.Keys.Contains(executiveBoard.ToKeyString()))
            {
                Dictionary.Add(executiveBoard.ToKeyString(), executiveBoard);
            }
            if (!Dictionary.Keys.Contains(team.ToKeyString())) {
                Dictionary.Add(team.ToKeyString(), team);
            }
            foreach (String key in Dictionary.Keys)
            {
                if (key != Dictionary[key].Key)
                {
                    Dictionary.Remove(key);
                }
            }
        }

        protected void Init(String organizationName, String organizationDescription, Roles organizationRoleDefinitions, String organizationChiefAdminTeamName, String organizationChiefAdminTeamDescription, String organizationChiefAdminTeamManagerName, Boolean empty = true)
        {
            Init(new OrganizationName(organizationName), organizationDescription, organizationRoleDefinitions, new Team(organizationRoleDefinitions, this, organizationChiefAdminTeamName, organizationChiefAdminTeamDescription, organizationChiefAdminTeamManagerName, false), empty);
        }
        protected void Init(OrganizationName organizationName, String organizationDescription, Roles organizationRoleDefinitions, Team organizationChiefAdminTeam, Boolean empty = true)
        {
            switch (organizationName.ToNameString())
            {
                case "":
                    Init(false);
                    break;
                default:
                    Name = organizationName;
                    Description = organizationDescription;
                    RoleDefinitions = organizationRoleDefinitions;
                    ChiefAdminstativeTeam = organizationChiefAdminTeam;
                    Add(organizationChiefAdminTeam.ToKeyString(), organizationChiefAdminTeam);
                    break;
            }
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the organization name.");
        }
        protected override void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the organization description.");
        }







        internal void DisplayPerson(String personKey)
        {
            People[personKey].Display();
        }
        private Team RequestPersonTeam()
        {
            int counter;
            int option;
            Dictionary<int, Team> optionMap;
            String response;
            Team resultTeam = null;
            while (resultTeam == null)
            {
                counter = 1;
                optionMap = new();
                foreach (String teamKey in Keys)
                {
                    this[teamKey].DisplayTeamName(counter);
                    optionMap.Add(counter, this[teamKey]);
                    counter++;
                }
                Console.WriteLine($"{counter})  *Add new Team*");
                Console.WriteLine("Select the potentialTeam the person belongs to:  ");
                response = IApplication.READ_RESPONSE();
                try
                {
                    option = int.Parse(response);
                }
                catch { option = 0; }
                if (option == counter)
                {
                    Team team = new Team(RoleDefinitions);
                    Add(team.ToKeyString(), team);
                    resultTeam = team;
                }
                else if (option > 0 && option < counter)
                {
                    resultTeam = optionMap[option];
                }
            }
            return resultTeam;
        }
        internal Team FindPersonTeam(Person person)
        {
            Team team = null;
            foreach(String potentialTeamKey in Keys)
            {
                Team potentialTeam = this[potentialTeamKey];
                foreach(String key in potentialTeam.People.Keys)
                {
                    if(potentialTeam[key] == person)
                    {
                        team = potentialTeam;
                        break;
                    }
                }
                if (team is not null) break;
            }
            return team;
        }
    }
}