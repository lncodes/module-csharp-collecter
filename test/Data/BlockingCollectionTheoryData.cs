using Xunit;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Lncodes.Collecter.Test
{
    public sealed class BlockingCollectionTheoryData : TheoryData<IEnumerable<object>, BlockingCollection<float>>
    {
        public BlockingCollectionTheoryData()
        {
            Add(new object[] { 1, 2, 3 }, new BlockingCollection<float> { 1, 2, 3 });
            Add(new object[] { "1.1", "2.2", "3.3" }, new BlockingCollection<float> { 1.1f, 2.2f, 3.3f });
        }
    }
}
