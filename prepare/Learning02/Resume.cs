using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Job job;
        Console.WriteLine($"Name:  {_name}");
        Console.WriteLine("Jobs:");
        _jobs.ForEach(delegate (Job job)
        {
            job.Display();
        });
    }
}