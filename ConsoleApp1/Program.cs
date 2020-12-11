using System;

namespace ConsoleApp1
{
  class Program
  {
    private static readonly PlayerInput PlayerInput = new PlayerInput();
    private static Combo _combo;
    
    static void Main()
    {
      Console.WriteLine("Combo simulator");
      Console.WriteLine("===============");
      MapInput();
      var decision = Decision.None;
      do
      {
        PrintOptions();
        var keyInfo = Console.ReadKey();
        Console.WriteLine();
        switch (keyInfo.Key)
        {
          case ConsoleKey.D0:
          case ConsoleKey.Q:
          case ConsoleKey.Escape:
            decision = Decision.None;
            break;
          case ConsoleKey.D6:
          case ConsoleKey.D: 
          case ConsoleKey.RightArrow:
            decision = Decision.Right;
            break;
          case ConsoleKey.D2:
          case ConsoleKey.S:
          case ConsoleKey.DownArrow:
            decision = Decision.Down;
            break;
          case ConsoleKey.D4:
          case ConsoleKey.A:
          case ConsoleKey.LeftArrow:
            decision = Decision.Left;
            break;
          case ConsoleKey.D8:
          case ConsoleKey.W:
          case ConsoleKey.UpArrow:
            decision = Decision.Up;
            break;
          case ConsoleKey.D5:
          case ConsoleKey.E:
          case ConsoleKey.Enter:
            decision = Decision.PrintTree;
            break;
          default:
            break;
        }

        ExecuteDecision(decision);
      } while (decision != Decision.None);
      Console.WriteLine("======================");
      Console.WriteLine("Thank you for playing!");
      Console.ReadKey();
    }

    static void MapInput()
    {
      var comboGenerator = new ComboGenerator
      {
        MinRowLength = 2,
        MaxRowLength = 5
      };
      _combo = new Combo(comboGenerator);
      var playerCharacter = new PlayerCharacter(_combo);
      PlayerInput.RightKeyPressed += () => playerCharacter.Attack(HorizontalDirection.Right);
      PlayerInput.DownKeyPressed += () => playerCharacter.Land();
      PlayerInput.LeftKeyPressed += () => playerCharacter.Attack(HorizontalDirection.Left);
      PlayerInput.UpKeyPressed += () => playerCharacter.Jump();
    }

    static void PrintOptions()
    {
      Console.WriteLine("Pick a decision:");
      Console.WriteLine(" 6|D: Right");
      Console.WriteLine(" 2|S: Down");
      Console.WriteLine(" 4|A: Left");
      Console.WriteLine(" 8|W: Up");
      Console.WriteLine(" 5|E: Print Combo");
      Console.WriteLine(" 0|Q: Quit");
    }

    static void ExecuteDecision(Decision decision)
    {
      if (decision == Decision.None)
        return;
      
      if (decision == Decision.Right)
        PlayerInput.InvokeRightKeyPressedEvent();
      
      if (decision == Decision.Down)
        PlayerInput.InvokeDownKeyPressedEvent();
      
      if (decision == Decision.Left)
        PlayerInput.InvokeLeftKeyPressedEvent();
      
      if (decision == Decision.Up)
        PlayerInput.InvokeUpKeyPressedEvent();
      
      if (decision == Decision.PrintTree)
        Console.WriteLine($"{_combo}");
    }
  }

  enum Decision
  {
    None,
    Up,
    Down,
    Left,
    Right,
    PrintTree
  }
}