using Xunit;
using System.Collections;
using System.Collections.Generic;

namespace Lncodes.Collecter.Test
{
    public sealed class BitArrayCollectionTheoryData : TheoryData<IEnumerable<bool>, BitArray>
    {
        public BitArrayCollectionTheoryData()
        {
            Add(new bool[] { true, true, true }, new BitArray(3, true));
            Add(new bool[] { true, false, true }, new BitArray(new bool[] { true, false, true }));
        }
    }
}
