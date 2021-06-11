using System;

namespace Nurses.Rostering.Models
{
	public class Schedule
	{
		public DateTime Date { get; set; }

		public Shift Shift { get; set; }
	}
}
