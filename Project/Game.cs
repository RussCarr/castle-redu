using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public bool doorLocked = true;
    public bool barndoorStuck = true;
    public bool keysUsed = false;
    public string help = "You have a few options. I would first (L)ook around a room, depending on what stage of construction the room is in, there might be some unsafe hazards.";
    public string help1 = "There are the directions you can move. Press the leter in the (Prens) [(N)orth-(E)ast-(S)outh,[W]est]";
    public string help2 = "Here are other options for the game. [(Quit)-(L)ook-(R)eset-(Take 'object')-(Use 'object']";
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
      Console.ForegroundColor = ConsoleColor.DarkRed;
      System.Console.WriteLine("Do you want to Quit");
      string quit = System.Console.ReadLine().ToLower();

      switch (quit)
      {
        case "y":
          Console.WriteLine();
          Console.ForegroundColor = ConsoleColor.DarkMagenta;
          System.Console.WriteLine("You should come back sometime and see all the changes I have made.");
          Console.ForegroundColor = ConsoleColor.White;
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
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Gray;
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
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine();
      Console.WriteLine("You are currently in the living room. There is currently no carpet on the floor. The wall to the  north has a barn door but it doesnt looks like it might be hanging funny. There is a door to the east. Man there sure isn't much for furniture in the living room. The west wall has a window with broken blinds. ");
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      string input = Console.ReadLine().ToLower();
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Cyan;
      switch (input)
      {
        case "n":
          //kitchen
          Console.WriteLine("It appears that the barn door to the kitchen is Stuck. I think you might need a tool to fix that.");
          Console.WriteLine();
          LivingRoom();
          break;
        case "e":
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
        case "s":
          //Front Door
          Console.WriteLine("You can't leave, the door knob just fell out, you need to look around the house to find another way out.");
          Console.WriteLine();
          LivingRoom();
          break;
        case "w":
          Console.WriteLine("You are facing a window.");
          Console.WriteLine();
          LivingRoom();
          break;
        case "l":
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("As you look around the room, you notice the room is in bad condition. You see some keys hanging on the wall next to the front door.");
          Console.ForegroundColor = ConsoleColor.White;
          LivingRoom();
          break;
        case "take screwdriver":
          if (barndoorStuck == false)
          {
            System.Console.WriteLine("You don't need that screwdriver anymore.");
          }
          else if (doorLocked == true)
          {
            System.Console.WriteLine("There isn't a screwdriver in here.");
          }
          else if (keysUsed == false)
          {
            System.Console.WriteLine("There isn't a screwdriver in here.");
          }
          else
          {
            Console.WriteLine();
            Console.WriteLine("You already have a screwdriver in your hand.");
          }
          LivingRoom();

          break;
        case "take keys":
          if (doorLocked == false)
          {
            System.Console.WriteLine("You don't need those keys.");
          }
          else
          {
            Item keys = new Item("Keys");
            keys.Take();
            Console.WriteLine();
            Console.WriteLine("You now have keys in your hand.");
            CurrentPlayer.Inventory.Add(keys);
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
          }
          break;
        // CurrentRoom.Items.
        case "use screwdriver":
          if (CurrentPlayer.Inventory.Count > 0)
          {
            barndoorStuck = false;
            CurrentPlayer.Inventory.RemoveAt(0);
            Console.WriteLine("You used the screwdriver to open the barn door. You put the screwdriver next to the the keys.");
          }
          else
          {
            Console.Write("You don't have a screwdriver.");
          }
          LivingRoom();
          break;
        case "use keys":
          if (CurrentPlayer.Inventory.Count > 0)
          {
            doorLocked = false;
            keysUsed = true;
            CurrentPlayer.Inventory.RemoveAt(0);
            Console.WriteLine("You used the keys to open the door, you have put them back.");
          }
          else
          {
            Console.Write("You don't have a key.");
          }
          LivingRoom();
          break;
        case "take":
          Console.WriteLine();
          Console.WriteLine("What do you want to take?");
          LivingRoom();
          break;
        case "use":
          Console.WriteLine();
          Console.WriteLine("What do you want to use?");
          LivingRoom();
          break;
        case "i":
          if (CurrentPlayer.Inventory.Count == 0)
          {
            Console.WriteLine("You have nothing in your hands");
          }
          else
          {
            Console.WriteLine("You are holding " + CurrentPlayer.Inventory[0].Name + "in your hands.");
          }
          LivingRoom();
          break;
        case "h":
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Clear();
          Console.WriteLine(help);
          Console.WriteLine(help1);
          Console.WriteLine(help2);
          Console.WriteLine();
          Console.WriteLine("Press enter to clear help menu.");
          Console.ReadLine();
          LivingRoom();
          break;
        case "q":
          Quit();
          break;
        case "r":
          Reset();
          break;
        default:
          LivingRoom();
          break;
      }
    }
    public void Bedroom()
    {
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine();
      Console.WriteLine("You are in the bedroom. This room is full of construction materials and its hard to move around. ");
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      string input2 = Console.ReadLine().ToLower();
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Cyan;
      switch (input2)
      {
        case "n":
          Bathroom();
          break;
        case "w":
          LivingRoom();
          break;
        case "s":
          Console.WriteLine("You are facing a window. The window blinds are currently closed.");
          Console.WriteLine();
          Bedroom();
          break;
        case "e":
          Console.WriteLine("You are facing a wall that has a bunch of building supplies leaning agaist it.");
          Console.WriteLine();
          Bedroom();
          break;
        case "l":
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("To the north you see a door possibly to a bathroom. The south wall has a window. The west wall has a bunch of sheetrock leaning agaist it.");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine();
          Bedroom();
          break;
        case "take":
          Console.WriteLine();
          Console.WriteLine("What do you want to take?");
          Bedroom();
          break;
        case "use screwdriver":
          Console.WriteLine();
          Console.WriteLine("You can't fix anything in here.");
          Bedroom();
          break;
        case "use":
          Console.WriteLine();
          Console.WriteLine("What do you want to use?");
          Bedroom();
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
          Bedroom();
          break;
        case "h":
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Clear();
          Console.WriteLine(help);
          Console.WriteLine(help1);
          Console.WriteLine(help2);
          Console.WriteLine();
          Console.WriteLine("Press enter to clear help menu.");
          Console.ReadLine();
          Bedroom();
          break;
        case "q":
          Quit();
          break;
        case "r":
          Reset();
          break;
        default:
          Bedroom();
          break;
      }
    }
    public void Bathroom()
    {
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine();
      Console.WriteLine("You are in the bathroom. The tub is missing and there is random plumbing pipes coming out of the wall. There is missing sheetrock on the walls and some bare studs. The vanity sink is dirty like it hasnt been used much.");
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      string input3 = Console.ReadLine().ToLower();
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Cyan;
      switch (input3)
      {
        case "n":
          Console.WriteLine("You are facing the vanity cabinet.");
          Bathroom();
          break;
        case "e":
          Console.WriteLine("You are facing a toilet.");
          Bathroom();
          break;
        case "s":
          Bathroom();
          break;
        case "w":
          Console.WriteLine("You fell into a hole where the tub was, you broke your neck.");
          Console.WriteLine("You LOSE!!!");
          Console.WriteLine();
          Quit();
          break;
        case "l":
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("To the north you see a vanity cabinet and sink, on top of the sink is a screwdriver. The east was has a crummy looking toilet. The west wall is where a tub used to be and there is a big hole in the floor, you can see down into the basement.");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine();
          Bathroom();
          break;
        case "take screwdriver":
          Item screwdriver = new Item("screwdriver");
          screwdriver.Take();
          Console.WriteLine();
          Console.WriteLine("You now have a screwdriver in your hand.");
          CurrentPlayer.Inventory.Add(screwdriver);
          Bathroom();
          break;
        case "use screwdriver":
          Console.WriteLine();
          Console.WriteLine("You can't fix anything in here.");
          Bathroom();
          break;
        case "take":
          Console.WriteLine();
          Console.WriteLine("What do you want to take?");
          Bathroom();
          break;
        case "use":
          Console.WriteLine();
          Console.WriteLine("What do you want to use?");
          Bathroom();
          break;
        case "i":
          if (CurrentPlayer.Inventory.Count == 0)
          {
            Console.WriteLine("You have nothing in your hands");
          }
          else
          {
            Console.WriteLine("You are holding " + CurrentPlayer.Inventory[0].Name + "in your hands.");
          }
          Bathroom();
          break;
        case "h":
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Clear();
          Console.WriteLine(help);
          Console.WriteLine(help1);
          Console.WriteLine(help2);
          Console.WriteLine();
          Console.WriteLine("Press enter to clear help menu.");
          Console.ReadLine();
          Bathroom();
          break;
        case "q":
          Quit();
          break;
        case "r":
          Reset();
          break;
        default:
          Bathroom();
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
        case "l":

          break;
        case "i":

          break;
        case "h":
          Console.Clear();
          Console.WriteLine(help);
          Console.WriteLine(help1);
          Console.WriteLine(help2);
          LivingRoom();
          Console.ReadLine();
          break;
        case "q":
          Quit();
          break;
        case "r":
          Reset();
          break;
        default:
          LivingRoom();
          break;
      }
    }
  }


}
