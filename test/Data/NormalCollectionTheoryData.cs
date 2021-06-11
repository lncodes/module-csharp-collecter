using Xunit;
using System.Collections;
using System.Collections.Generic;

namespace Lncodes.Collecter.Test
{
    public sealed class NormalCollectionTheoryData : TheoryData<IEnumerable<object>, IEnumerable>
    {
        public NormalCollectionTheoryData()
        {
            Add(new object[] { 1, 2, 3 }, new List<int> { 1, 2, 3 });
            Add(new object[] { 1.1, 1.2, 1.3 }, new List<float> { 1.1f, 1.2f, 1.3f });
            Add(new object[] { "a", "b", "c" }, new ArrayList { "a", "b", "c" });
        }
    }
}
