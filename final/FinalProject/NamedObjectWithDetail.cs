using System;

namespace FinalProject
{
    public abstract class NamedObjectWithDetail : NamedObject
    {
        protected String Description { get; set; }
        protected override void Init(Boolean empty = true)
        {
            Init(NameType.Thing, empty);
        }
        protected override void Init(NameType type, Boolean empty = true)
        {
            base.Init(type, empty);
            if (empty) Description = "";
            else RequestDescription(type);
        }
        protected override void Init(Name name)
        {
            base.Init(name);
        }
        protected virtual void Init(Name name, String description)
        {
            base.Init(name);
            Description = description;
        }
        protected virtual void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the description.");
        }
        protected void RequestDescription(NameType type)
        {
            DisplayRequestDescription();
            Description = IApplication.READ_RESPONSE();
        }
        protected Boolean IsDescribed()
        {
            return (Description != null) && (Description != "");
        }
        internal virtual void Display(Boolean name = true, Boolean description = true, int option = -1)
        {
            if (name) { base.Display(option); }
            if (name && description)
            {
                if (option >= 0)
                {
                    foreach (char character in option.ToString()) { Console.Write(' '); }
                    Console.WriteLine(String.Format("   {0}", Description));
                }
                else Console.WriteLine(String.Format("{0}", Description));
            }
            else if (description)
            {
                if (option >= 0) Console.WriteLine(String.Format("{0})  {1}", option, Description));
                else Console.WriteLine(String.Format("{0}", Description));
            }
        }
        protected virtual void DisplaySetDescription()
        {
            Console.WriteLine("\nSet Description");
        }
        protected virtual void DisplayRequestReSetDescription()
        {
            Console.WriteLine("\nRedescribe?");
        }
        protected virtual void DisplayRequestSetDescription()
        {
            Console.WriteLine("\nWhat is the description?");
        }
        internal void SetDescription()
        {
            Boolean setDescription = true;
            this.DisplaySetDescription();
            if (IsDescribed())
            {
                Display(false, true, -1);
                this.DisplayRequestReSetDescription();
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setDescription = false;
            }
            if (setDescription)
            {
                this.DisplayRequestSetDescription();
                Description = IApplication.READ_RESPONSE();
            }
        }
    }
}