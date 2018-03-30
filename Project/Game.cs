using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public bool doorLocked = true;
    public string help = "You have a few options. I would first (L)ook around a room, depending on what stage of construction the room is in, there might be some unsafe hazards.";
    public string help1 = "There are the directions you can move. Press the leter in the (Prens) [(N)orth-(E)ast-(S)outh,[W]est]";
    public string help2 = "Here are other options for the game. [(Quit)-(L)ook-(R)eset-(T)ake 'object')-(U)se 'object']";
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }


    // internal Bag screwdriver { get; private set; }

    public void Reset()
    {
      Setup();
    }

    public void Setup()
    {
      CurrentPlayer = new Player();
      CurrentRoom = new Room();

      Start();
      // Player player = new Player();
      // CurrentPlayer.Score = 513;

      // Item screwdriver = new Item("Screwdriver");
      // Console.WriteLine(CurrentPlayer.Score);
      // CurrentPlayer.Inventory.Add(screwdriver);
      // Console.WriteLine(CurrentPlayer.Inventory[0].Name);
      // // Start();
      // System.Console.WriteLine();
      // screwdriver.Take();
      // Console.ReadLine();
      // Console.ReadLine();
    }

    public void UseItem(string itemName)
    {

    }

    public void Quit()
    {
      System.Console.WriteLine("Do you want to Quit");
      string quit = System.Console.ReadLine().ToLower();

      switch (quit)
      {
        case "y":
          System.Console.WriteLine("You should come back sometime and see all the changes I have made.");
          return;
        case "n":
          Start();
          break;
        default:
          Start();
          break;
      }
    }

    public void Start()
    {
      Console.Clear();
      Console.WriteLine("Welcome to my House. Sorry its a mess! I was remodeling this place but then decided to go to code school before finishing all the projects, so Becareful there are lots of hazards around. The doors around here are falling apart so if you get stuck in a room, just find a tool and use it. Go ahead and take a look around, I need to run out to the back deck for something, meet me out there if I dont come back in a few minutes.");
      Console.WriteLine();
      Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      Console.WriteLine("Here are the options you have to move about...");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      Console.WriteLine();
      LivingRoom();
    }

    public void LivingRoom()
    {
      Console.WriteLine();
      Console.WriteLine("You are currently in the living room.");
      Console.WriteLine();
      string input = Console.ReadLine().ToLower();
      switch (input)
      {
        case "n":
          //kitchen
          Console.WriteLine("It appears that the bard door to the kitchen is Stuck. I think you might need a tool to fix that.");
          Console.WriteLine();
          LivingRoom();
          break;
        case "e":
          Console.WriteLine("You are facing a window.");
          Console.WriteLine();
          LivingRoom();
          break;
        case "s":
          //Front Door
          Console.WriteLine("You can't leave, you need to look around the house. You should find another way out.");
          Console.WriteLine();
          LivingRoom();
          break;
        case "w":
          //Bedroom
          if (doorLocked == true)
          {
            Console.WriteLine("The door is locked. You should look around to find a key.");
          }
          else
          {
            Bedroom();
          }
          LivingRoom();
          break;
        case "h":
          Console.Clear();
          Console.WriteLine(help);
          Console.WriteLine(help1);
          Console.WriteLine(help2);
          LivingRoom();
          Console.ReadLine();
          break;
        case "take key":
          Item key = new Item("Key");
          // Item screwdriver = new Item("Screwdriver");
          Console.WriteLine("You have a a key in your hand");
          key.Take();
          CurrentPlayer.Inventory.Add(key);
          // Console.WriteLine(CurrentPlayer.Inventory[0].Name);

          // Console.WriteLine(CurrentPlayer.Score);

          // CurrentPlayer.Inventory.Add(key);
          // Item screwdriver = new Item();
          // Item hammer = new Item();
          //  Item[] Inventory = new Item[2];
          // Inventory [0]  = screwdriver;
          // Inventory [1]  = hammer;
          //  List<Item> Inventory = new List<Item>();
          // Item screwdriver = new Item();
          // Console.WriteLine(CurrentPlayer);
          // CurrentPlayer.Inventory.Add(screwdriver);
          // Console.WriteLine(CurrentPlayer.Inventory[0].Name);
          // CurrentPlayer
          // CurrentPlayer.Inventory
          LivingRoom();
          break;
        // CurrentRoom.Items.
        case "use key":
          if (CurrentPlayer.Inventory.Count > 0)
          {
            doorLocked = false;
            CurrentPlayer.Inventory.RemoveAt(0);
            Console.WriteLine("You used the key to open the door");
          }
          else
          {
            Console.Write("You don't have a key.");
          }
          LivingRoom();
          break;
        case "i":
          if (CurrentPlayer.Inventory.Count == 0)
          {
            Console.WriteLine("You have nothing in your hands");
          }
          else
          {
            Console.WriteLine(CurrentPlayer.Inventory[0].Name);
          }
          LivingRoom();
          break;
        case "q":
          Quit();
          break;
        case "r":
          Reset();
          break;
        case "l":
          Console.WriteLine("As you look around the room, you notice the room is in bad condition. You see some keys hanging on the wall next to the front door.");
          LivingRoom();
          break;
        default:
          LivingRoom();
          break;
      }
    }
    public void Bedroom()
    {
      Console.WriteLine("You are in the bedroom.");
      // Console.WriteLine("Where are the options you have to move about...");
      // Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      // Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      string input2 = Console.ReadLine().ToLower();
      switch (input2)
      {
        case "n":
          Bathroom();
          break;
        case "e":
          LivingRoom();
          break;
        case "s":
          Console.WriteLine("You are facing a window.");
          break;
        case "w":
          Console.WriteLine("You are facing a closet.");
          break;
        case "h":
       
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
    public void Bathroom()
    {
      Console.WriteLine("Bathroom");
      Console.WriteLine();
      Console.WriteLine("You are in the bathroom. The tub is missing and their is random plumbing pipes coming out of the floor. Their is missing sheetrock on the walls.");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      string input3 = Console.ReadLine().ToLower();
      switch (input3)
      {
        case "n":
          Console.WriteLine("You are facing a cabinet.");
          break;
        case "e":
          Console.WriteLine("You are facing a Toilet.");
          Bathroom();
          break;
        case "s":
          Bedroom();
          break;
        case "w":
          Console.WriteLine("You fell into a hole where the tub was, you hurt yourself.");
          Console.WriteLine("You LOSE>>>");
          Quit();
          break;
        case "h":
         
          break;
        case "i":

          break;
        case "q":
          Quit();
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
      Console.WriteLine("Kitchen");
      // Console.WriteLine("Where are the options you have to move about...");
      // Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      // Console.WriteLine("Where are the options you have to move about...");
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      string input4 = Console.ReadLine().ToLower();
      switch (input4)
      {
        case "n":
          Console.WriteLine("Hey man you made it, sorry I didn't get back to you but did you take a look around. This place needs a lot of work huh?");
          System.Console.WriteLine("You win!");
          Quit();
          break;
        case "e":
          Console.WriteLine("You are facing countertops and range.");
          Kitchen();
          break;
        case "s":
          LivingRoom();
          break;
        case "w":
          Console.WriteLine("You are facing a refrigerator.");
          Kitchen();
          break;
        case "h":
        
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
