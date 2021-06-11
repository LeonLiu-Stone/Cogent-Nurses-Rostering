using System;

namespace Nurses.Rostering.Models
{
	public class Schedule
	{
		public Schedule(DateTime dateTime, Shift shift) {
			Date = dateTime.ToString("yyyy-MM-dd");
			Shift = shift;
		}

		public string Date { get; }

		public Shift Shift { get; set; }
	}
}
