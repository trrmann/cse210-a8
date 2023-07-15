using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonPeople : JsonDictionaryNamedObject<JsonPerson>
    {
        protected People _people { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PeopleMembers")]
        public JsonDictionaryNamedObject<JsonPerson> Members
        {
            get
            {
                JsonDictionaryNamedObject<JsonPerson> dictionary = new(Convert(_people));
                foreach (String key in DictionaryNamedObject.Keys)
                {
                    dictionary.Dictionary.Add(key, (JsonPerson)(Person)DictionaryNamedObject[key]);
                }
                return dictionary;
            }
            set
            {
                DictionaryNamedObject.Clear();
                foreach (String key in value.Dictionary.Keys)
                {
                    DictionaryNamedObject.Add(key, (Person)value.Dictionary[key]);
                }
            }
        }
        public JsonPeople() : base(new Dictionary<String, JsonPerson>()) { }
        [JsonConstructor]
        public JsonPeople(JsonDictionaryNamedObject<JsonPerson> Members) : base(new Dictionary<String, JsonPerson>())
        {
            this.Members = Members;
        }
        public JsonPeople(People people) : base(new Dictionary<String, JsonPerson>())
        {
            _people = people;
        }
        public static implicit operator JsonPeople(People people)
        {
            return new(people);
        }
        public static implicit operator People(JsonPeople people)
        {
            return people._people;
        }
        internal static JsonDictionaryNamedObject<JsonPerson> Convert(People value)
        {
            Dictionary<String, JsonPerson> result = new();
            foreach (String key in value.Keys)
            {
                result.Add(key, value[key]);
            }
            return new(result);
        }
    }
    public class People : DictionaryNamedObject<Person>
    {
        internal Dictionary<int, Person> GetOptionMap()
        {
            Dictionary<int, Person> result = new();
            int option = 1;
            foreach (String key in Keys)
            {
                result.Add(option, this[key]);
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
        internal String Add(Organization organization, Team team)
        {
            Person person = new(organization, team, false);
            Add(person.Key, person);
            return person.Key;
        }
        internal void List(Organizations organizations)
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
                    organizations[organizationKey].Display(true, false, organizationCounter);
                    organizationOptionMap.Add(organizationCounter, organizationKey);
                    organizationCounter++;
                }
                Console.WriteLine($"Select the member to list members for.");
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
                teamName = "All Values";
                people = organizations.People;
            }
            else
            {
                Organization organization = organizations[organizationOptionMap[organizationOption]];
                organizationName = organization.ToNameString();
                while (teamOption == -1)
                {
                    Console.WriteLine($"\nList {organizationName} Members");
                    teamCounter = 1;
                    Console.WriteLine("0)  All Members.");
                    foreach (String teamKey in organization.Teams.Keys)
                    {
                        organization.Teams[teamKey].Display(true, false, teamCounter);
                        teamOptionMap.Add(teamCounter, teamKey);
                        teamCounter++;
                    }
                    Console.WriteLine($"Select the member to list members for.");
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
                    teamName = String.Format("All {0} Members", organizationName);
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

        internal void Remove(Organizations organizations)
        {
            Person person = null;
            Console.WriteLine("\nRemove Member");
            if (organizations.People.Count > 0)
            {
                if (organizations.People.Count > 1)
                {
                    while (person is null)
                    {
                        person = organizations.RequestPerson();
                    }
                }
                else
                {
                    person = organizations.People.First().Value;
                }
                Team teamKey = organizations.FindPersonTeam(person);
                teamKey.RemoveMember(person.Key);
            }
            else
            {
                Console.WriteLine("\nNo Members to Remove.");
            }
        }

        protected override void DisplayNameObjectExportMessage()
        {
            /*TODO - DisplayNameObjectExportMessage*/
            throw new NotImplementedException();
        }

        protected override void DisplayNameObjectImportMessage()
        {
            /*TODO - DisplayNameObjectImportMessage*/
            throw new NotImplementedException();
        }

        public static implicit operator People(DescribedObjectDictionary<Person> value)
        {
            People people  = new People();
            foreach(String key in value.Keys)
            {
                if(!people.Keys.Contains(key)) people.Add(key, value[key]);
            }
            return people;
        }
    }
}