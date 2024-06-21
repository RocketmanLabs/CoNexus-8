using Rml.CoNexus.Core;
using Group = Rml.CoNexus.Core.Group;

namespace Rml.CoNexus.UnitTests;

public static class TestHelperExtensions
{
    public static Group BuildTestGroup(this Inquiry inq)
    {
        Participant p1 = new Participant("James Kirk", false);
        Participant p2 = new Participant("Christopher Pike", true);
        Participant p3 = new Participant("Benjamin Sisko", false);
        Participant p4 = new Participant("Katherine Janeway", false);
        Group grp = new Group([p1, p2, p3, p4]);
        inq.People = grp;
        return grp;
    }
    
    public static Axes BuildTestAxes(this Inquiry inq)
    {
        Axis weights = new Axis(
            name: "Prioritize entries",
            sequence: 1,
            question: "Having both, which was most important and by how much?",
            assigned: AxisAssignment.WEIGHTS,
            method: VoteMethod.PAIRS,
            scale: new Scale(
                [
                    new ScaleEntry(ConsoleKey.NumPad9, false, 3, "3 points = More important"),
                    new ScaleEntry(ConsoleKey.NumPad8, false, 2, "2 points = Important"),
                    new ScaleEntry(ConsoleKey.NumPad7, false, 1, "1 point = Important"),
                    new ScaleEntry(isPlaceholder: true),
                    new ScaleEntry(ConsoleKey.NumPad3, false, 1, "1 point = Important"),
                    new ScaleEntry(ConsoleKey.NumPad8, false, 2, "2 points = Important"),
                    new ScaleEntry(ConsoleKey.NumPad9, false, 3, "3 points = More important")
                ]
            )
        );

        Axis contribution = new Axis(
            name: "Evaluate current performance",
            sequence: 2,
            question: "Rate how this is performed today",
            assigned: AxisAssignment.CONTRIBUTIONS,
            method: VoteMethod.RATE,
            scale: new Scale(
                [
                    new ScaleEntry(ConsoleKey.NumPad6, false, 6, "6 = Practically perfect"),
                    new ScaleEntry(ConsoleKey.NumPad5, false, 5, "5 = Good"),
                    new ScaleEntry(ConsoleKey.NumPad4, false, 4, "4 = Slightly better than average"),
                    new ScaleEntry(ConsoleKey.NumPad3, false, 3, "3 point = Slightly worse than average"),
                    new ScaleEntry(ConsoleKey.NumPad2, false, 2, "2 points = Poor"),
                    new ScaleEntry(ConsoleKey.NumPad1, false, 1, "1 point = None, or almost none")
                ]
            )
        );

        Axes axes = new Axes([weights, contribution]);
        return axes;
    }
}
