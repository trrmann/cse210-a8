using System.Data;

namespace FinalProject
{
    public class Roles : Dictionary<String, Role>
    {
        internal void AddRole()
        {
            Role role = new(false);
            if(Keys.Contains(role.Key))
            {
                Console.WriteLine($"Role {role.ToNameString()} already exists.");
                Console.Write("overwrite?");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Remove(role.Key);
                    Add(role.Key, role);
                }
            } else Add(role.Key, role);
        }
        internal void CopyRole()
        {
            Dictionary<int, String> optionMap = new();
            int option = 0;
            while (option == 0)
            {
                Console.WriteLine("\nCopy Role");
                int counter = 1;
                foreach (String roleKey in Keys)
                {
                    this[roleKey].Display(true, false, counter);
                    optionMap.Add(counter, roleKey);
                    counter++;
                }
                Console.WriteLine($"Select the role to copy.");
                String response = IApplication.READ_RESPONSE().ToLower();
                try
                {
                    option = int.Parse(response);
                }
                catch
                {
                    option = 0;
                }
                if(!optionMap.ContainsKey(option)) option = 0;
            }
            Role sourceRole = this[optionMap[option]];
            Console.WriteLine($"\nEnter the name of the copied role.");
            String newName = IApplication.READ_RESPONSE();
            Role role = sourceRole.CreateCopy(newName);
            if (Keys.Contains(role.Key))
            {
                Console.WriteLine($"Role {role.ToNameString()} already exists.");
                Console.Write("overwrite?");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Remove(role.Key);
                    Add(role.Key, role);
                }
            }
            else Add(role.Key, role);
        }
        internal void ListRoles()
        {
            Console.WriteLine("\nList Roles");
            int counter = 1;
            foreach(String roleKey in Keys )
            {
                Role role = this[roleKey];
                role.Display(true, true, counter);
                counter++;
            }
        }
        internal void RemoveRole()
        {
            Dictionary<int, String> optionMap = new();
            int option = -1;
            while (option == -1)
            {
                Console.WriteLine("\nRemove Role");
                int counter = 1;
                Console.WriteLine("0)  None.");
                foreach (String roleKey in Keys)
                {
                    this[roleKey].Display(true, false, counter);
                    optionMap.Add(counter, roleKey);
                    counter++;
                }
                if (optionMap.Count > 0)
                {
                    Console.WriteLine($"Select the role to remove.");
                    String response = IApplication.READ_RESPONSE().ToLower();
                    try
                    {
                        option = int.Parse(response);
                    }
                    catch
                    {
                        option = -1;
                    }
                }
                else option = 0;
                if (!optionMap.ContainsKey(option)) option = 0;
            }
            if(option > 0)
            {
                Remove(optionMap[option]);
            }
        }
        internal void ExportRoles()
        {
            throw new NotImplementedException();
        }
        internal void ImportRoles()
        {
            throw new NotImplementedException();
        }
    }
}