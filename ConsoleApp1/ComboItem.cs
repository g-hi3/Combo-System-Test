using System;

namespace ConsoleApp1
{
  public class ComboItem
  {
    public static readonly ComboItem NullItem = new ComboItem();

    public ComboItem(ComboItem forward)
    {
      Forward = forward;
    }

    private ComboItem()
    {
    }

    public ComboItem Forward { get; }

    public ComboItem Up { get; set; } = NullItem;

    public ComboItem Down { get; set; } = NullItem;

    public bool IsFinishItem =>
      Forward == NullItem
      && Up == NullItem
      && Down == NullItem;

    public ComboItem Next(ComboDirection direction)
    {
      switch (direction)
      {
        case ComboDirection.Back: return NullItem;
        case ComboDirection.Forward: return Forward;
        case ComboDirection.Up: return Up;
        case ComboDirection.Down: return Down;
        default: throw new ArgumentException($"Unsupported direction {direction}!");
      }
    }

    public override string ToString()
    {
      return "("
             + (Up != NullItem ? "^" : " ")
             + " "
             + (Down != NullItem ? "v" : " ")
             + ")";
    }
  }
}