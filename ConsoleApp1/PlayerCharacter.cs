using System;

namespace ConsoleApp1
{
  public class PlayerCharacter
  {
    private readonly Combo _combo;
    private HorizontalDirection _direction = HorizontalDirection.Right;

    public PlayerCharacter(Combo combo)
    {
      _combo = combo;
    }

    private bool IsInAir
    {
      get;
      set;
    }

    public void Attack(HorizontalDirection direction)
    {
      var originalDirection = _direction;
      Look(direction);
      Console.WriteLine("I did an attack.");
      var comboDirection = originalDirection == direction ? ComboDirection.Forward : ComboDirection.Back;
      _combo.Advance(comboDirection);
    }

    private void Look(HorizontalDirection direction)
    {
      Console.WriteLine($"I looked to my {direction}.");
      _direction = direction;
    }

    public void Jump()
    {
      if (_combo.IsActive)
      {
        _combo.Advance(ComboDirection.Up);
      }
      else
      {
        IsInAir = true;
        Console.WriteLine("I jumped.");
      }
    }

    public void Land()
    {
      if (_combo.IsActive)
      {
        _combo.Advance(ComboDirection.Down);
      }
      else
      {
        IsInAir = false;
        Console.WriteLine("I landed.");
      }
    }
    
  }
}