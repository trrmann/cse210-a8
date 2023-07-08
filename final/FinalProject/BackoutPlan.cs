namespace FinalProject
{
    public class BackoutPlan : Plan
    {
        public BackoutPlan(Plan plan) : base(plan)
        {
        }

        public BackoutPlan(Organizations organizations) : base(organizations)
        {
        }

        public BackoutPlan(Plan plan, Organizations organizations) : base(plan, organizations)
        {
        }
    }
}