using System;

namespace Nurses.Rostering.Models
{
	public class Schedule
	{
		public Schedule(DateTime dateTime, string shiftName) {
			Date = dateTime.ToString("yyyy-MM-dd");
			Shift = new Shift(shiftName);
		}

		public string Date { get; }

		public Shift Shift { get; set; }
	}
}
