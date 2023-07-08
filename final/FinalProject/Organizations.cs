using System.Diagnostics.Metrics;

namespace FinalProject
{
    public class Organizations : Dictionary<String, Organization>
    {
        internal Units Units { get; set; }
        internal Roles RoleDefinitions { get; set; }
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
                        result.Add(personName+teamKey, subGroup[personName]);
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
                        result.Add(teamKey+organizationKey, subGroup[teamKey]);
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
        protected void Init(Boolean empty = true)
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
            Init(organizations.Units, organizations.RoleDefinitions, (Dictionary<String, Organization>)organizations);
        }
        protected void Init(Units units, Roles roleDefinitions, Dictionary<String, Organization> dictionary)
        {
            Units = units;
            RoleDefinitions = roleDefinitions;
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
        internal String AddPersonKey()
        {
            String personKey = RequestPersonTeam(RoleDefinitions);
            String teamKey = FindPersonTeamKey(personKey);
            String organizationKey = FindTeamOrganizationKey(teamKey);
            Organization organization;
            Team team;
            Person person;
            if (organizationKey is null)
            {
                organization = new Organization(RoleDefinitions);
                organizationKey = organization.OrganizationKey;
                if (!ContainsKey(organizationKey))
                {
                    Add(organizationKey, organization);
                }
                if(organization.People.Count == 1) {
                    return organization.People.First().Key;
                }
            }
            organization = this[organizationKey];
            if (teamKey is null)
            {
                team = new Team(RoleDefinitions);
                teamKey = team.ToKeyString();
                if (!organization.ContainsKey(teamKey))
                {
                    organization.Add(teamKey, team);
                }
            }
            return personKey;// team.AddMember(personKey);
        }
        internal void AddOrganization()
        {
            Organization organization = new(false);
            if (Keys.Contains(organization.Key))
            {
                Console.WriteLine($"Organization {organization.ToNameString()} already exists.");
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
            throw new NotImplementedException();
        }
        internal void RemoveOrganization()
        {
            throw new NotImplementedException();
        }
        internal void ListOrganizations()
        {
            Console.WriteLine("\nList Organizations");
            int counter = 1;
            foreach (String organizationKey in Keys)
            {
                Organization organization = this[organizationKey];
                organization.Display(true, true, counter);
                counter++;
            }
        }
        internal void ExportOrganizations()
        {
            throw new NotImplementedException();
        }
        internal void ImportOrganizations()
        {
            throw new NotImplementedException();
        }
        internal void AddTeam()
        {
            int counter;
            String organizationName;
            Dictionary<int, String> optionMap = new();
            int option = -1;
            while (option == -1)
            {
                Console.WriteLine("\nAdd Team");
                counter = 1;
                foreach (String organizationKey in Keys)
                {
                    this[organizationKey].Display(true, false, counter);
                    optionMap.Add(counter, organizationKey);
                    counter++;
                }
                Console.WriteLine($"Select the organization to add the teams to.");
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
            Organization organization = this[optionMap[option]];
            organizationName = organization.ToNameString();
            Team team = new(RoleDefinitions, false);
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
        internal void CopyTeam()
        {
            throw new NotImplementedException();
        }
        internal void RemoveTeam()
        {
            throw new NotImplementedException();
        }
        internal void ListTeams()
        {
            int counter;
            String organizationName;
            Dictionary<String, Team> teams;
            Dictionary<int, String> optionMap = new();
            int option = -1;
            while (option == -1)
            {
                Console.WriteLine("\nList Teams");
                counter = 1;
                Console.WriteLine("0)  All Organzations.");
                foreach (String organizationKey in Keys)
                {
                    this[organizationKey].Display(true, false, counter);
                    optionMap.Add(counter, organizationKey);
                    counter++;
                }
                Console.WriteLine($"Select the organization to list teams for.");
                String response = IApplication.READ_RESPONSE().ToLower();
                try
                {
                    option = int.Parse(response);
                }
                catch
                {
                    option = -1;
                }
                if (!optionMap.ContainsKey(option)) option = 0;
            }
            if (option==0)
            {
                organizationName = "All Organizations";
                teams = Teams;
            } else
            {
                organizationName = this[optionMap[option]].ToNameString();
                teams = this[optionMap[option]].Teams;
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
            throw new NotImplementedException();
        }
        internal void NameOrganization()
        {
            throw new NotImplementedException();
        }
        internal void DescribeOrganization()
        {
            throw new NotImplementedException();
        }
        internal void DisplayOrganization()
        {
            throw new NotImplementedException();
        }
        internal void ListTeamMembers()
        {
            int organizationCounter;
            int teamCounter;
            String organizationName;
            String teamName;
            People people;
            Dictionary<int, String> organizationOptionMap = new();
            Dictionary<int, String> teamOptionMap = new();
            int organizationOption = -1;
            int teamOption = -1;
            while (organizationOption == -1)
            {
                Console.WriteLine("\nList Members");
                organizationCounter = 1;
                Console.WriteLine("0)  All Organzations.");
                foreach (String organizationKey in Keys)
                {
                    this[organizationKey].Display(true, false, organizationCounter);
                    organizationOptionMap.Add(organizationCounter, organizationKey);
                    organizationCounter++;
                }
                Console.WriteLine($"Select the organization to list members for.");
                String response = IApplication.READ_RESPONSE().ToLower();
                try
                {
                    organizationOption = int.Parse(response);
                }
                catch
                {
                    organizationOption = -1;
                }
                if (!organizationOptionMap.ContainsKey(organizationOption)) organizationOption = 0;
            }
            if (organizationOption == 0)
            {
                teamName = "All Organizations";
                people = People;
            }
            else
            {
                Organization organization = this[organizationOptionMap[organizationOption]];
                organizationName = organization.ToNameString();
                while (teamOption == -1)
                {
                    Console.WriteLine($"\nList {organizationName} Members");
                    teamCounter = 1;
                    Console.WriteLine("0)  All Teams.");
                    foreach (String teamKey in organization.Teams.Keys)
                    {
                        organization.Teams[teamKey].Display(true, false, teamCounter);
                        teamOptionMap.Add(teamCounter, teamKey);
                        teamCounter++;
                    }
                    Console.WriteLine($"Select the team to list members for.");
                    String response = IApplication.READ_RESPONSE().ToLower();
                    try
                    {
                        teamOption = int.Parse(response);
                    }
                    catch
                    {
                        teamOption = -1;
                    }
                    if (!teamOptionMap.ContainsKey(teamOption)) teamOption = 0;
                }
                if (teamOption == 0)
                {
                    teamName = String.Format("All {0} Teams", organizationName);                    
                    people = organization.People;
                }
                else
                {
                    teamName = organization.Teams[teamOptionMap[teamOption]].ToNameString();
                    people = organization.Teams[teamOptionMap[teamOption]].People;
                }
            }
            Console.WriteLine($"\n{teamName}");
            int counter = 1;
            foreach (String personKey in people.Keys)
            {
                people[personKey].Display(counter);
                counter++;
            }
        }
        internal void ImportExportTeamMembers()
        {
            throw new NotImplementedException();
        }
        internal void NameTeam()
        {
            throw new NotImplementedException();
        }
        internal void AssignTeamManager()
        {
            throw new NotImplementedException();
        }
        internal void AddReportingTeam()
        {
            throw new NotImplementedException();
        }
        internal void RemoveReportingTeam()
        {
            throw new NotImplementedException();
        }
        internal void AddTeamStaff()
        {
            throw new NotImplementedException();
        }
        internal void RemoveTeamStaff()
        {
            throw new NotImplementedException();
        }
        internal void DisplayTeam()
        {
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
                    Console.WriteLine("\nReassign Member Name");
                    orgnizationCounter = 1;
                    if (Keys.Count > 1)
                    {
                        foreach (String organizationKey in Keys)
                        {
                            this[organizationKey].Display(true, false, orgnizationCounter);
                            organizationOptionMap.Add(orgnizationCounter, organizationKey);
                            orgnizationCounter++;
                        }
                        Console.WriteLine($"Select the organization to select the person from.");
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
                        Console.WriteLine($"\nReassign Member Name from {organizationName}");
                        teamCounter = 1;
                        if (organization.Teams.Count > 1)
                        {

                            foreach (String teamKey in organization.Teams.Keys)
                            {
                                organization.Teams[teamKey].Display(true, false, teamCounter);
                                teamOptionMap.Add(teamCounter, teamKey);
                                teamCounter++;
                            }
                            Console.WriteLine($"Select the team to select the person from.");
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
                            Console.WriteLine($"\nReassign Member Name from {organizationName} - {teamName}");
                            memberCounter = 1;
                            if (team.Members.Keys.Count > 1)
                            {
                                foreach (String memberKey in team.Members.Keys)
                                {
                                    team.Members[memberKey].Display(memberCounter);
                                    memberOptionMap.Add(memberCounter, memberKey);
                                    memberCounter++;
                                }
                                Console.WriteLine($"Select the person to reassign the name for.");
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
            throw new NotImplementedException();
        }
        internal void AddPersonRole()
        {
            throw new NotImplementedException();
        }
        internal void RemovePersonRole()
        {
            throw new NotImplementedException();
        }
        internal void ListPersonRoles()
        {
            throw new NotImplementedException();
        }
        internal void AddRole()
        {
            RoleDefinitions.AddRole();
        }
        internal void CopyRole()
        {
            RoleDefinitions.CopyRole();
        }
        internal void RemoveRole()
        {
            RoleDefinitions.RemoveRole();
        }
        internal void ListRoles()
        {
            RoleDefinitions.ListRoles();
        }
        internal void ExportRoles()
        {
            RoleDefinitions.ExportRoles();
        }
        internal void ImportRoles()
        {
            RoleDefinitions.ImportRoles();
        }
        internal void AddMember()
        {
            int orgnizationCounter, teamCounter;
            String organizationName, teamName;
            Dictionary<int, String> organizationOptionMap = new();
            Dictionary<int, String> teamOptionMap = new();
            int organizationOption = -1;
            int teamOption = -1;
            if (Keys.Count > 0)
            {
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
                        Console.WriteLine($"Select the organization to add the person to.");
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
                    } else
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
                        Console.WriteLine($"\nAdd Member to {organizationName}");
                        teamCounter = 1;
                        if(organization.Teams.Count > 1)
                        {

                        foreach (String teamKey in organization.Teams.Keys)
                        {
                            organization.Teams[teamKey].Display(true, false, teamCounter);
                            teamOptionMap.Add(teamCounter, teamKey);
                            teamCounter++;
                        }
                        Console.WriteLine($"Select the team to add the person to.");
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
                        } else
                        {
                            teamOptionMap.Add(1, organization.Teams.Keys.First());
                            teamOption = 1;
                        }
                    }
                    Team team = organization.Teams[teamOptionMap[teamOption]];
                    teamName = team.ToNameString();
                    Console.WriteLine($"\nAdd Member to {teamName} in {organizationName}");
                    Person person = new(false);
            teamName = team.ToNameString();
            if (team.People.Keys.Contains(person.Key))
            {
                Console.WriteLine($"Memeber {person.ToNameString()} already exists in {teamName}.");
                Console.Write("overwrite?");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    team.RemovePerson(person.Key);
                    team.Members.Add(person.Key, person);
                }
            }
            else team.Members.Add(person.Key, person);
                }
                else
                {
                    Team team = new Team(RoleDefinitions, false);
                    organization.Teams.Add(team.Key, team);
                }
            }
            else
            {
                Organization organization = new Organization(false);
                Add(organization.Key, organization);
            }
        }
        internal void CopyPerson()
        {
            String personKey = null;
            while(personKey is not null)
            {
                personKey = RequestPerson();
            }
            String teamKey = FindPersonTeamKey(personKey);
            Teams[teamKey].CopyPerson(personKey);
        }
        internal void EditPerson()
        {
            String personKey = null;
            while (personKey is not null)
            {
                personKey = RequestPerson();
            }
            String teamKey = FindPersonTeamKey(personKey);
            Teams[teamKey].EditPerson(personKey);
        }
        internal void RemovePerson()
        {
            String personKey = null;
            while (personKey is not null)
            {
                personKey = RequestPerson();
            }
            String teamKey = FindPersonTeamKey(personKey);
            Teams[teamKey].RemovePerson(personKey);
        }
        internal void DisplayPerson()
        {
            throw new NotImplementedException();
        }
        internal void DisplayPersonByKey(String personKey)
        {
            People[personKey].Display();
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
        internal void AddUnit()
        {
            Units.Add();
        }
        internal void CopyUnit()
        {
            Units.Copy();
        }
        internal void EditUnit()
        {
            Units.Edit();
        }
        internal void RemoveUnit()
        {
            Units.Remove();
        }
        internal void ListUnits()
        {
            Units.List();
        }
        internal void ExportUnits()
        {
            Units.ExportUnits();
        }
        internal void ImportUnits()
        {
            Units.ImportUnits();
        }
        private String RequestPersonTeam(Roles roleDefinitions)
        {
            Organization organization;
            Team team;
            int teamCounter, orgCounter;
            int teamOption, orgOption;
            Dictionary<int, String> teamOptionMap, orgOptionMap;
            String response, resultPersonKey = "", resultTeamKey = "", resultOrganizationKey="";
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
                        Console.WriteLine("Select the team the person belongs to:  ");
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
                        this[orgKey].DisplayOrganizationName(orgCounter);
                        orgOptionMap.Add(orgCounter, orgKey);
                        orgCounter++;
                    }
                    if (orgOptionMap.Count > 0)
                    {
                        Console.WriteLine($"{orgCounter})  *Add new Organization*");
                        Console.WriteLine("Select the team the team belongs to:  ");
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
                        resultOrganizationKey = organization.OrganizationKey;
                        if(Keys.Contains(resultOrganizationKey)) {
                            organization.Add(this[resultOrganizationKey]);
                            Remove(resultOrganizationKey);
                        }
                        Add(resultOrganizationKey, organization);
                        resultTeamKey = this[resultOrganizationKey].Teams.First().Key;
                        resultPersonKey = this[resultOrganizationKey].Teams[resultTeamKey].People.First().Key;
                    }
                    else if (orgOption > 0 && orgOption < orgCounter)
                    {
                        resultOrganizationKey = orgOptionMap[orgOption];
                        team = new(RoleDefinitions, false);
                        this[resultOrganizationKey].Add(team.Key, team);
                        resultTeamKey = team.Key;
                        resultPersonKey = this[resultOrganizationKey].Teams[resultTeamKey].People.First().Key;
                    }
                }
                else if (teamOption > 0 && teamOption < teamCounter)
                {
                    resultTeamKey = orgOptionMap[teamOption];
                    resultPersonKey = this[resultOrganizationKey].Teams[resultTeamKey].People.First().Key;
                }
            }
            return resultPersonKey;
        }
        private String FindPersonTeamKey(String personKey)
        {
            String teamKey = null;
            String temp;
            foreach(String organizationKey in Keys)
            {
                Organization organization = this[organizationKey];
                temp = organization.FindPersonTeamKey(personKey);
                if(temp is not null) {
                    teamKey = temp;
                    break;
                }
            }
            return teamKey;
        }
        private String FindTeamOrganizationKey(String teamKey)
        {
            String organizationKey = null;
            foreach(String key in Keys)
            {
                if (this[key].ContainsKey(teamKey)) organizationKey = key;
            }
            return organizationKey;
        }
        private String RequestPerson()
        {
            int option = 0;
            String result = null;
            Dictionary<int, String> optionMap;
            while(option==0)
            {
                int counter = 1;
                optionMap = new();
                foreach (String personKey in People.Keys)
                {
                    Person person = People[personKey];
                    person.Display(counter);
                    optionMap.Add(counter, personKey);
                    counter++;
                }
                Console.WriteLine("Please select the person:  ");
                result = IApplication.READ_RESPONSE();
                try
                {
                    option = int.Parse(result);
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
            throw new NotImplementedException();
        }
    }
}