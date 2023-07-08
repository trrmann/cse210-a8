using System.Security.Principal;

namespace FinalProject
{
    public class Person : NamedObject
    {
        internal List<String> RoleNames { get; private set; }
        protected String Team { get; set; }
        public Person(Boolean empty=true) {
            Init(empty);
        }
        public Person(String teamKey, Boolean empty = true)
        {
            Init(teamKey, empty);
        }
        protected override void Init(Boolean empty = true)
        {
            base.Init(NameType.Person, empty);
            RoleNames = new List<String>();
            Team = "";
        }
        protected void Init(String teamKey, Boolean empty = true)
        {
            base.Init(NameType.Person, empty);
            Team = teamKey;
            RoleNames = new List<String>();
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