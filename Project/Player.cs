using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Player : IPlayer
  {
    public int Score { get; set; } = 0;
    public List<Item> Inventory { get; set; }

    public Player()
    {
      Inventory = new List<Item>();
    }
  }

}