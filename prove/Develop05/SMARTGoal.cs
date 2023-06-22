using Develop05External;
using System.Text.Json.Serialization;

namespace Develop05
{
    public abstract class SMARTGoal : Goal
    {
        /**
         * S - Specific
         * M - Measurable
         * A - Attainable
         * R - Realistic
         * T - Timely
         */
        internal DateTime Created { get; set; }
        internal int Timely { get; set; }
        internal int TimelyPointPentalty { get; set; }
        protected override void Init(Configuration configuration, Boolean empty = false) {
            Created = DateTime.Now;
            base.Init(configuration, empty);
            if (empty)
            {
                Timely = 0;
                TimelyPointPentalty = 0;
            }
            else
            {
                RequestIsSpecific();
                RequestIsMeasurable();
                RequestIsAttainable();
                RequestIsRealistic();
                RequestTimely();
                RequestTimelyPointPentalty();
            }
        }
        protected override void Init(Goal goal)
        {
            if(goal.GetType() == typeof(SMARTGoal)) Init((SMARTGoal)goal);
            else if (goal.GetType() == typeof(SimpleSMARTGoal)) Init((SMARTGoal)goal);
            else if (goal.GetType() == typeof(EternalSMARTGoal)) Init((SMARTGoal)goal);
            else if (goal.GetType() == typeof(ChecklistSMARTGoal)) Init((SMARTGoal)goal);
            else
            {
                Created = DateTime.Now;
                base.Init(goal);
                Timely = 0;
                TimelyPointPentalty = 0;
            }
        }
        protected virtual void Init(SMARTGoal goal)
        {
            Created = goal.Created;
            base.Init(goal);
            Timely = goal.Timely;
            TimelyPointPentalty = goal.TimelyPointPentalty;
        }
        protected virtual String GetRequestIsSpecificMessageKey()
        {
            return "RequestIsSpecificMessage";
        }
        protected virtual String GetRequestIsMeasurableMessageKey()
        {
            return "RequestIsMeasurableMessage";
        }
        protected virtual String GetRequestIsAttainableMessageKey()
        {
            return "RequestIsAttainableMessage";
        }
        protected virtual String GetRequestIsRealisticMessageKey()
        {
            return "RequestIsRealisticMessage";
        }
        protected virtual void DisplayRequestTimely()
        {
            Console.WriteLine(Configuration.Dictionary["RequestTimelyMessage"]);
        }
        protected virtual void DisplayRequestTimelyPointPentalty()
        {
            Console.WriteLine(Configuration.Dictionary["RequestTimelyPointPentaltyMessage"]);
        }
        private Boolean RequestIs(String messageKey)
        {
            String response = "undefined";
            while (response != "y" && response != "yes" && response != "n" && response != "no" && response != "")
            {
                Console.WriteLine(Configuration.Dictionary[messageKey]);
                response = IApplication.READ_RESPONSE(Configuration);
            }
            if (response == "y" || response == "yes" || response == "") return true;
            else return false;
        }
        private void RequestIsSpecific()
        {
            while(!RequestIs(GetRequestIsSpecificMessageKey())) RequestDescription();
        }
        private void RequestIsMeasurable()
        {
            while (!RequestIs(GetRequestIsMeasurableMessageKey())) RequestDescription();
        }
        private void RequestIsAttainable()
        {
            while (!RequestIs(GetRequestIsAttainableMessageKey())) RequestDescription();
        }
        private void RequestIsRealistic()
        {
            while (!RequestIs(GetRequestIsRealisticMessageKey())) RequestDescription();
        }
        private void RequestTimely()
        {
            Timely = -1;
            while(Timely < 0)
            {
                DisplayRequestTimely();
                try
                {
                    Timely = int.Parse(IApplication.READ_RESPONSE(Configuration));
                }
                catch
                {
                    Timely = -1;
                }
            }
        }
        private void RequestTimelyPointPentalty()
        {
            TimelyPointPentalty = -1;
            while (TimelyPointPentalty < 0)
            {
                DisplayRequestTimelyPointPentalty();
                try
                {
                    TimelyPointPentalty = int.Parse(IApplication.READ_RESPONSE(Configuration));
                }
                catch
                {
                    TimelyPointPentalty = -1;
                }
            }
        }
    }
    [Serializable]
    public abstract class JSONSMARTGoal : JSONGoal/*, SMARTGoal*/
    {
        [JsonInclude]
        [JsonPropertyName("Created")]
        [JsonPropertyOrder(3)]
        public DateTime Created {
            get
            {
                return Base.Created;
            }
            set
            {
                Base.Created = value;
            }
        }
        [JsonInclude]
        [JsonPropertyName("Days Due")]
        [JsonPropertyOrder(4)]
        public int Timely {
            get
            {
                return Base.Timely;
            }
            set
            {
                Base.Timely = value;
            }
        }
        [JsonInclude]
        [JsonPropertyName("Overdue Point Pentalty")]
        [JsonPropertyOrder(5)]
        public int TimelyPointPentalty {
            get
            {
                return Base.TimelyPointPentalty;
            }
            set
            {
                Base.TimelyPointPentalty = value;
            }
        }
        protected SMARTGoal Base { get; set; }
        [JsonConstructor]
        public JSONSMARTGoal() {
            Init();
        }
        public virtual void Init()
        {
            Base = new SimpleSMARTGoal(Configuration, true);
            base.Init(Configuration, true);
        }
        protected void Init(SMARTGoal goal)
        {
            Base = goal;
            base.Init(goal);
        }
    }
}
