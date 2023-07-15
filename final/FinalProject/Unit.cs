using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonUnit : JsonDescribedObject
    {
        private Unit _unit { get { return (Unit)base._describedObject; } set { base._describedObject = value; } }
        public JsonUnit() : base(null, null) { }
        [JsonConstructor]
        public JsonUnit(JsonName Name, String Description) : base(Name, Description) { }
        public JsonUnit(Unit unit) : base((DescribedObject)unit) { }
        public static implicit operator JsonUnit(Unit unit)
        {
            return new(unit);
        }
        public static implicit operator Unit(JsonUnit unit)
        {
            return unit._unit;
        }
    }
    public class Unit : DescribedObject
    {
        public Unit(String unitName, String unitDescription)
        {
            Init(unitName, unitDescription);
        }
        public Unit(Boolean empty = true)
        {
            Init(empty);
        }
        public Unit(Unit unit)
        {
            Init(unit);
        }
        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the unit name.");
        }
        protected override void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the unit description.");
        }
        protected void Init(String unitName, String unitDescription, Boolean empty = true)
        {
            switch (unitName)
            {
                case "":
                    Init(false);
                    break;
                default:
                    Name = new ThingName(unitName);
                    Description = unitDescription;
                    break;
            }
        }
        private void Init(Unit unit)
        {
            Name = unit.Name;
            Description = unit.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override Unit CreateCopy(String newName)
        {
            Unit result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}