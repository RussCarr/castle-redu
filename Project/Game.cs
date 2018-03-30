using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public bool doorLocked = true;
    public bool barndoorStuck = true;
    public bool keysUsed = false;
    public bool screwdriverUsed = false;
    public string help = "You have a few options. I would first (L)ook around a room, depending on what stage of construction the room is in, there might be some unsafe hazards.";
    public string help1 = "There are the directions you can move. Press the leter in the (Prens) [(N)orth-(E)ast-(S)outh,[W]est]";
    public string help2 = "Here are other options for the game. [(Quit)-(L)ook-(R)eset-(Take 'object')-(Use 'object']";
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }


    // internal Bag screwdriver { get; private set; }

    public void Setup()
    {
      CurrentPlayer = new Player();
      CurrentRoom = new Room();
      Start();
    }

    public void UseItem(string itemName)
    {

    }

    public void Quit()
    {
      Console.ForegroundColor = ConsoleColor.DarkRed;
      System.Console.WriteLine("Do you want to Quit");
      string quit = System.Console.ReadLine().ToLower();
      Console.WriteLine();
      switch (quit)
      {
        case "y":
          Console.WriteLine();
          Console.ForegroundColor = ConsoleColor.DarkMagenta;
          System.Console.WriteLine("You should come back sometime and see all the changes I have made.");
          Console.ForegroundColor = ConsoleColor.White;
          Environment.Exit(0);
          break;
        case "n":
          Start();
          break;
        default:
          Quit();
          break;
      }
    }
    public void Win()
    {

      Console.ForegroundColor = ConsoleColor.DarkRed;
      System.Console.WriteLine("Do you want to Play again?");
      string playAgain = System.Console.ReadLine().ToLower();
      Console.WriteLine();
      switch (playAgain)
      {
        case "y":
          if (CurrentPlayer.Inventory.Count > 0)
          {
            CurrentPlayer.Inventory.RemoveAt(0);
            System.Console.WriteLine("Reset");
          }
          else
          {
            System.Console.WriteLine("Reset");
          }
          doorLocked = true;
          barndoorStuck = true;
          keysUsed = false;
          Start();
          break;
        case "n":
          Quit();
          break;
        default:
          Win();
          break;
      }

    }

    public void Start()
    {
      Console.Clear();
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine("Welcome to my House. Sorry its a mess! I was remodeling this place but then decided to go to code school before finishing all the projects, so be careful there are lots of hazards around. The doors around here are falling apart so if you get stuck in a room, just find a tool and use it. Go ahead and take a look around, I need to run out to the back deck for something, meet me out there if I dont come back in a few minutes.");
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("If you need help with how to move around you can ask for (H)elp.");
      Console.WriteLine("Here are the options you have to move about...");
      Console.WriteLine();
      Console.WriteLine("[(N)orth-(E)ast-(S)outh,[W]est]");
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine();
      LivingRoom();
    }

    public void LivingRoom()
    {
      Console.ForegroundColor = ConsoleColor.DarkGray;
      Console.WriteLine("Living Room");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine();
      Console.WriteLine("You are currently in the living room. There is currently no carpet on the floor. The wall to the north has a barn door but it doesnt looks like it might be hanging funny. There is a door to the east. Man there sure isn't much for furniture in the living room. The west wall has a window with broken blinds. ");
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      string input = Console.ReadLine().ToLower();
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Cyan;
      switch (input)
      {
        case "n":

          if (barndoorStuck == true)
          {

            Console.WriteLine();
            Console.WriteLine("It appears that the barn door to the kitchen is Stuck. I think you might need a tool to fix that.");
            Console.WriteLine();
            LivingRoom();
          }
          else
          {
            Console.WriteLine();
            Console.Clear();
            Kitchen();
          }
          break;
        case "e":

          if (doorLocked == true)
          {
            Console.WriteLine();
            Console.WriteLine("The door is locked. You should look around to find a key.");
          }
          else
          {
            Console.Clear();
            Bedroom();
          }
          LivingRoom();
          break;
        case "s":

          Console.WriteLine();
          Console.WriteLine("You can't leave, the door knob just fell out, you need to look around the house to find another way out.");
          Console.WriteLine();
          LivingRoom();
          break;
        case "w":
          Console.WriteLine();
          Console.WriteLine("You are facing a window.");
          Console.WriteLine();
          LivingRoom();
          break;
        case "l":
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine();
          Console.WriteLine("As you look around the room, you notice the room is in bad condition. You see some keys hanging on the wall next to the front door.");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine();
          LivingRoom();
          break;
        case "take screwdriver":
          if (barndoorStuck == false)
          {
            Console.WriteLine();
            System.Console.WriteLine("You don't need that screwdriver anymore.");
          }
          else if (doorLocked == true)
          {
            Console.WriteLine();
            System.Console.WriteLine("There isn't a screwdriver in here.");
          }
          else if (keysUsed == false)
          {
            Console.WriteLine();
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
            Console.WriteLine();
            System.Console.WriteLine("You don't need those keys.");
          }
          else
          {
            if (CurrentPlayer.Inventory.Count > 0)
            {
              Console.WriteLine();
              Console.WriteLine("You already have something in your hands.");
              Console.WriteLine();
              LivingRoom();
            }
            else
            {
              Item keys = new Item("Keys");
              keys.Take();
              Console.WriteLine();
              Console.WriteLine("You now have keys in your hand.");
              CurrentPlayer.Inventory.Add(keys);
              Console.WriteLine();
              LivingRoom();
            }
          }
          break;

        case "use screwdriver":
          if (CurrentPlayer.Inventory.Count > 0 && keysUsed == true)
          {
            barndoorStuck = false;
            screwdriverUsed = true;
            CurrentPlayer.Inventory.RemoveAt(0);
            Console.WriteLine();
            Console.WriteLine("You used the screwdriver to open the barn door. You put the screwdriver next to the the keys.");
          }
          else
          {
            Console.WriteLine();
            Console.Write("You don't have a screwdriver.");
          }
          Console.WriteLine();
          LivingRoom();
          break;
        case "use keys":
          if (CurrentPlayer.Inventory.Count > 0 && screwdriverUsed == false)
          {
            doorLocked = false;
            keysUsed = true;
            CurrentPlayer.Inventory.RemoveAt(0);
            Console.WriteLine();
            Console.WriteLine("You used the keys to open the door, you have put them back.");
          }
          else
          {
            Console.WriteLine();
            Console.Write("You don't have a key.");
          }
          Console.WriteLine();
          LivingRoom();
          break;
        case "take":
          Console.WriteLine();
          Console.WriteLine("What do you want to take?");
          Console.WriteLine();
          LivingRoom();
          break;
        case "use":
          Console.WriteLine();
          Console.WriteLine("What do you want to use?");
          Console.WriteLine();
          LivingRoom();
          break;
        case "i":
          if (CurrentPlayer.Inventory.Count == 0)
          {
            Console.WriteLine();
            Console.WriteLine("You have nothing in your hands");
          }
          else
          {
            Console.WriteLine();
            Console.WriteLine("You are holding " + CurrentPlayer.Inventory[0].Name + " in your hands.");
          }
          Console.WriteLine();
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
          Console.Clear();
          LivingRoom();
          break;
        case "q":
          Quit();
          break;
        case "r":
          if (CurrentPlayer.Inventory.Count > 0)
          {
            CurrentPlayer.Inventory.RemoveAt(0);
            System.Console.WriteLine("Reset");
          }
          else
          {
            System.Console.WriteLine("Reset");
          }
          doorLocked = true;
          barndoorStuck = true;
          keysUsed = false;
          Start();
          break;
        default:
          LivingRoom();
          break;
      }
    }
    public void Bedroom()
    {
      Console.ForegroundColor = ConsoleColor.DarkGray;
      Console.WriteLine("Master Bedroom");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine();
      Console.WriteLine("You are in the master bedroom. This room is full of construction materials and its hard to move around. ");
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      string input2 = Console.ReadLine().ToLower();
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Cyan;
      switch (input2)
      {
        case "n":
          Console.Clear();
          Bathroom();
          break;
        case "w":
          Console.Clear();
          LivingRoom();
          break;
        case "s":
          Console.WriteLine();
          Console.WriteLine("You are facing a window. The window blinds are currently closed.");
          Console.WriteLine();
          Bedroom();
          break;
        case "e":
          Console.WriteLine();
          Console.WriteLine("You are facing a wall that has a bunch of building supplies leaning agaist it.");
          Console.WriteLine();
          Bedroom();
          break;
        case "l":
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine();
          Console.WriteLine("To the north you see a door possibly to a bathroom. The south wall has a window. The west wall has a bunch of sheetrock leaning agaist it.");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine();
          Bedroom();
          break;
        case "take":
          Console.WriteLine();
          Console.WriteLine("What do you want to take?");
          Console.WriteLine();
          Bedroom();
          break;
        case "use screwdriver":
          Console.WriteLine();
          Console.WriteLine("You can't fix anything in here.");
          Console.WriteLine();
          Bedroom();
          break;
        case "use":
          Console.WriteLine();
          Console.WriteLine("What do you want to use?");
          Console.WriteLine();
          Bedroom();
          break;
        case "i":
          if (CurrentPlayer.Inventory.Count == 0)
          {
            Console.WriteLine();
            Console.WriteLine("You have nothing in your hands");
            Console.WriteLine();
          }
          else
          {
            Console.WriteLine();
            Console.WriteLine("You are holding a screwdriver " + CurrentPlayer.Inventory[0].Name + " in your hands.");
            Console.WriteLine();
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
          Console.Clear();
          Bedroom();
          break;
        case "q":
          Quit();
          break;
        case "r":
          if (CurrentPlayer.Inventory.Count > 0)
          {
            CurrentPlayer.Inventory.RemoveAt(0);
            System.Console.WriteLine("Reset");
          }
          else
          {
            System.Console.WriteLine("Reset");
          }
          doorLocked = true;
          barndoorStuck = true;
          keysUsed = false;
          Start();
          break;
        default:
          Bedroom();
          break;
      }
    }
    public void Bathroom()
    {
      Console.ForegroundColor = ConsoleColor.DarkGray;
      Console.WriteLine("Bathroom");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine();
      Console.WriteLine("You are in a bathroom. The tub is missing and there is random plumbing pipes coming out of the wall. There is missing sheetrock on the walls and some bare studs. The vanity sink is dirty like it hasnt been used much.");
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      string input3 = Console.ReadLine().ToLower();
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Cyan;
      switch (input3)
      {
        case "n":
          Console.WriteLine();
          Console.WriteLine("You are facing the vanity cabinet.");
          Console.WriteLine();
          Bathroom();
          break;
        case "e":
          Console.WriteLine();
          Console.WriteLine("You are facing a toilet.");
          Console.WriteLine();
          Bathroom();
          break;
        case "s":
          Console.Clear();
          Bedroom();
          break;
        case "w":
          Console.WriteLine();
          Console.ForegroundColor = ConsoleColor.DarkRed;
          Console.WriteLine("You fell into a hole where the tub was, you broke your neck.");
          Console.WriteLine();
          Console.BackgroundColor = ConsoleColor.White;
          Console.WriteLine("You LOSE!!!");
          Console.BackgroundColor = ConsoleColor.Black;
          Console.WriteLine();
          Win();
          break;
        case "l":
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine();
          Console.WriteLine("To the north you see a vanity cabinet and sink, on top of the sink is a screwdriver. The east wall has a crummy looking toilet. The west wall is where a tub used to be and there is a big hole in the floor, you can see down into the basement.");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine();
          Bathroom();
          break;
        case "take screwdriver":
          if (CurrentPlayer.Inventory.Count > 0)
          {
            Console.WriteLine();
            Console.WriteLine("You already have something in your hands.");
            Console.WriteLine();
            Bathroom();
          }
          else
          {
            Item screwdriver = new Item("screwdriver");
            screwdriver.Take();
            Console.WriteLine();
            Console.WriteLine("You now have a screwdriver in your hand.");
            CurrentPlayer.Inventory.Add(screwdriver);
            Console.WriteLine();
            Bathroom();
          }
          break;
        case "use screwdriver":
          Console.WriteLine();
          Console.WriteLine("You can't fix anything in here.");
          Console.WriteLine();
          Bathroom();
          break;
        case "take":
          Console.WriteLine();
          Console.WriteLine("What do you want to take?");
          Console.WriteLine();
          Bathroom();
          break;
        case "use":
          Console.WriteLine();
          Console.WriteLine("What do you want to use?");
          Console.WriteLine();
          Bathroom();
          break;
        case "i":
          if (CurrentPlayer.Inventory.Count == 0)
          {
            Console.WriteLine();
            Console.WriteLine("You have nothing in your hands");
          }
          else
          {
            Console.WriteLine();
            Console.WriteLine("You are holding " + CurrentPlayer.Inventory[0].Name + " in your hands.");
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
          Console.Clear();
          Bathroom();
          break;

        case "q":
          Quit();
          break;
        case "r":
          if (CurrentPlayer.Inventory.Count > 0)
          {
            CurrentPlayer.Inventory.RemoveAt(0);
            System.Console.WriteLine("Reset");
          }
          else
          {
            System.Console.WriteLine("Reset");
          }
          doorLocked = true;
          barndoorStuck = true;
          keysUsed = false;
          Start();
          break;
        default:
          Bathroom();
          break;
      }
    }
    public void Kitchen()
    {
      Console.ForegroundColor = ConsoleColor.DarkGray;
      Console.WriteLine("Kitchen");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine();
      Console.WriteLine("You are standing at the entrance to the kitchen. It looks to be brand new. You think to your self, maybe i can get through here without having to fix something.");
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      string input4 = Console.ReadLine().ToLower();
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.Cyan;
      switch (input4)
      {
        case "n":
          Console.ForegroundColor = ConsoleColor.DarkRed;
          Console.WriteLine("Hey man you made it, sorry I didn't get back to you but did you get a chance to take a look around? I know my place needs a lot of work, huh? I can't wait to show you the basement!");
          Console.WriteLine();
          Console.BackgroundColor = ConsoleColor.White;
          Console.WriteLine("You WIN!!!");
          Console.BackgroundColor = ConsoleColor.Black;
          Console.WriteLine();
          Win();
          break;
        case "e":
          Console.WriteLine();
          Console.WriteLine("You are facing countertops and range.");
          Console.WriteLine();
          Kitchen();
          break;
        case "s":
          Console.Clear();
          LivingRoom();
          break;
        case "w":
          Console.WriteLine();
          Console.WriteLine("You are facing a refrigerator.");
          Console.WriteLine();
          Kitchen();
          break;
        case "l":
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine();
          Console.WriteLine("You look around and see a newly remodeled kitchen. Wow its beautiful, there are granite countertop, new appliances and white cabinets. You can see a door on the north side of the kitchen.");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine();
          Kitchen();
          break;

        case "take":
          Console.WriteLine();
          Console.WriteLine("What do you want to take?");
          Console.WriteLine();
          Kitchen();
          break;
        case "use":
          Console.WriteLine();
          Console.WriteLine("What do you want to use?");
          Console.WriteLine();
          Kitchen();
          break;
        case "i":
          if (CurrentPlayer.Inventory.Count == 0)
          {
            Console.WriteLine();
            Console.WriteLine("You have nothing in your hands");
          }
          else
          {
            Console.WriteLine();
            Console.WriteLine("You are holding " + CurrentPlayer.Inventory[0].Name + " in your hands.");
          }
          Console.WriteLine();
          Kitchen();
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
          Console.Clear();
          Kitchen();
          break;

        case "q":
          Quit();
          break;
        case "r":
          if (CurrentPlayer.Inventory.Count > 0)
          {
            CurrentPlayer.Inventory.RemoveAt(0);
            System.Console.WriteLine("Reset");
          }
          else
          {
            System.Console.WriteLine("Reset");
          }
          doorLocked = true;
          barndoorStuck = true;
          keysUsed = false;
          Start();
          break;
        default:
          Kitchen();
          break;
      }
    }

    public void Reset()
    {
      throw new NotImplementedException();
    }
  }


}
