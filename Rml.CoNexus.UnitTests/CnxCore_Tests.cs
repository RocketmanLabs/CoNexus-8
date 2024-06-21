using Rml.CoNexus.Core;

namespace Rml.CoNexus.UnitTests
{
    public class CnxCore_Tests
    {
        [Fact]
        public void EntityBase_issues_unique_IDs()
        {
            Topic t1 = new();
            int id = t1.Id;
            Assert.True(id > 0);
            Topic t2 = new();
            Assert.Equal(id + 1, t2.Id);
        }

        [Fact]
        public void Collection_init()
        {
            Participant p1 = new();
            Participant p2 = new();
            Group grp = new([p1, p2]);
            Assert.Equal(2, grp.Count);
        }
    }
}