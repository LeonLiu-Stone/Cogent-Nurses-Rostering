using System;
namespace Nurses.Rostering.Models
{
	public class Nurse
	{
		public Nurse() { }

		public Nurse(string uid, string name) {
			Uid = uid;
			Name = name;
		}

		public string Uid { get; set; }

		public string Name { get; set; }

		public bool Equals(Nurse other)
		{
			if (Object.ReferenceEquals(this, other)) return true;
			return Uid.Equals(other.Uid) && Name.Equals(other.Name);
		}

		public override int GetHashCode()
		{
			return Uid.GetHashCode() ^ Name.GetHashCode();
		}
	}
}
