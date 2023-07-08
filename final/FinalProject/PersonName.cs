using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;

namespace FinalProject
{
    public class PersonName : Name
    {
        protected virtual Boolean UseTitle { get; set; }
        protected virtual Boolean UseGivenName { get; set; }
        protected virtual Boolean UseFirstGivenName { get; set; }
        protected virtual Boolean UseSecondGivenName { get; set; }
        protected virtual Boolean UsePatriachalGivenName { get; set; }
        protected virtual Boolean UseMatriachalGivenName { get; set; }
        protected virtual Boolean UseExtendedPatriachalGivenName { get; set; }
        protected virtual Boolean UseExtendedMatriachalGivenName { get; set; }
        protected virtual Boolean UseMiddleName { get; set; }
        protected virtual Boolean UseSurName { get; set; }
        protected virtual Boolean UsePaternalSurName { get; set; }
        protected virtual Boolean UseMaternalSurName { get; set; }
        protected virtual Boolean UseMaindenSurName { get; set; }
        protected virtual Boolean UseMaindenPaternalSurName { get; set; }
        protected virtual Boolean UseMaindenMaternalSurName { get; set; }
        protected virtual Boolean UseLocationName { get; set; }
        protected virtual Boolean UseSuffix { get; set; }

        protected virtual Boolean HasTitle { get { return Title is not null && Title != ""; } }
        protected virtual Boolean HasGivenName { get { return GivenName is not null && GivenName != ""; } }
        protected virtual Boolean HasFirstGivenName { get { return FirstGivenName is not null && FirstGivenName != ""; } }
        protected virtual Boolean HasSecondGivenName { get { return SecondGivenName is not null && SecondGivenName != ""; } }
        protected virtual Boolean HasPatriachalGivenName { get { return PatriachalGivenName is not null && PatriachalGivenName != ""; } }
        protected virtual Boolean HasMatriachalGivenName { get { return MatriachalGivenName is not null && MatriachalGivenName != ""; } }
        protected virtual Boolean HasExtendedPatriachalGivenName { get { return ExtendedPatriachalGivenName is not null && ExtendedPatriachalGivenName != ""; } }
        protected virtual Boolean HasExtendedMatriachalGivenName { get { return ExtendedMatriachalGivenName is not null && ExtendedMatriachalGivenName != ""; } }
        protected virtual Boolean HasMiddleName { get { return MiddleName is not null && MiddleName != ""; } }
        protected virtual Boolean HasSurName { get { return SurName is not null && SurName != ""; } }
        protected virtual Boolean HasPaternalSurName { get { return PaternalSurName is not null && PaternalSurName != ""; } }
        protected virtual Boolean HasMaternalSurName { get { return MaternalSurName is not null && MaternalSurName != ""; } }
        protected virtual Boolean HasMaidenSurName { get { return MaidenSurName is not null && MaidenSurName != ""; } }
        protected virtual Boolean HasMaidenPaternalSurName { get { return MaidenPaternalSurName is not null && MaidenPaternalSurName != ""; } }
        protected virtual Boolean HasMaidenMaternalSurName { get { return MaidenMaternalSurName is not null && MaidenMaternalSurName != ""; } }
        protected virtual Boolean HasLocationName { get { return LocationName is not null && LocationName != ""; } }
        protected virtual Boolean HasSuffix { get { return Suffix is not null && Suffix != ""; } }




