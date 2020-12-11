using System;

namespace ConsoleApp1
{
  public class ComboGenerator
  {
    private static readonly Random Random = new Random();
    
    public int MinRowLength { get; set; }
    
    public int MaxRowLength { get; set; }
    
    public ComboItem Generate()
    {
      var topRow = GenerateRow();
      var midRow = GenerateRow();
      var botRow = GenerateRow();
      ConnectRows(midRow, topRow, botRow);
      return midRow[0];
    }

    private ComboItem[] GenerateRow()
    {
      var rowLength = Random.Next(MinRowLength, MaxRowLength);
      var row = new ComboItem[rowLength];
      var prevItem = ComboItem.NullItem;
      for (var index = rowLength - 1; index >= 0; index--)
      {
        row[index] = new ComboItem(prevItem);
        prevItem = row[index];
      }
      Console.WriteLine($"Row length is {rowLength}");
      return row;
    }

    private void ConnectRows(ComboItem[] midRow, ComboItem[] topRow, ComboItem[] botRow)
    {
      var topConnectionIndex = Random.Next(0, midRow.Length);
      var topConnection = midRow[topConnectionIndex];
      topConnection.Up = topRow[0];
      Console.WriteLine($"Top row connected at {topConnectionIndex}.");
      var botConnectionIndex = Random.Next(0, midRow.Length);
      var botConnection = midRow[botConnectionIndex];
      botConnection.Down = botRow[0];
      Console.WriteLine($"Bottom row connected at {botConnectionIndex}.");
    }
    
  }
}