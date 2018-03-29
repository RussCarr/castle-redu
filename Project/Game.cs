using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void Reset()
    {
      
    }

    public void Setup()
    {
     Player CurrentPlayer = new Player();
     Room CurrentRoom = new Room();
     
    }

    public void UseItem(string itemName)
    {
      
    }
  }
}