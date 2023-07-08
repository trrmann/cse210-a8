namespace FinalProject
{
    internal interface IName : IStringUtilities, IBitwiseUtilities
    {
        public static Name CreateName(String name, NameType type=NameType.Thing)
        {
            switch (type)
            {
                case NameType.Person:
                    return new PersonName(name);
                case NameType.Organization:
                    return new OrganizationName(name);
                case NameType.Place:
                    return new PlaceName(name);
                case NameType.Thing:
                    return new ThingName(name);
                default:
                    return new ThingName(name);
            }

        }
        private Dictionary<String, List<List<Boolean>>> BitWiseCombinations
        {
            get
            {
                int outerCounter, counter, innerCounter;
                List<Boolean> combination;
                List<List<Boolean>> groupList;
                Dictionary<String, List<List<Boolean>>> result = new();
                List<String> groups = new() { "5-Person", "4-Person", "3-Person", "2-Person", "1-Person" };
                foreach (String group in groups)
                {
                    groupList = new();
                    switch (group)
                    {
                        case "5-Person":
                            combination = new();
                            for (outerCounter = 0; outerCounter < 7; outerCounter++) combination.Add(true);
                            groupList.Add(combination);
                            break;
                        case "4-Person":
                            for (outerCounter = 0; outerCounter < 5; outerCounter++)
                            {
                                if (outerCounter == 0 || outerCounter == 5)
                                {
                                    for (counter = 0; counter < 3; counter++)
                                    {
                                        combination = new();
                                        for (innerCounter = 0; innerCounter < 5; innerCounter++)
                                        {
                                            if (innerCounter == 0 || innerCounter == 5)
                                            {
                                                if (outerCounter == innerCounter)
                                                {
                                                    switch (counter)
                                                    {
                                                        case 0:
                                                            combination.Add(false);
                                                            combination.Add(false);
                                                            break;
                                                        case 1:
                                                            combination.Add(true);
                                                            combination.Add(false);
                                                            break;
                                                        case 2:
                                                            combination.Add(false);
                                                            combination.Add(true);
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    combination.Add(true);
                                                    combination.Add(true);
                                                }
                                            }
                                            else
                                            {
                                                if (outerCounter == innerCounter)
                                                {
                                                    combination.Add(true);
                                                }
                                                else
                                                {
                                                    combination.Add(true);
                                                }
                                            }
                                        }
                                        groupList.Add(combination);
                                    }
                                }
                                else
                                {
                                    combination = new();
                                    for (innerCounter = 0; innerCounter < 5; innerCounter++)
                                    {
                                        if (innerCounter == 0 || innerCounter == 5)
                                        {
                                            if (outerCounter == innerCounter)
                                            {
                                                combination.Add(true);
                                                combination.Add(true);
                                            }
                                            else
                                            {
                                                combination.Add(true);
                                                combination.Add(true);
                                            }
                                        }
                                        else
                                        {
                                            if (outerCounter == innerCounter)
                                            {
                                                combination.Add(true);
                                            }
                                            else
                                            {
                                                combination.Add(true);
                                            }
                                        }
                                    }
                                    groupList.Add(combination);
                                }
                            }
                            break;
                        case "3-Person":
                            break;
                        case "2-Person":
                            break;
                        case "1-Person":
                            break;
                        default:
                            break;
                    }
                    result.Add(group, groupList);
                }
                return result;
            }
        }
        private String OptionDisplay(NameType type)
        {
            return "";/* String.Format(FormatStrings[type][OptionCombination(OptionCombinationFlags(type))], OptionCombination(type));*/
        }
    }
}