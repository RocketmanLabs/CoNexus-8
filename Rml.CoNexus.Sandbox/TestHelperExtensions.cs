using Rml.CoNexus.Core;
using Rml.CoNexus.Core.CnxElicitation;
using Rml.CoNexus.Core.CnxEvaluation;
using Rml.CoNexus.Core.CnxParticipation;
using Group = Rml.CoNexus.Core.Group;

namespace Rml.CoNexus.Sandbox;


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

    public static Scale BuildImportanceScale() => new Scale(
        [
            new ScaleEntry(ConsoleKey.NumPad9, false, 3, "3 points = More important"),
            new ScaleEntry(ConsoleKey.NumPad8, false, 2, "2 points = Important"),
            new ScaleEntry(ConsoleKey.NumPad7, false, 1, "1 point = Important"),
            new ScaleEntry(isPlaceholder: true),
            new ScaleEntry(ConsoleKey.NumPad3, false, 1, "1 point = Important"),
            new ScaleEntry(ConsoleKey.NumPad8, false, 2, "2 points = Important"),
            new ScaleEntry(ConsoleKey.NumPad9, false, 3, "3 points = More important")
        ]
    );


    public static Scale BuildContributionScale() => new Scale(
        [
            new ScaleEntry(ConsoleKey.NumPad6, false, 6, "6 = Practically perfect"),
            new ScaleEntry(ConsoleKey.NumPad5, false, 5, "5 = Good"),
            new ScaleEntry(ConsoleKey.NumPad4, false, 4, "4 = Slightly better than average"),
            new ScaleEntry(ConsoleKey.NumPad3, false, 3, "3 point = Slightly worse than average"),
            new ScaleEntry(ConsoleKey.NumPad2, false, 2, "2 points = Poor"),
            new ScaleEntry(ConsoleKey.NumPad1, false, 1, "1 point = None, or almost none")
        ]
    );

    public static Axes BuildTestAxes(this Inquiry inq)
    {
        Axis weights = new Axis(
            seq: 1,
            name: "Prioritize entries",
            descr: null,
            label: "Importance",
            question: "Having both, which was most important and by how much?",
            assn: AxisType.WEIGHTS,
            method: VoteMethod.PAIRS,
            scale: BuildImportanceScale()
        );

        Axis contribution = new Axis(
            seq: 2,
            name: "Evaluate current performance",
            descr: null,
            label: "Performance",
            question: "How well is this performed today?",
            assn: AxisType.CONTRIBUTIONS,
            method: VoteMethod.CONTRIBUTION,
            scale: BuildContributionScale()
        );

        DemographicQuestion dq1 = new DemographicQuestion(
            seq: 3,
            name: "Department",
            question: "How satisfied are you today?",
            scale: BuildContributionScale()
        );
        return new Axes([weights, contribution, dq1]);
    }

    /// <summary>
    /// Implements a common demo Profile based on Maslow's triangle (use in individualistic societies).
    ///     Transcendence - skipped
    ///     Self-actualization
    ///     Aesthetic
    ///     Cognitive
    ///     (deficiency need) Esteem
    ///     (deficiency need) Love & Belonging
    ///     (deficiency need) Safety
    ///     (deficiency need) Physiological - skipped
    /// Aristotle's definition of happiness (via Norman Lear): "The exercise of one's vital abilities in a life that affords them scope"
    /// </summary>
    /// <param name="inq"></param>
    /// <returns></returns>
    public static TopicList BuildMaslowTopicList(this Inquiry inq)
    {
        TopicList criteria = new TopicList(
            [
                 new Topic("Personal/family safety", "1", null),
                 new Topic("Physical health", "2", null),
                 new Topic("Family", "3", null),
                 new Topic("Friends", "4", null),
                 new Topic("Respect", "5", null),
                 new Topic("Trust", "6", null),
                 new Topic("Learning", "7", null),
                 new Topic("Self-expression", "8", null),
                 new Topic("Natural beauty", "9", null),
                 new Topic("Appearance/fitness", "10", null),
                 new Topic("Knowledge of self", "11", null),
                 new Topic("Creative self-expression", "12", null),
            ]
        );
        return criteria;
    }
}
