using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonOrganizations
    {
        private Organizations _organizations { get; set; } = new();
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("OrganizationalUnits")]
        public JsonUnits OrganizationalUnits {
            get
            {
                return _organizations.OrganizationalUnits;
            }
            set
            {
                _organizations.OrganizationalUnits = value;
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("OrganizationalRoles")]
        public JsonRoles OrganizationalRoles
        {
            get
            {
                return _organizations.OrganizationalRoles;
            }
            set
            {
                _organizations.OrganizationalRoles = value;
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Organizations")]
        public Dictionary<String, JsonOrganization> Organizations
        {
            get
            {
                Dictionary<String, JsonOrganization> organizations = new();
                foreach(String key in _organizations.Keys)
                {
                    organizations.Add(key, _organizations[key]);
                }
                return organizations;
            }
            set
            {
                _organizations.Clear();
                foreach(String key in value.Keys)
                {
                    _organizations.Add(key, value[key]);
                }
            }
        }
        public JsonOrganizations() : base()
        {
            OrganizationalRoles = new();
            OrganizationalUnits = new();
            Organizations = new();
        }
        [JsonConstructor]
        public JsonOrganizations(JsonRoles OrganizationalRoles, JsonUnits OrganizationalUnits, Dictionary<String, JsonOrganization> Organizations)
        {
            this.OrganizationalRoles = OrganizationalRoles;
            this.OrganizationalUnits = OrganizationalUnits;
            this.Organizations = Organizations;
        }
        public JsonOrganizations(Organizations organizations)
        {
            _organizations = organizations;
        }
        public static implicit operator JsonOrganizations(Organizations organizations)
        {
            return new(organizations);
        }
        public static implicit operator Organizations(JsonOrganizations organizations)
        {
            return organizations._organizations;
        }
    }
    public class Organizations : DictionaryDescribedObject<Organization>
    {
        internal Units OrganizationalUnits { get; set; }
        internal Roles OrganizationalRoles { get; set; }
        internal List<String> Roles { get {
                List<String> result = new();
                foreach(String personKey in People.Keys)
                {
                    Person person = People[personKey];
                    List<String> personRoles = person.RoleNames;
                    foreach(String role in personRoles)
                    {
                        if(!result.Contains(role)) result.Add(role);
                    }
                }
                return result;
            }
        }
        internal People People
        {
            get
            {
                People result = new();
                foreach (String teamKey in Teams.Keys)
                {
                    People subGroup = Teams[teamKey].People;
                    foreach (String personName in subGroup.Keys)
                    {
                        result.Add(personName, subGroup[personName]);
                    }
                }
                return result;
            }
        }
        internal Dictionary<String, Team> Teams {
            get
            {
                Dictionary<String, Team> result = new();
                foreach(String organizationKey in this.Keys)
                {
                    Organization organization = this[organizationKey];
                    Dictionary<String, Team> subGroup = organization.Teams;
                    foreach (String teamKey in subGroup.Keys)
                    {
                        result.Add(teamKey, subGroup[teamKey]);
                    }
                }
                return result;
            }
        }
        public Organizations(Boolean empty = true)
        {
            Init(empty);
        }
        public Organizations(Organizations organizations)
        {
            Init(organizations);
        }
        protected override void Init(Boolean empty = true)
        {
            if (empty)
            {
                Init(new(), new(), new());
            }
            else
            {
                Init(new(), new(), new());
            }
        }
        protected void Init(Organizations organizations)
        {
            Init(organizations.OrganizationalUnits, organizations.OrganizationalRoles, (Dictionary<String, Organization>)organizations);
        }
        protected void Init(Units units, Roles roleDefinitions, Dictionary<String, Organization> dictionary)
        {
            OrganizationalUnits = units;
            OrganizationalRoles = roleDefinitions;
            Clear();
            foreach(String organizationKey in dictionary.Keys)
            {
                Add(organizationKey, dictionary[organizationKey]);
            }
        }
        public static implicit operator Organizations(Plan plan)
        {
            return plan.Organizations;
        }
        /**
        public static implicit operator Units<String, JsonOrganization>(_organizations value)
        {
            Units<String, JsonOrganization> result = new();
            foreach(String key in value.Keys)
            {
                result.Add(key, value[key] as JsonOrganization);
            }
            return result;
        }
        /**/

        internal Person AddPerson()
        {
            Person person = RequestPersonTeam(OrganizationalRoles);
            Team team = FindPersonTeam(person);
            Organization organization = FindTeamOrganization(team);
            if (organization is null)
            {
                organization = new Organization(OrganizationalRoles);
                if (!ContainsKey(organization.Key))
                {
                    Add(organization.Key, organization);
                }
                if(organization.People.Count == 1) {
                    return organization.People.First().Value;
                }
            }
            if (team is null)
            {
                team = new Team(OrganizationalRoles);
                if (!organization.ContainsKey(team.Key))
                {
                    organization.Add(team.Key, team);
                }
            }
            return person;// member.AddMember(member);
        }
        internal void AddOrganization()
        {
            Organization organization = new(OrganizationalRoles, false);
            if (Keys.Contains(organization.Key))
            {
                Console.WriteLine($"Values {organization.ToNameString()} already exists.");
                Console.Write("overwrite?");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Remove(organization.Key);
                    Add(organization.Key, organization);
                }
            }
            else Add(organization.Key, organization);
        }
        internal void CopyOrganization()
        {
            /*TODO - CopyOrganization*/
            throw new NotImplementedException();
        }
        internal void RemoveOrganization(Plan plan)
        {
            Organization organization = RequestOrganization();
            if (organization.People.Keys.Contains(plan.Manager.Key))
            {
                plan.Manager = null;
            }
            Remove(organization.Key);
        }
        internal Organization RequestOrganization(Boolean all=false)
        {
            int option = -1;
            String response;
            Organization organization;
            Dictionary<int, Organization> optionList = null;
            while(option < 0)
            {
                optionList = new();
                if(all)
                {
                    Console.WriteLine("0)  All Organzations.");
                    optionList.Add(0, null);
                }
                int counter = 1;
                foreach(String organizationKey in Keys)
                {
                    organization = this[organizationKey];
                    optionList.Add(counter, organization);
                    organization.Display(true, false, counter);
                    counter++;
                }
                Console.WriteLine("\nPlease select the Values:  ");
                response = IApplication.READ_RESPONSE();
                try
                {
                    option = int.Parse(response);
                } catch
                {
                    option = -1;
                }
                if (!optionList.Keys.Contains(option)) option = -1;
            }
            return optionList[option];
        }
        internal void ListOrganizations()
        {
            Console.WriteLine("\nList Values");
            int counter = 1;
            foreach (String organizationKey in Keys)
            {
                Organization organization = this[organizationKey];
                organization.Display(true, true, counter);
                counter++;
            }
        }
        internal override void DisplayDescribedObjectExportMessage()
        {
            Console.WriteLine("\nExport Organizations");
        }
        internal override void DisplayDescribedObjectImportMessage()
        {
            Console.WriteLine("\nImport Organizations");
        }
        internal override void Export(Dictionary<String, Organization> namedObjectsWithDetail)
        {
            DisplayDescribedObjectExportMessage();
            JsonOrganizations json = new(this);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IncludeFields = true
            };
            String jsonString = JsonSerializer.Serialize<JsonOrganizations>(json, options);
            Console.WriteLine("Enter the filename to export to.");
            String response = IApplication.READ_RESPONSE();
            File.WriteAllText(response, jsonString);
            /*TODO - Export*/
        }
        internal override void Import(Dictionary<String, Organization> namedObjectsWithDetail)
        {
            DisplayDescribedObjectImportMessage();
            Console.WriteLine("Enter the filename to import from.");
            String response = IApplication.READ_RESPONSE();
            Console.WriteLine($"{Path.GetFullPath(response)}");
            String jsonString = File.ReadAllText(response);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true
            };
            JsonOrganizations json = JsonSerializer.Deserialize<JsonOrganizations>(jsonString, options);
            //Init(json);
            /*TODO - Import*/
        }
        internal void ExportOrganizations()
        {
            Export(this);
        }
        internal void ImportOrganizations()
        {
            Import(this);
        }
        internal void AddTeam()
        {
            int counter;
            Boolean done = false;
            String organizationName;
            Organization organization;
            Dictionary<int, String> optionMap = new();
            int option = -1;
            while (option == -1)
            {
                Console.WriteLine("\nAdd Team");
                if (Keys.Count > 1)
                {
                    counter = 1;
                    foreach (String organizationKey in Keys)
                    {
                        this[organizationKey].Display(true, false, counter);
                        optionMap.Add(counter, organizationKey);
                        counter++;
                    }
                    Console.WriteLine($"Select the member to add the members to.");
                    String response = IApplication.READ_RESPONSE().ToLower();
                    try
                    {
                        option = int.Parse(response);
                    }
                    catch
                    {
                        option = -1;
                    }
                    if (!optionMap.ContainsKey(option)) option = -1;
                }
                else if(Keys.Count==1)
                {
                    optionMap.Add(1, Keys.First());
                    option = 1;
                }
                else
                {
                    organization = new Organization(OrganizationalRoles, false);
                    Add(organization.ToKeyString(),organization);
                    optionMap.Add(1, Keys.First());
                    option = 1;
                    done = true;
                }
            }
            organization = this[optionMap[option]];
            organizationName = organization.ToNameString();
            if(!done)
            {
                Team team = new(OrganizationalRoles, organization, false);
                if (organization.Teams.Keys.Contains(team.Key))
                {
                    Console.WriteLine($"Team {team.ToNameString()} already exists in {organizationName}.");
                    Console.Write("overwrite?");
                    String response = IApplication.READ_RESPONSE().ToLower();
                    if (IApplication.YES_RESPONSE.Contains(response))
                    {
                        organization.Teams.Remove(team.Key);
                        organization.Teams.Add(team.Key, team);
                    }
                }
                else organization.Teams.Add(team.Key, team);
            }
        }
        internal void CopyTeam()
        {
            /*TODO - CopyTeam*/
            throw new NotImplementedException();
        }
        internal void RemoveTeam(Plan plan)
        {
            Team team = RequestTeam();
            if (team.People.Keys.Contains(plan.Manager.Key))
            {
                plan.Manager = null;
            }
            team.Organization.Teams.Remove(team.Key);
        }
        internal Team RequestTeam(Boolean all = false, Boolean allOrganizations = false)
        {
            Organization organization = RequestOrganization(allOrganizations);
            int option = -1;
            String response;
            Team team;
            Dictionary<String, Team> teams;
            if(organization is null)
            {
                teams = Teams;
            } else
            {
                teams = organization.Teams;
            }
            Dictionary<int, Team> optionList = null;
            while (option < 0)
            {
                optionList = new();
                if (all && organization is null)
                {
                    Console.WriteLine("0)  All Members.");
                    optionList.Add(0, null);
                }
                int counter = 1;
                foreach (String teamKey in teams.Keys)
                {
                    team = teams[teamKey];
                    optionList.Add(counter, team);
                    organization.Display(true, false, counter);
                    counter++;
                }
                Console.WriteLine("\nPlease select the member:  ");
                response = IApplication.READ_RESPONSE();
                try
                {
                    option = int.Parse(response);
                }
                catch
                {
                    option = -1;
                }
                if (!optionList.Keys.Contains(option)) option = -1;
            }
            return optionList[option];
        }
        internal void RemovePerson(Plan plan)
        {
            Person person = RequestPerson();
            Team team = person.Team;
            if (person==plan.Manager)
            {
                plan.Manager = null;
            }
            if (person== team.Manager)
            {
                if (team.Count > 2)
                {
                    int option = -1;
                    String response;
                    Dictionary<int, Person> optionMap = null;
                    while (option < 1)
                    {
                        int counter = 1;
                        optionMap = new();
                        foreach (String personKey in team.Keys)
                        {
                            if (team[personKey]!=person)
                            {
                                team[personKey].Display(counter);
                                optionMap.Add(counter, person);
                                counter++;
                            }
                        }
                        Console.WriteLine($"\nSelect the new manager for team {team.ToNameString()}");
                        response = IApplication.READ_RESPONSE();
                        try
                        {
                            option = int.Parse(response);
                        } catch { option = -1; }
                        if(!optionMap.Keys.Contains(option)) { option = -1; }

                    }
                    team.Manager = optionMap[option];
                    team.Manager.AddRole(plan.Organizations.OrganizationalRoles, "Manager");
                }
                else if (team.Count == 2)
                {
                    Person newManager = null;
                    foreach(String personKey in team.Keys)
                    {
                        newManager = team[personKey];
                        if (newManager != person) break;
                    }
                    team.Manager = newManager;
                    newManager.AddRole(plan.Organizations.OrganizationalRoles, "Manager");
                }
                else team.Organization.Teams.Remove(team.Key);
            }
            person.Organization.Teams.Remove(person.Key);
        }
        internal void CopyPerson(Plan plan)
        {
            /*TODO - CopyPerson*/
            throw new NotImplementedException();
        }
        internal void EditPerson(Plan plan)
        {
            /*TODO - EditPerson*/
            throw new NotImplementedException();
        }
        internal Person RequestPerson(Boolean all = false, Boolean allTeams = false, Boolean allOrganizations = false)
        {
            Team team = RequestTeam(allTeams, allOrganizations);
            int option = -1;
            String response;
            Person member;
            Dictionary<String, Person> members;
            if (team is null)
            {
                members = People;
            }
            else
            {
                members = team.DescribedObjectDictionaryOfNamedObjects;
            }
            Dictionary<int, Person> optionList = null;
            while (option < 0)
            {
                optionList = new();
                if (all && team is null)
                {
                    Console.WriteLine("0)  All Members.");
                    optionList.Add(0, null);
                }
                int counter = 1;
                foreach (String teamKey in members.Keys)
                {
                    member = members[teamKey];
                    optionList.Add(counter, member);
                    team.Display(true, false, counter);
                    counter++;
                }
                Console.WriteLine("\nPlease select the member:  ");
                response = IApplication.READ_RESPONSE();
                try
                {
                    option = int.Parse(response);
                }
                catch
                {
                    option = -1;
                }
                if (!optionList.Keys.Contains(option)) option = -1;
            }
            return optionList[option];
        }
        internal void ListTeams()
        {
            int counter;
            String organizationName;
            Dictionary<String, Team> teams;
            Organization organization = RequestOrganization(true);
            if(organization is null)
            {
                organizationName = "All Values";
                teams = Teams;
            } else
            {
                organizationName = organization.ToNameString();
                teams = organization.Teams;
            }
            Console.WriteLine($"\n{organizationName}");
            counter = 1;
            foreach(String teamKey in teams.Keys)
            {
                teams[teamKey].Display(true, false, counter);
                counter++;
            }
        }
        internal void ImportExportTeams()
        {
            /*TODO - ImportExportTeams*/
            throw new NotImplementedException();
        }
        internal void NameOrganization()
        {
            /*TODO - NameOrganization*/
            throw new NotImplementedException();
        }
        internal void DescribeOrganization()
        {
            /*TODO - DescribeOrganization*/
            throw new NotImplementedException();
        }
        internal void DisplayOrganization()
        {
            /*TODO - DisplayOrganization*/
            throw new NotImplementedException();
        }
        internal void ListMembers()
        {
            People.List(this);
        }
        internal void ImportExportTeamMembers()
        {
            /*TODO - ImportExportTeamMembers*/
            throw new NotImplementedException();
        }
        internal void NameTeam()
        {
            /*TODO - NameTeam*/
            throw new NotImplementedException();
        }
        internal void AssignTeamManager()
        {
            /*TODO - AssignTeamManager*/
            throw new NotImplementedException();
        }
        internal void AddReportingTeam()
        {
            /*TODO - AddReportingTeam*/
            throw new NotImplementedException();
        }
        internal void RemoveReportingTeam()
        {
            /*TODO - RemoveReportingTeam*/
            throw new NotImplementedException();
        }
        internal void AddTeamStaff()
        {
            /*TODO - AddTeamStaff*/
            throw new NotImplementedException();
        }
        internal void RemoveTeamStaff()
        {
            /*TODO - RemoveTeamStaff*/
            throw new NotImplementedException();
        }
        internal void DisplayTeam()
        {
            /*TODO - DisplayTeam*/
            throw new NotImplementedException();
        }
        internal void NamePerson()
        {
            String response;
            int orgnizationCounter, teamCounter, memberCounter;
            String organizationName, teamName, memberName;
            Dictionary<int, String> organizationOptionMap = new();
            Dictionary<int, String> teamOptionMap = new();
            Dictionary<int, String> memberOptionMap = new();
            int organizationOption = -1;
            int teamOption = -1;
            int memberOption = -1;
            if (Keys.Count > 0)
            {
                while (organizationOption == -1)
                {
                    Console.WriteLine("\nReassign Member _name");
                    orgnizationCounter = 1;
                    if (Keys.Count > 1)
                    {
                        foreach (String organizationKey in Keys)
                        {
                            this[organizationKey].Display(true, false, orgnizationCounter);
                            organizationOptionMap.Add(orgnizationCounter, organizationKey);
                            orgnizationCounter++;
                        }
                        Console.WriteLine($"Select the member to select the member from.");
                        response = IApplication.READ_RESPONSE().ToLower();
                        try
                        {
                            organizationOption = int.Parse(response);
                        }
                        catch
                        {
                            organizationOption = -1;
                        }
                        if (!organizationOptionMap.ContainsKey(organizationOption)) organizationOption = -1;
                    }
                    else
                    {
                        organizationOptionMap.Add(1, Keys.First());
                        organizationOption = 1;
                    }
                }
                Organization organization = this[organizationOptionMap[organizationOption]];
                organizationName = organization.ToNameString();
                if (organization.Teams.Keys.Count > 0)
                {
                    while (teamOption == -1)
                    {
                        Console.WriteLine($"\nReassign Member _name from {organizationName}");
                        teamCounter = 1;
                        if (organization.Teams.Count > 1)
                        {

                            foreach (String teamKey in organization.Teams.Keys)
                            {
                                organization.Teams[teamKey].Display(true, false, teamCounter);
                                teamOptionMap.Add(teamCounter, teamKey);
                                teamCounter++;
                            }
                            Console.WriteLine($"Select the member to select the member from.");
                            response = IApplication.READ_RESPONSE().ToLower();
                            try
                            {
                                teamOption = int.Parse(response);
                            }
                            catch
                            {
                                teamOption = -1;
                            }
                            if (!teamOptionMap.ContainsKey(teamOption)) teamOption = -1;
                        }
                        else
                        {
                            teamOptionMap.Add(1, organization.Teams.Keys.First());
                            teamOption = 1;
                        }
                    }
                    Team team = organization.Teams[teamOptionMap[teamOption]];
                    teamName = team.ToNameString();
                    if (team.Members.Keys.Count > 0)
                    {
                        while (memberOption == -1)
                        {
                            Console.WriteLine($"\nReassign Member _name from {organizationName} - {teamName}");
                            memberCounter = 1;
                            if (team.Members.Keys.Count > 1)
                            {
                                foreach (String memberKey in team.Members.Keys)
                                {
                                    team.Members[memberKey].Display(memberCounter);
                                    memberOptionMap.Add(memberCounter, memberKey);
                                    memberCounter++;
                                }
                                Console.WriteLine($"Select the member to reassign the name for.");
                                response = IApplication.READ_RESPONSE().ToLower();
                                try
                                {
                                    memberOption = int.Parse(response);
                                }
                                catch
                                {
                                    memberOption = -1;
                                }
                                if (!memberOptionMap.ContainsKey(memberOption)) memberOption = -1;
                            }
                            else
                            {
                                memberOptionMap.Add(1, team.Members.Keys.First());
                                memberOption = 1;
                            }
                        }
                        Person person = team.Members[memberOptionMap[memberOption]];
                        memberName = person.ToNameString();
                        Console.WriteLine($"Please enter the new name for {memberName}.");
                        response = IApplication.READ_RESPONSE();
                        person.SetName(response);
                    }
                }
            }
        }
        internal void AssignPersonTeam()
        {
            /*TODO - AssignPersonTeam*/
            throw new NotImplementedException();
        }
        internal void AddPersonRole()
        {
            /*TODO - AddPersonRole*/
            throw new NotImplementedException();
        }
        internal void RemovePersonRole()
        {
            /*TODO - RemovePersonRole*/
            throw new NotImplementedException();
        }
        internal void ListPersonRoles()
        {
            /*TODO - ListPersonRoles*/
            throw new NotImplementedException();
        }
        internal void AddRole()
        {
            OrganizationalRoles.Add();
        }
        internal void CopyRole()
        {
            OrganizationalRoles.Copy();
        }
        internal void RemoveRole()
        {
            OrganizationalRoles.Remove();
        }
        internal void ListRoles()
        {
            OrganizationalRoles.List();
        }
        internal void ExportRoles()
        {
            OrganizationalRoles.Export(OrganizationalRoles);
        }
        internal void ImportRoles()
        {
            OrganizationalRoles.Import(OrganizationalRoles);
        }
        internal void AddMember()
        {
            int orgnizationCounter, teamCounter;
            String organizationName, teamName;
            Organization organization;
            Boolean done = false;
            Dictionary<int, String> organizationOptionMap = new();
            Dictionary<int, String> teamOptionMap = new();
            int organizationOption = -1;
            int teamOption = -1;
            while (organizationOption == -1)
            {
                Console.WriteLine("\nAdd Member");
                orgnizationCounter = 1;
                if(Keys.Count > 1)
                {
                    foreach (String organizationKey in Keys)
                    {
                        this[organizationKey].Display(true, false, orgnizationCounter);
                        organizationOptionMap.Add(orgnizationCounter, organizationKey);
                        orgnizationCounter++;
                    }
                    Console.WriteLine($"Select the member to add the member to.");
                    String response = IApplication.READ_RESPONSE().ToLower();
                    try
                    {
                        organizationOption = int.Parse(response);
                    }
                    catch
                    {
                        organizationOption = -1;
                    }
                    if (!organizationOptionMap.ContainsKey(organizationOption)) organizationOption = -1;
                } else if (Keys.Count == 1)
                {
                    organizationOptionMap.Add(1, Keys.First());
                    organizationOption = 1;
                } else
                {
                    organization = new Organization(OrganizationalRoles, false);
                    Add(organization.ToKeyString(), organization);
                    organizationOptionMap.Add(1, Keys.First());
                    organizationOption = 1;
                    done = true;
                }
            }
            if(!done)
            {
                organization = this[organizationOptionMap[organizationOption]];
                organizationName = organization.ToNameString();
                if (organization.Teams.Keys.Count > 0)
                {
                    while (teamOption == -1)
                    {
                        Console.WriteLine($"\nAdd Member to {organizationName}");
                        teamCounter = 1;
                        if (organization.Teams.Count > 1)
                        {
                            foreach (String teamKey in organization.Teams.Keys)
                            {
                                organization.Teams[teamKey].Display(true, false, teamCounter);
                                teamOptionMap.Add(teamCounter, teamKey);
                                teamCounter++;
                            }
                            Console.WriteLine($"Select the member to add the member to.");
                            String response = IApplication.READ_RESPONSE().ToLower();
                            try
                            {
                                teamOption = int.Parse(response);
                            }
                            catch
                            {
                                teamOption = -1;
                            }
                            if (!teamOptionMap.ContainsKey(teamOption)) teamOption = -1;
                        }
                        else
                        {
                            teamOptionMap.Add(1, organization.Teams.Keys.First());
                            teamOption = 1;
                        }
                    }
                    Team team = organization.Teams[teamOptionMap[teamOption]];
                    teamName = team.ToNameString();
                    Console.WriteLine($"\nAdd Member to {teamName} in {organizationName}");
                    Person person = new(OrganizationalRoles, organization, team, false);
                    teamName = team.ToNameString();
                    if (team.People.Keys.Contains(person.Key))
                    {
                        Console.WriteLine($"Memeber {person.ToNameString()} already exists in {teamName}.");
                        Console.Write("overwrite?");
                        String response = IApplication.READ_RESPONSE().ToLower();
                        if (IApplication.YES_RESPONSE.Contains(response))
                        {
                            team.RemoveMember(person.Key);
                            team.DescribedObjectDictionaryOfNamedObjects.Add(person.Key, person);
                        }
                    }
                    else team.DescribedObjectDictionaryOfNamedObjects.Add(person.Key, person);
                }
                else
                {
                    Team team = new Team(OrganizationalRoles, false);
                    organization.Teams.Add(team.Key, team);
                }
            }
        }
        internal void CopyMember()
        {
            Person person = null;
            Console.WriteLine("\nCopy Member");
            if (People.Count == 0) AddMember();
            if (People.Count > 1)
            {
                while (person is null)
                {
                    person = RequestPerson();
                }
            } else {
                person = People.First().Value;
            }
            Team teamKey = FindPersonTeam(person);
            teamKey.CopyMember(person.Key);
        }
        internal void RemoveMember()
        {
            People.Remove(this);
        }
        internal void DisplayMember()
        {
            /*TODO - DisplayMember*/
            throw new NotImplementedException();
        }
        internal void DisplayPerson(Person person)
        {
            person.Display();
        }
        internal void AddUnit()
        {
            OrganizationalUnits.Add();
        }
        internal void CopyUnit()
        {
            OrganizationalUnits.Copy();
        }
        internal void EditUnit()
        {
            OrganizationalUnits.Edit();
        }
        internal void RemoveUnit()
        {
            OrganizationalUnits.Remove();
        }
        internal void ListUnits()
        {
            OrganizationalUnits.List();
        }
        internal void ExportUnits()
        {
            OrganizationalUnits.Export(OrganizationalUnits);
        }
        internal void ImportUnits()
        {
            OrganizationalUnits.Import(OrganizationalUnits);
        }
        private Person RequestPersonTeam(Roles roleDefinitions)
        {
            Organization organization;
            Team team;
            Person resultPerson=null;
            int teamCounter, orgCounter;
            int teamOption, orgOption;
            Dictionary<int, String> teamOptionMap, orgOptionMap;
            String response, resultTeamKey = "", resultOrganizationKey="";

            while (resultTeamKey == "")
            {
                teamOption = 0;
                teamCounter = 1;
                while (teamOption == 0)
                {
                    teamCounter = 1;
                    teamOptionMap = new();
                    foreach (String teamKey in Teams.Keys)
                    {
                        Teams[teamKey].DisplayTeamName(teamCounter);
                        teamOptionMap.Add(teamCounter, teamKey);
                        teamCounter++;
                    }
                    if(teamOptionMap.Count>0)
                    {
                        Console.WriteLine($"{teamCounter})  *Add new Team*");
                        Console.WriteLine("Select the member the member belongs to:  ");
                        response = IApplication.READ_RESPONSE();
                        try
                        {
                            teamOption = int.Parse(response);
                        }
                        catch { teamOption = 0; }
                    }
                    else
                    {
                        teamOption = teamCounter;
                    }
                }
                orgOptionMap = new();
                if (teamOption == teamCounter)
                {
                    orgCounter = 1;
                    foreach (String orgKey in Keys)
                    {
                        this[orgKey].Display(orgCounter);
                        orgOptionMap.Add(orgCounter, orgKey);
                        orgCounter++;
                    }
                    if (orgOptionMap.Count > 0)
                    {
                        Console.WriteLine($"{orgCounter})  *Add new Values*");
                        Console.WriteLine("Select the member the member belongs to:  ");
                        response = IApplication.READ_RESPONSE();
                        try
                        {
                            orgOption = int.Parse(response);
                        }
                        catch { orgOption = 0; }
                    }
                    else
                    {
                        orgOption = teamCounter;
                    }
                    if (orgOption == orgCounter)
                    {
                        organization = new(roleDefinitions, false);
                        Add(organization.Key, organization);
                        resultTeamKey = organization.Teams.Last().Key;
                        resultPerson = organization.Teams[resultTeamKey].People.First().Value;
                    }
                    else if (orgOption > 0 && orgOption < orgCounter)
                    {
                        resultOrganizationKey = orgOptionMap[orgOption];
                        team = new(OrganizationalRoles, false);
                        this[resultOrganizationKey].Add(team.Key, team);
                        resultTeamKey = team.Key;
                        resultPerson = this[resultOrganizationKey].Teams[resultTeamKey].People.First().Value;
                    }
                }
                else if (teamOption > 0 && teamOption < teamCounter)
                {
                    resultTeamKey = orgOptionMap[teamOption];
                    resultPerson = this[resultOrganizationKey].Teams[resultTeamKey].People.First().Value;
                }
            }
            return resultPerson;
        }
        internal Team FindPersonTeam(Person person)
        {
            Team teamKey = null;
            Team temp;
            foreach(String organizationKey in Keys)
            {
                Organization organization = this[organizationKey];
                temp = organization.FindPersonTeam(person);
                if(temp is not null) {
                    teamKey = temp;
                    break;
                }
            }
            return teamKey;
        }
        private Organization FindTeamOrganization(Team team)
        {
            Organization organization = null;
            foreach(String key in Keys)
            {
                if (this[key].ContainsKey(team.Key)) organization = this[key];
            }
            return organization;
        }
        private Person RequestPerson()
        {
            int option = 0;
            Person result = null;
            String response;
            Dictionary<int, Person> optionMap;
            while(option==0)
            {
                int counter = 1;
                optionMap = new();
                foreach (String personKey in People.Keys)
                {
                    Person person = People[personKey];
                    person.Display(counter);
                    optionMap.Add(counter, person);
                    counter++;
                }
                Console.WriteLine("Please select the member:  ");
                response = IApplication.READ_RESPONSE();
                try
                {
                    option = int.Parse(response);
                }
                catch { option = 0; }
                if(optionMap.ContainsKey(option))
                {
                    result = optionMap[option];
                }
                else
                {
                    option = 0;
                }
            }
            return result;
        }
        private void ThrowNotImplementedException()
        {
            /*TODO -- ThrowNotImplementedException*/
            throw new NotImplementedException();
        }

        internal override Organization CreateNewDescribedObject(Boolean empty = true)
        {
            /*TODO - CreateNewDescribedObject*/
            throw new NotImplementedException();
        }

        internal override Organization CreateNewDescribedObject(String organizationName, String organizationDescription)
        {
            /*TODO - CreateNewDescribedObject*/
            throw new NotImplementedException();
        }
    }
}