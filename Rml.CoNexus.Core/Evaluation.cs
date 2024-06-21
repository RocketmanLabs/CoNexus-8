namespace Rml.CoNexus.Core;

public class Evaluation
{
    public Evaluation() { }

    public Evaluation(Axis axis, Participant person, Criteria crits, Votes votes)
    {
        Axis = axis;
        Person = person;
        Criteria = crits;
        Votes = votes;
    }

    public Axis Axis { get; set; } = new();
    public Participant Person { get; set; } = new();
    public Criteria Criteria { get; set; } = new();
    public Votes Votes { get; set; } = new();
    public string PctComplete => Votes.Count == 0
        ? "0 % complete"
        : (Votes.VotedCount / Votes.Count * 100).ToString();
}

