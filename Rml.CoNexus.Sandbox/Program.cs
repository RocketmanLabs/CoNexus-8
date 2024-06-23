using Rml.CoNexus.Core;
using Version = Rml.CoNexus.Core.Version;

namespace Rml.CoNexus.Sandbox;

internal class Program
{
    static void Main(string[] args)
    {
        CC.Header("CoNexus 8", Version.AppVersion);

        Inquiry inq = new();
        inq.Title = "Happiness Profile";

        //inq.People = inq.BuildTestGroup();            // participants get entered in REPL
        Group crowd = inq.BuildTestGroup();             // ...but we draw from here
        inq.Axes = inq.BuildTestAxes();                 // WEIGHTS and CONTRIBUTION
        inq.TopicList = inq.BuildMaslowTopicList();      // 12 criteria

        CC.Left("Collections:", CC.ShowAs.PROMPT1);
        CC.WriteLine($"\tPeople - {inq.People.Count} defined");
        CC.WriteLine($"\tAxes   - {inq.Axes.Count} defined");
        CC.WriteLine($"\tTopics - {inq.TopicList.Count} defined");

        CC.Crlf();
        inq.People.Add(crowd[0]);  
        CC.Left("Entered your first person...", CC.ShowAs.PROMPT1);
        CC.WriteLine(crowd[0].Text);

    }
}