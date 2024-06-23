namespace Rml.CoNexus.Core.CnxElicitation;

public class TopicList : List<Topic>
{
    public TopicList() { }

    public TopicList(IEnumerable<Topic> ts) => AddRange(ts);

    public Topic? Fetch(int id) => Find(x => x.Id == id);
}