        private String Title { get; set; }
        private String GivenName {
            get
            {
                if (UseSecondGivenName && HasSecondGivenName && HasFirstGivenName)
                {
                    return String.Format("{0} {1}", FirstGivenName, SecondGivenName);
                }
                else if (HasFirstGivenName)
                {
                    return String.Format("{0}", FirstGivenName);
                }
                else if (UseSecondGivenName && HasSecondGivenName)
                {
                    return String.Format("{0}", SecondGivenName);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (UseSecondGivenName && value.Contains(' '))
                {
                    string[] parts = value.Split(" ");
                    List<String> partList = new(parts);
                    FirstGivenName = partList[0];
                    partList.RemoveAt(0);
                    SecondGivenName = String.Join(" ", partList);
                }
                else if (UseSecondGivenName) SecondGivenName = value;
                else FirstGivenName = value;
            }
        }
        private String FirstGivenName { get; set; }
        private String SecondGivenName { get; set; }
        private String PatriachalGivenName { get; set; }
        private String MatriachalGivenName { get; set; }
        private String ExtendedPatriachalGivenName { get; set; }
        private String ExtendedMatriachalGivenName { get; set; }
        private String MiddleName { get; set; }
        private String MaidenSurName { get; set; }
        private String MaidenPaternalSurName { get; set; }
        private String MaidenMaternalSurName { get; set; }
        private Boolean SurNameUseHyphen { get; set; }
        private String SurName
        {
            get
            {
                if (UseMaternalSurName && HasMaternalSurName && HasPaternalSurName)
                {
                    if (SurNameUseHyphen)
                    {
                        return String.Format("{0}-{1}", PaternalSurName, MaternalSurName);
                    }
                    else
                    {
                        return String.Format("{0} {1}", PaternalSurName, MaternalSurName);
                    }
                }
                else if (HasPaternalSurName)
                {
                    return String.Format("{0}", PaternalSurName);
                }
                else if (UseMaternalSurName && HasMaternalSurName)
                {
                    return String.Format("{0}", MaternalSurName);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (UseMaternalSurName && value.Contains('-'))
                {
                    string[] parts = value.Split("-");
                    List<String> partList = new(parts);
                    PaternalSurName = partList[0];
                    partList.RemoveAt(0);
                    MaternalSurName = String.Join("-", partList);
                }
                else if (UseMaternalSurName && value.Contains(' '))
                {
                    string[] parts = value.Split(" ");
                    List<String> partList = new(parts);
                    PaternalSurName = partList[0];
                    partList.RemoveAt(0);
                    MaternalSurName = String.Join(" ", partList);
                }
                else if (UseMaternalSurName) MaternalSurName = value;
                else PaternalSurName = value;
            }
        }
        private String PaternalSurName { get; set; }
        private String MaternalSurName { get; set; }
        private String LocationName { get; set; }
        private String Suffix { get; set; }
        public PersonName()
        {
            Init();
        }
        public PersonName(String name, Boolean useTitle=false, Boolean useSuffix=false, Boolean useMaternal=false)
        {
            Init(name, useTitle, useSuffix, useMaternal);
        }
        protected override void Init()
        {
            base.Init(NameType.Person);
        }
        protected void Init(String name, Boolean useTitle = false, Boolean useSuffix = false, Boolean useMaternal = false)
        {
            Init();
            UseTitle = useTitle;
            UseSuffix = useSuffix;
            UseMaternalSurName = useMaternal;
            Value = name;
        }
        protected override void Init(String name)
        {
            Init(name, false, false, false);
        }
        protected override List<Boolean> OptionCombinationFlags(NameType type)
        {
            return new() { UseTitle, HasTitle, HasGivenName, HasMiddleName, HasSurName, UseSuffix, HasSuffix };
        }
        protected override List<String> OptionCombination(NameType type)
        {
            List<String> result = new();
            if (UseTitle && HasTitle) result.Add(Title);
            if (HasGivenName) result.Add(GivenName);
            if (HasMiddleName) result.Add(MiddleName);
            if (HasSurName) result.Add(SurName);
            if (UseSuffix && HasSuffix) result.Add(Suffix);
            return result;
        }
        protected override List<String> KeyOptionCombination(NameType type)
        {
            List<String> result = new();
            if (UseTitle && HasTitle) result.Add(IStringUtilities.Proper(Title));
            if (HasGivenName) result.Add(IStringUtilities.Proper(GivenName));
            if (HasMiddleName) result.Add(IStringUtilities.Proper(MiddleName));
            if (HasSurName) result.Add(IStringUtilities.Proper(SurName));
            if (UseSuffix && HasSuffix) result.Add(IStringUtilities.Proper(Suffix));
            return result;
        }
        public override void Parse(String value)
        {
            string[] parts;
            List<String> partsList;
            String subValue = value;
            Title = "";
            Suffix = "";
            MaternalSurName = "";
            PaternalSurName = "";
            if (UseTitle && subValue.Contains(" "))
            {
                parts = subValue.Split(" ");
                partsList = new(parts);
                Title = partsList[0];
                partsList.RemoveAt(0);
                subValue = String.Join(" ", partsList);
            }
            else if(UseTitle)
            {
                Title = subValue;
                subValue = "";
            }
            if (UseSuffix && subValue.Contains(" "))
            {
                parts = subValue.Split(" ");
                partsList = new(parts);
                Suffix = partsList[partsList.Count - 1];
                partsList.RemoveAt(partsList.Count - 1);
                subValue = String.Join(" ", partsList);
            }
            else if(UseSuffix)
            {
                Suffix = subValue;
                subValue = "";
            }
            if (UseMaternalSurName && subValue.Contains(" "))
            {
                parts = subValue.Split(" ");
                partsList = new(parts);
                MaternalSurName = partsList[partsList.Count - 1];
                partsList.RemoveAt(partsList.Count - 1);
                subValue = String.Join(" ", partsList);
            }
            else if (UseMaternalSurName)
            {
                MaternalSurName = subValue;
                subValue = "";
            }
            parts = subValue.Split(" ");
            partsList = new(parts);
            PaternalSurName = partsList[partsList.Count - 1];
            partsList.RemoveAt(partsList.Count - 1);
            subValue = String.Join(" ", partsList);
            parts = subValue.Split(" ");
            partsList = new(parts);
            GivenName = partsList[0];
            partsList.RemoveAt(0);
            MiddleName = String.Join(" ", partsList);
        }
        public override String ToNameString()
        {
            String format = IPersonName.FormatStrings[IBitwiseUtilities.OptionCombination(OptionCombinationFlags(Type))];
            List<String> parts = OptionCombination(Type);
            return String.Format(format, parts.ToArray());
        }
        internal override String ToKeyString()
        {
            String format = IPersonName.KeyFormatStrings[IBitwiseUtilities.OptionCombination(OptionCombinationFlags(Type))];
            List<String> parts = KeyOptionCombination(Type);
            return String.Format(format, parts.ToArray());
        }
        public static implicit operator PersonName(string name)
        {
            PersonName nameObject = new()
            {
                Value = name
            };
            return nameObject;
        }
        public static implicit operator string(PersonName name)
        {
            return name.Value;
        }
    }
    internal interface IPersonName
    {
        static List<Boolean> BaseAll { get { return new() { true, true, true, true, true, true, true }; } }
        static List<String> Groups { get { return new() { "1PartPersonName", "2PartPersonName", "3PartPersonName", "4PartPersonName", "5PartPersonName" }; } }
        static Dictionary<String, List<List<Boolean>>> BitWiseCombinations
        {
            get
            {
                int outerCounter, innerCounter;
                List<List<Boolean>> groupList;
                List<Boolean> combination;
                Dictionary<String, List<List<Boolean>>> result = new();
                Groups.ForEach(group => {
                    groupList = new();
                    result.Add(group, groupList);
                });
                for (outerCounter = IBitwiseUtilities.OptionCombination(BaseAll); outerCounter >= 0; outerCounter--)
                {
                    innerCounter = 0;
                    combination = IBitwiseUtilities.OptionCombination(outerCounter, BaseAll.Count);
                    if (combination[0] && combination[1]) innerCounter++;
                    if (combination[2]) innerCounter++;
                    if (combination[3]) innerCounter++;
                    if (combination[4]) innerCounter++;
                    if (combination[5] && combination[6]) innerCounter++;
                    if (innerCounter > 0)
                    {
                        groupList = result[Groups[innerCounter - 1]];
                        groupList.Add(combination);
                        result[Groups[innerCounter - 1]] = groupList;
                    }
                }
                return result;
            }
        }
        static Dictionary<String, String> GroupFormatStrings { get {
                Dictionary<String, String> result = new();
                Groups.ForEach(group => {
                    int index = Groups.IndexOf(group);
                    switch(index)
                    {
                        case 0:
                            result.Add(group, "{0}");
                            break;
                        case 1:
                            result.Add(group, "{0} {1}");
                            break;
                        case 2:
                            result.Add(group, "{0} {1} {2}");
                            break;
                        case 3:
                            result.Add(group, "{0} {1} {2} {3}");
                            break;
                        case 4:
                            result.Add(group, "{0} {1} {2} {3} {4}");
                            break;
                        default:
                            result.Add(group, "");
                            break;
                    }
                });
                return result;
            } }
        static Dictionary<String, String> GroupKeyFormatStrings
        {
            get
            {
                Dictionary<String, String> result = new();
                Groups.ForEach(group => {
                    int index = Groups.IndexOf(group);
                    switch (index)
                    {
                        case 0:
                            result.Add(group, "{0}");
                            break;
                        case 1:
                            result.Add(group, "{0}{1}");
                            break;
                        case 2:
                            result.Add(group, "{0}{1}{2}");
                            break;
                        case 3:
                            result.Add(group, "{0}{1}{2}{3}");
                            break;
                        case 4:
                            result.Add(group, "{0}{1}{2}{3}{4}");
                            break;
                        default:
                            result.Add(group, "");
                            break;
                    }
                });
                return result;
            }
        }
        static Dictionary<int, String> FormatStrings
        {
            get
            {
                Dictionary<int, String> result = new();
                Groups.ForEach(group => {
                    BitWiseCombinations[group].ForEach(combination =>
                    {
                        result.Add(IBitwiseUtilities.OptionCombination(combination), GroupFormatStrings[group]);
                    });
                });
                return result;
        } }
        static Dictionary<int, String> KeyFormatStrings
        {
            get
            {
                Dictionary<int, String> result = new();
                Groups.ForEach(group => {
                    BitWiseCombinations[group].ForEach(combination =>
                    {
                        result.Add(IBitwiseUtilities.OptionCombination(combination), GroupKeyFormatStrings[group]);
                    });
                });
                return result;
            }
        }
    }
}
