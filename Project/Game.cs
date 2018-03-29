using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    internal static void setup()
    {
       Player CurrentPlayer = new Player();
      Room CurrentRoom = new Room();
    }

    internal Bag screwdriver { get; private set; }

    public void Reset()
    {

    }

    public void Setup()
    {
     
      Start();
      
    }

    public void UseItem(string itemName)
    {

    }
    public void Help()
    {
      Console.WriteLine("You have a few options.");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      Console.WriteLine("[(Quit)-(L)ook-(R)eset-(T)ake 'object')-(U)se 'object']");
      return;
    }

    public void Start()
    {
      Console.Clear();
      Console.WriteLine("Welcome to my House. Its a mess because I was remodeling this place but I decided to go to code school before finishing. Becareful there are lots of hazards laying around. The doors around here are falling apart so if you get stuck in a room, just find a tool and use it.");
      Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");

      string input = Console.ReadLine().ToLower();
      switch (input)
      {
        case "n":
          Console.WriteLine("The door is locked.");
          Start();
          break;
        case "e":
          Console.WriteLine("You are looking at a window, nowhere to exit to.");
          Start();
          break;
        case "s":
          Console.WriteLine("You can't leave the door is stuck and the lock just fell off.");
          Start();
          break;
        case "w":
          Console.WriteLine("Looks like the door is locked.");
          Start();
          break;
        case "h":
          Console.WriteLine("You have a few options.");
          Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
          Console.WriteLine("[(Quit)-(L)ook-(R)eset-(T)ake-(U)se]");
          Start();
          break;
        case "take screwdriver":
          // Item screwdriver = new Item();
          //  Bag[] Inventory = new Bag[0];
          // Inventory [0]  = screwdriver;
          // Inventory [1]  = hammer;
          //  List<Item> screwdriver = new List<Item>();
          // CurrentPlayer.Inventory.Add(screwdriver);
          return;
        // CurrentRoom.Items.
        case "use screwdriver":
          // if (screwdriver)
          // {
          //   Console.WriteLine("you used a screwdrive to open the door");
          // }
          // else
          // {
          //   Console.Write("Door is locked, find an object to open the door.");
          // }
          return;

        case "i":

          break;
        case "q":
          Console.WriteLine("GoodBye");
          break;
        case "r":
          Start();
          break;
        case "l":
          Console.WriteLine("Looks like all the doors are locked. There is screwdriver laying on the floor.");
          return;

        default:
          Start();
          break;
      }
    }
    public void Living()
    {
      Console.WriteLine("Welcome to my House. Its a mess because I have been remodeling this place but I decided to go to code school before finishing. Becareful there are lots of hazards laying around.");
      Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      string input = Console.ReadLine().ToLower();
      switch (input)
      {
        case "n":

          break;
        case "e":

          break;
        case "s":

          break;
        case "w":

          break;
        case "h":
          Help();
          break;
        case "i":

          break;
        case "q":
          Console.WriteLine("GoodBye");
          break;
        case "r":
          Start();
          break;
        default:
          Start();
          break;
      }
    }
    public void Kitchen()
    {
      Console.WriteLine("Welcome to my House. Its a mess because I have been remodeling this place but I decided to go to code school before finishing. Becareful there are lots of hazards laying around.");
      Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      string input = Console.ReadLine().ToLower();
      switch (input)
      {
        case "n":

          break;
        case "e":

          break;
        case "s":

          break;
        case "w":

          break;
        case "h":
          Help();
          break;
        case "i":

          break;
        case "q":
          Console.WriteLine("GoodBye");
          break;
        case "r":
          Start();
          break;
        default:
          Start();
          break;
      }
    }
    public void Bedroom()
    {
      Console.WriteLine("Welcome to my House. Its a mess because I have been remodeling this place but I decided to go to code school before finishing. Becareful there are lots of hazards laying around.");
      Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      string input = Console.ReadLine().ToLower();
      switch (input)
      {
        case "n":

          break;
        case "e":

          break;
        case "s":

          break;
        case "w":

          break;
        case "h":
          Help();
          break;
        case "i":

          break;
        case "q":
          Console.WriteLine("GoodBye");
          break;
        case "r":
          Start();
          break;
        default:
          Start();
          break;
      }
    }
  }

  internal class Bag
  {
  }
}
