namespace FinalProject
{
    public class Organization : NamedObjectWithDetail
    {
        private Roles RoleDefinitions { get; set; }
        protected String ChiefAdminTeamName { get; set; }
        internal Dictionary<String, Team> Teams { get; set; }
        internal People People
        {
            get
            {
                People result = new();
                foreach (String teamKey in Teams.Keys)
                {
                    Team team = Teams[teamKey];
                    People subGroup = team.People;
                    foreach (String personName in subGroup.Keys)
                    {
                        result.Add(personName+teamKey, subGroup[personName]);
                    }
                }
                return result;
            }
        }

        public string OrganizationKey { get { return base.Key; } }

        public Organization(Roles roleDefinitions, Boolean empty = true)
        {
            Init(roleDefinitions, empty);
        }
        public Organization(Organization organization)
        {
            Init(organization);
        }
        public Organization(Boolean empty=true)
        {
            Init(empty);
        }
        protected override void Init(Boolean empty = true)
        {
            if(empty)
            {
                Init(new(), "", "", "", new(), empty);
            }
            else
            {
                Init(new(), null, null, null, null, empty);
                Team team = new Team(RoleDefinitions, false);
                Init(RoleDefinitions, Name, Description, team.Key, new() { { team.Key, team } });
            }
        }
        protected void Init(Roles roleDefinitions, Boolean empty = true)
        {
            if (empty)
            {
                Init(roleDefinitions, "", "", "", new(), empty);
            }
            else
            {
                Init(roleDefinitions, null, null, null, null, empty);
                Team team = new Team(RoleDefinitions, false);
                Init(RoleDefinitions, Name, Description, team.Key, new() { { team.Key, team } });
            }
        }
        private void Init(Organization organization)
        {
            Init(organization.RoleDefinitions, organization.Name, organization.Description, organization.ChiefAdminTeamName, organization.Teams);
        }
        private void Init(Roles roleDefinitions, String name, String description, String chiefAdminTeamName, Dictionary<String, Team> teams, Boolean empty = true)
        {
            if(empty)
            {
                base.Init(NameType.Organization, empty);
                Name = (OrganizationName)name;
                Description = description;
                ChiefAdminTeamName = chiefAdminTeamName;
                Teams = teams;
                RoleDefinitions = roleDefinitions;
            }
            else
            {
                Name = (OrganizationName)name;
                Description = description;
                base.Init(NameType.Organization, empty);
                ChiefAdminTeamName = chiefAdminTeamName;
                Teams = teams;
                RoleDefinitions = roleDefinitions;
            }
        }
        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the organization name.");
        }
        protected override void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the organization description.");
        }
        internal void AddPerson()
        {
            String teamKey = RequestPersonTeam();
            if(!Teams.ContainsKey(teamKey))
            {
                Teams.Add(teamKey, new Team(RoleDefinitions, teamKey));
            }
            Teams[teamKey].AddPerson();
        }
        internal void CopyPerson()
        {
            String personKey = RequestPerson();
            String teamKey = FindPersonTeamKey(personKey);
            Teams[teamKey].CopyPerson(personKey);
        }
        internal void EditPerson()
        {
            String personKey = RequestPerson();
            String teamKey = FindPersonTeamKey(personKey);
            Teams[teamKey].EditPerson(personKey);
        }
        internal void RemovePerson()
        {
            String personKey = RequestPerson();
            String teamKey = FindPersonTeamKey(personKey);
            Teams[teamKey].RemovePerson(personKey);
        }
        internal void ListPeople()
        {
            People.List();
        }
        internal void ExportPeople()
        {
            People.ExportPeople();
        }
        internal void ImportPeople()
        {
            People.ImportPeople(this);
        }
        internal void DisplayPerson(String personKey)
        {
            People[personKey].Display();
        }
        private String RequestPersonTeam()
        {
            int counter;
            int option;
            Dictionary<int, String> optionMap;
            String response, resultTeamKey = "";
            while (resultTeamKey == "")
            {
                counter = 1;
                optionMap = new();
                foreach (String teamKey in Teams.Keys)
                {
                    Teams[teamKey].DisplayTeamName(counter);
                    optionMap.Add(counter, teamKey);
                    counter++;
                }
                Console.WriteLine($"{counter})  *Add new Team*");
                Console.WriteLine("Select the team the person belongs to:  ");
                response = IApplication.READ_RESPONSE();
                try
                {
                    option = int.Parse(response);
                }
                catch { option = 0; }
                if (option == counter)
                {
                    Team team = new Team(RoleDefinitions);
                    Teams.Add(team.ToKeyString(), team);
                    resultTeamKey = team.ToKeyString();
                }
                else if (option > 0 && option < counter)
                {
                    resultTeamKey = optionMap[option];
                }
            }
            return resultTeamKey;
        }
        private String RequestPerson()
        {
            throw new NotImplementedException();
        }
        internal String FindPersonTeamKey(String personKey)
        {
            String teamKey = null;
            foreach(String potentialTeamKey in Teams.Keys)
            {
                Team team = Teams[potentialTeamKey];
                foreach(String key in team.People.Keys)
                {
                    if(key==personKey)
                    {
                        teamKey = potentialTeamKey;
                        break;
                    }
                }
                if (teamKey is not null) break;
            }
            return teamKey;
        }

        internal Boolean ContainsKey(String teamKey)
        {
            return Teams.ContainsKey(teamKey);
        }

        internal void Add(String teamKey, Team team)
        {
            throw new NotImplementedException();
        }

        internal String AddPerson(String teamsKey)
        {
            return Teams[teamsKey].AddPerson();
        }

        internal void DisplayOrganizationName(int orgCounter)
        {
            throw new NotImplementedException();
        }

        internal void Add(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}