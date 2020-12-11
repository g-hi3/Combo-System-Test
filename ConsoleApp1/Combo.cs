using System;
using System.Text;

namespace ConsoleApp1
{
  public class Combo
  {
    private readonly ComboGenerator _generator;
    private ComboItem _nextItem = NullItem;

    public Combo(ComboGenerator generator)
    {
      _generator = generator;
    }

    public bool IsActive => _nextItem != NullItem;
    
    private static ComboItem NullItem => ComboItem.NullItem;

    public void Advance(ComboDirection direction)
    {
      if (!IsActive)
      {
        StartCombo();
      }
      else
      {
        _nextItem = _nextItem.Next(direction);
        Console.WriteLine(IsActive ? "Combo advanced." : "Combo finished.");
      }
    }

    private void StartCombo()
    {
      _nextItem = _generator.Generate();
    }

    // Call this after some inactivity.
    public void SetInactive()
    {
      _nextItem = NullItem;
    }

    public override string ToString()
    {
      var strBuilder = new StringBuilder();
      var topFirstItem = GetFirstTopItem(out var topSize);
      PrintRow(topSize, topFirstItem, strBuilder);
      PrintRow(0, _nextItem, strBuilder);
      var bottomFirstItem = GetFirstBottomItem(out var bottomSize);
      PrintRow(bottomSize, bottomFirstItem, strBuilder);
      return strBuilder.ToString();
    }

    private ComboItem GetFirstTopItem(out int size)
    {
      size = 0;
      var comboItem = _nextItem;
      do
      {
        if (comboItem.Up != NullItem)
          return comboItem.Up;
        comboItem = comboItem.Forward;
        size++;
      } while (comboItem != NullItem);

      size = 0;
      return NullItem;
    }

    private ComboItem GetFirstBottomItem(out int size)
    {
      size = 0;
      var comboItem = _nextItem;
      do
      {
        if (comboItem.Down != NullItem)
          return comboItem.Down;
        comboItem = comboItem.Forward;
        size++;
      } while (comboItem != NullItem);

      size = 0;
      return NullItem;
    }

    private void PrintRow(int size, ComboItem firstItem, StringBuilder strBuilder)
    {
      if (firstItem == null)
        return;
      for (var i = 0; i < size; i++)
      {
        strBuilder.Append("     ");
        if (i < size)
        {
          strBuilder.Append("   ");
        }
      }
      for (var item = firstItem; item != NullItem; item = item.Forward)
      {
        strBuilder.Append(item);
        if (item.Forward != NullItem)
        {
          strBuilder.Append(" - ");
        }
      }
      strBuilder.Append(Environment.NewLine);
    }
  }
}