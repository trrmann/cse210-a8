namespace FinalProject
{
    public class Team : NamedObjectWithDetail
    {
        protected String Manager { get; set; }
        internal People Members { get; set; }
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

        public Team(Roles roleDefinitions, String teamName, Boolean empty = true)
        {
            Init(roleDefinitions, teamName, empty);
        }

        protected override void Init(Boolean empty = true)
        {
            Init(new(), null, null, null, new(), new(), new(), empty);
        }
        protected void Init(Roles roleDefinitions, Boolean empty = true)
        {
            Init(roleDefinitions, null, null, null, new(), new(), new(), empty);
        }

        protected void Init(Roles roleDefinitions, String teamName, Boolean empty = true)
        {
            Init(roleDefinitions, teamName, null, null, new(), new(), new(), empty);
        }
        protected void Init(Roles roleDefinitions, String teamName, String description, String manager, People members, List<Team> teams, List<String> staff, Boolean empty = true)
        {
            if(empty)
            {
                base.Init(NameType.Organization, empty);
                Name = (OrganizationName)teamName;
                Description = description;
                Manager = manager;
                Members = members;
                ReportingTeams = teams;
                StaffReportingTeamNames = staff;
            }
            else
            {
                Name = (OrganizationName)teamName;
                Description = description;
                Manager = manager;
                Members = members;
                ReportingTeams = teams;
                StaffReportingTeamNames = staff;
                base.Init(NameType.Organization, empty);
                Manager = Members.Add(Key);
                People[Manager].AddRole(roleDefinitions, "Manager");
            }
        }
        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the team name.");
        }
        protected override void DisplaySetName()
        {
            Console.WriteLine("\nSet team name");
        }
        protected override void DisplayRequestReSetName()
        {
            Console.WriteLine("\nRename team?");
        }
        protected override void DisplayRequestSetName()
        {
            Console.WriteLine("\nWhat is the name of the team?");
        }
        internal override void Display(int option = -1)
        {
            base.Display(option);
        }

        internal String AddPerson()
        {
            throw new NotImplementedException();
        }

        internal void DisplayTeamName(int counter = -1)
        {
            base.Display(true,false,counter);
        }

        internal void CopyPerson(string personKey)
        {
            throw new NotImplementedException();
        }

        internal void EditPerson(string personKey)
        {
            throw new NotImplementedException();
        }

        internal void RemovePerson(string personKey)
        {
            throw new NotImplementedException();
        }
    }
}