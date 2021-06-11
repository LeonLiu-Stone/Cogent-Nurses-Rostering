# pragma warning disable 1591

using System;

namespace Nurses.Rostering
{
    public class Nurse : IEquatable<Nurse>
    {
        public string uid  { get; set; }
        public string name { get; set; }

        public bool Equals(Nurse other)
        {
            if (Object.ReferenceEquals(this, other)) return true;
            return uid.Equals(other.uid) && name.Equals(other.name);
        }

        public override int GetHashCode()
        {
            return uid.GetHashCode() ^ name.GetHashCode();
        }
    }
}