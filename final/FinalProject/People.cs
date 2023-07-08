namespace FinalProject
{
    public class People : Dictionary<String, Person>
    {
        internal Dictionary<int, String> GetOptionMap()
        {
            Dictionary<int, String> result = new();
            int option = 1;
            foreach (String key in Keys)
            {
                result.Add(option, key);
                option++;
            }
            return result;
        }
        internal void DisplayPersonOptions()
        {
            int option = 1;
            foreach (String key in Keys)
            {
                this[key].Display(option);
                option++;
            }
        }
        internal String Add(String teamKey)
        {
            Person person = new(teamKey, false);
            Add(person.Key, person);
            return person.Key;
        }

        internal void Copy()
        {
            throw new NotImplementedException();
        }


        internal void Edit()
        {
            throw new NotImplementedException();
        }

        internal void ExportPeople()
        {
            throw new NotImplementedException();
        }

        internal void ImportPeople(Organization organization)
        {
            throw new NotImplementedException();
        }

        internal void List()
        {
            throw new NotImplementedException();
        }

        internal void Remove()
        {
            throw new NotImplementedException();
        }

        internal void ImportPeople(Organizations organizations)
        {
            throw new NotImplementedException();
        }
    }
}