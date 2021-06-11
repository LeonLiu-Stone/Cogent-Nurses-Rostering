using System;
using System.Collections.Generic;

namespace Nurses.Rostering.Models
{
	public class Job
	{
		public Job(Schedule schedule, Nurse nurse)
		{
			Schedule = schedule;
			Nurse = nurse;
		}

		public Schedule Schedule { get; set; }

		public Nurse Nurse { get; set; }

		public override string ToString()
		{
			return $"{Schedule.Date}  {Schedule.Shift.Name} ${Nurse.Name}";
		}
	}

	public class Roster
	{
		public List<Job> Jobs { get; set; } = new List<Job>();

		public void Write()
		{
			// Todo: should use _logger to print in console
			Console.WriteLine("\nRESULT ROSTER");
			Console.WriteLine("=============");
			Jobs.ForEach((job) => Console.WriteLine(job.ToString()));
		}
	}

}
