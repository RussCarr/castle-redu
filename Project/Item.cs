using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public void Take()
    {
        System.Console.WriteLine("You have taken the" + Name);
    }

       public Item(string name)
    {
      Name = name;
    }
  }

}