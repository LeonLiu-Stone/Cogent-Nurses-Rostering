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
	}

	public class Roster
	{
		public List<Job> Jobs { get; set; } = new List<Job>();
	}

}
