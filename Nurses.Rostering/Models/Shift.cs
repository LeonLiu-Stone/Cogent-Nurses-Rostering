using System;

namespace Nurses.Rostering.Models
{
  public class Shift
  {
    public Shift(string name) {
      Name = name;
    }
    
    public string Name { get; set; }
  }
}
