using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }


    // internal Bag screwdriver { get; private set; }

    public void Reset()
    {

    }

    public void Setup()
    {
      Start();
      // Player player = new Player();
      CurrentPlayer = new Player();
      CurrentRoom = new Room();
      CurrentPlayer.Score = 513;

      Item screwdriver = new Item("Screwdriver");
      Console.WriteLine(CurrentPlayer.Score);
      CurrentPlayer.Inventory.Add(screwdriver);
      Console.WriteLine(CurrentPlayer.Inventory[0].Name);
      // Start();
      System.Console.WriteLine();
      screwdriver.Take();
      Console.ReadLine();
      Console.ReadLine();
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
      Console.WriteLine();
      Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      Console.WriteLine("Here are the options you have to move about...");
      Console.WriteLine();
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");

      string input = Console.ReadLine().ToLower();
      switch (input)
      {
        case "n":
          Console.WriteLine("The door is locked.");
          Start();
          break;
        // case "e":
        //   Console.WriteLine("You are looking at a window, nowhere to exit to.");
        //   Start();
        //   break;
        // case "s":
        //   Console.WriteLine("You can't leave the door is stuck and the lock just fell off.");
        //   Start();
        //   break;
        case "w":
          Console.WriteLine("Looks like the door is locked.");
          Bedroom();
          break;
        case "h":
          Console.WriteLine("You have a few options.");
          Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
          Console.WriteLine("[(Quit)-(L)ook-(R)eset-(T)ake-(U)se]");
          Start();
          break;
          // case "take screwdriver":
          // Item screwdriver = new Item();
          // Item hammer = new Item();
          //  Item[] Inventory = new Item[2];
          // Inventory [0]  = screwdriver;
          // Inventory [1]  = hammer;
          //  List<Item> Inventory = new List<Item>();
          // Item screwdriver = new Item();
          Console.WriteLine(CurrentPlayer);
          // CurrentPlayer.Inventory.Add(screwdriver);
          Console.WriteLine(CurrentPlayer.Inventory[0].Name);
          // CurrentPlayer
          // CurrentPlayer.Inventory
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
      Console.WriteLine("Room 2");
      // Console.WriteLine("Where are the options you have to move about...");
      // Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      // Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      string input2 = Console.ReadLine().ToLower();
      switch (input2)
      {
        case "n":
          Kitchen();
          break;
        // case "e":

        //   break;
        // case "s":

        //   break;
        // case "w":

        // break;
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
      Console.WriteLine("Room 3");
      // Console.WriteLine("Where are the options you have to move about...");
      // Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      // Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      string input3 = Console.ReadLine().ToLower();
      switch (input3)
      {
        case "n":
          Living();
          break;
        // case "e":

        //   break;
        // case "s":

        //   break;
        // case "w":

        // break;
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
      Console.WriteLine("Room 4");
      // Console.WriteLine("Where are the options you have to move about...");
      // Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      // Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      string input4 = Console.ReadLine().ToLower();
      switch (input4)
      {
        case "n":
          System.Console.WriteLine("You win!");
          break;
        // case "e":

        //   break;
        // case "s":

        //   break;
        // case "w":

        //   break;
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


}
