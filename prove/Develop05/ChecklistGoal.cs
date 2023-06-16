﻿using System.Text.Json.Serialization;

namespace Develop05
{
    public class ChecklistGoal : Goal
    {
        public ChecklistGoal(Boolean empty = false)
        {
            Init(empty);
        }
        protected new void Init(Boolean empty = false)
        {
            base.Init(empty);
            if(empty)
            {
                NumberOfTimes = 0;
                BonusPointValue = 0;
            } else
            {
                RequestNumberOfTimes();
                RequestBonusPoints();
            }
            NumberOfTimes = 0;
        }
        internal int TargetNumberOfTimes { get; set; }
        internal int NumberOfTimes { get; set; }
        internal int BonusPointValue { get; set; }
        public override void DisplayRequestPointValue()
        {
            Console.WriteLine("Please enter the point value for each completion of your goal.");
        }
        public virtual void DisplayRequestNumberOfTimes()
        {
            Console.WriteLine("Please enter the number times required to complete your overall goal.");
        }
        public virtual void DisplayRequestBonusPoints()
        {
            Console.WriteLine("Please enter the bonus point value of your overall goal.");
        }
        public void RequestNumberOfTimes()
        {
            DisplayRequestNumberOfTimes();
            TargetNumberOfTimes = int.Parse(ReadResponse());
        }
        public void RequestBonusPoints()
        {
            DisplayRequestBonusPoints();
            BonusPointValue = int.Parse(ReadResponse());
        }
        internal static Boolean IsCompleted(ChecklistGoal goal)
        {
            return goal.NumberOfTimes >= goal.TargetNumberOfTimes;
        }
        public override Boolean IsCompleted()
        {
            return IsCompleted(this);
        }
        internal static void DisplayGoal(ChecklistGoal goal, int index = -1)
        {
            String check = " ";
            if (goal.IsCompleted()) check = "X";
            if (index >= 0) Console.WriteLine($"{index})  [{check}] {goal.Name}({goal.Description}) {goal.NumberOfTimes}/{goal.TargetNumberOfTimes}");
            else Console.WriteLine($"[{check}] {goal.Name}({goal.Description}) {goal.NumberOfTimes}/{goal.TargetNumberOfTimes}");
        }
        public override void DisplayGoal(int index = -1)
        {
            DisplayGoal(this, index);
        }
        internal static int Report(ChecklistGoal goal)
        {
            goal.NumberOfTimes++;
            if (goal.IsCompleted()) return goal.PointValue + goal.BonusPointValue;
            else return goal.PointValue;
        }
        public override int Report()
        {
            return Report(this);
        }
        public static explicit operator ChecklistGoal(JSONGoal goal)
        {
            ChecklistGoal result = null;
            if (goal.GetType() == typeof(JSONChecklistGoal))
            {
                result = new(true);
                result.Init((JSONChecklistGoal)goal);
                result.TargetNumberOfTimes = ((JSONChecklistGoal)goal).TargetNumberOfTimes;
                result.NumberOfTimes = ((JSONChecklistGoal)goal).NumberOfTimes;
                result.BonusPointValue = ((JSONChecklistGoal)goal).BonusPointValue;
            }
            return result;
        }
    }
    [Serializable]
    internal class JSONChecklistGoal : JSONGoal
    {
        [JsonConstructor]
        public JSONChecklistGoal() { }
        [JsonInclude]
        [JsonPropertyName("Target Number of Times")]
        [JsonPropertyOrder(5)]
        public int TargetNumberOfTimes { get; set; }
        [JsonInclude]
        [JsonPropertyName("Number of Times")]
        [JsonPropertyOrder(4)]
        public int NumberOfTimes { get; set; }
        [JsonInclude]
        [JsonPropertyName("Bonus Point Value")]
        [JsonPropertyOrder(3)]
        public int BonusPointValue { get; set; }
        public JSONChecklistGoal(Goal goal)
        {
            if (goal.GetType() == typeof(ChecklistGoal))
            {
                Init((ChecklistGoal)goal);
                TargetNumberOfTimes = ((ChecklistGoal)goal).TargetNumberOfTimes;
                NumberOfTimes = ((ChecklistGoal)goal).NumberOfTimes;
                BonusPointValue = ((ChecklistGoal)goal).BonusPointValue;
            }
        }
        public override void DisplayGoal(int index = -1)
        {
            ChecklistGoal.DisplayGoal((ChecklistGoal)(Goal)(JSONGoal)this, index);
        }
        public override bool IsCompleted()
        {
            return ChecklistGoal.IsCompleted((ChecklistGoal)(Goal)(JSONGoal)this);
        }
        public override int Report()
        {
            return ChecklistGoal.Report((ChecklistGoal)(Goal)(JSONGoal)this);
        }
    }
}