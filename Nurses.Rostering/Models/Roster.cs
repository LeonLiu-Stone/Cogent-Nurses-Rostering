using System;
namespace Nurses.Rostering.Models
{
	public class Roster
	{
		public Schedule Schedule { get; set; }

		public Nurse Nurse { get; set; }

		public void Write()
		{
			Console.WriteLine("\nRESULT ROSTER");
			Console.WriteLine("=============");
			// TODO: write the roster to stdout
		}
	}
}
