namespace FinalProject
{
    public class Role : NamedObjectWithDetail
    {
        public Role(String roleKey)
        {
            Init(roleKey);
        }
        public Role(Boolean empty=true)
        {
            Init(empty);
        }
        public Role(Role role)
        {
            Init(role);
        }
        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the role name.");
        }
        protected override void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the role description.");
        }
        protected void Init(String roleKey, Boolean empty = true)
        {
            switch(roleKey)
            {
                case "":
                    Name = new ThingName(false);
                    Description = "Description";
                    break;
                case "Manager":
                    Name = new ThingName("Manager");
                    Description = "Manager";
                    break;
                default:
                    Name = new ThingName(roleKey);
                    Description = roleKey;
                    break;
            }
        }
        private void Init(Role role)
        {
            Name = role.Name;
            Description = role.Description;
        }
        internal Role CreateCopy(String newName)
        {
            Role result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}