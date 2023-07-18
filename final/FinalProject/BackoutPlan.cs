using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonBackoutPlan), typeDiscriminator: "BackoutPlan")]
    internal class JsonBackoutPlan : JsonPlan
    {
        protected new BackoutPlan BackoutPlan { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return BackoutPlan;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(BackoutPlan)))
                {
                    BackoutPlan = (BackoutPlan)value;
                }
                else
                {
                    BackoutPlan = new();
                    BackoutPlan.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description {
            get {
                if(BackoutPlan is null) BackoutPlan = new();
                return BackoutPlan.Description;
            } set {
                if (BackoutPlan is null) BackoutPlan = new();
                BackoutPlan.Description = value;
            } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Manager")]
        public new JsonName Manager { get { return BackoutPlan.Manager; } set { BackoutPlan.Manager = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Tasks")]
        public new JsonTasks Tasks { get { return BackoutPlan.Tasks; } set { BackoutPlan.Tasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Risks")]
        public new JsonRisks Risks { get { return BackoutPlan.Risks; } set { BackoutPlan.Risks = value; } }
        public JsonBackoutPlan() : base()
        {
            this.Plan = new(true, false);
        }
        [JsonConstructor]
        public JsonBackoutPlan(JsonNamedObject NamedObject, String Description, JsonName Manager, JsonTasks Tasks, JsonRisks Risks) : base()
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.Manager = Manager;
            this.Tasks = Tasks;
            this.Risks = Risks;
        }
        public JsonBackoutPlan(BackoutPlan Plan) : base()
        {
            this.Plan = Plan;
        }
        public static implicit operator JsonBackoutPlan(BackoutPlan plan)
        {
            return new(plan);
        }
        public static implicit operator BackoutPlan(JsonBackoutPlan plan)
        {
            if(plan is null ) return null;
            else return plan.BackoutPlan;
        }
    }
    public class BackoutPlan : Plan
    {
        public BackoutPlan(Plan plan) : base(plan)
        {
        }
        public BackoutPlan() : base(true, false)
        {
        }
    }
}