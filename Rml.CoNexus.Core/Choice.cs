namespace Rml.CoNexus.Core;

public class Choice : Topic
{
    public Choice() { }

    public Choice(string text, decimal value, ConsoleKey selectionKey)
    {
        Text = text;
        Value = value;
        SelectionKey = selectionKey;
    }

    public decimal Value { get; set; }
    public ConsoleKey SelectionKey { get; set; }
}

