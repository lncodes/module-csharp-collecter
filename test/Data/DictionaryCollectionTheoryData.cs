using Xunit;
using System.Collections;
using System.Collections.Generic;

namespace Lncodes.Collecter.Test
{
    public sealed class DictionaryCollectionTheoryData : TheoryData<IDictionary<object, object>, IDictionary>
    {
        public DictionaryCollectionTheoryData()
        {
            Add(new Dictionary<object, object> { { "a", "b" }, { "1", "2" }, { "1.1", "2.2" } }, new SortedList { { "a", "b" }, { "1", "2" }, { "1.1", "2.2" } });
            Add(new Dictionary<object, object> { { "1", "1.1" }, { 2, 2.2f }, { 3f, 3.3d } }, new Dictionary<int, float> { { 1, 1.1f }, { 2, 2.2f }, { 3, 3.3f } });
        }
    }
}
