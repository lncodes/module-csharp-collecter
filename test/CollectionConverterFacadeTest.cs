using Xunit;
using Lncodes.Module.Collecter;

using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Lncodes.Collecter.Test
{
    public sealed class CollectionConverterFacadeTest
    {
        [Theory]
        [ClassData(typeof(NormalCollectionTheoryData))]
        public void Convert_Reguler_AreEqual(IEnumerable<object> input, IEnumerable expected)
        {
            var collectionConverter = GetCollectionConverterFacade();

            var actual = collectionConverter.ConvertRegulerCollection(input, expected.GetType());

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(DictionaryCollectionTheoryData))]
        public void Convert_Dictionary_AreEqual(IDictionary<object, object> input, IDictionary expected)
        {
            var collectionConverter = GetCollectionConverterFacade();

            var actual = collectionConverter.ConvertDictionaryCollection(input, expected.GetType());

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(BitArrayCollectionTheoryData))]
        public void Convert_BitArray_AreEqual(IEnumerable<bool> input, BitArray expected)
        {
            var collectionConverter = GetCollectionConverterFacade();

            var actual = collectionConverter.ConvertBitArrayCollection(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(BlockingCollectionTheoryData))]
        public void Convert_BlockingCollection_AreEqual(IEnumerable<object> input, BlockingCollection<float> expected)
        {
            var collectionConverter = GetCollectionConverterFacade();

            var actual = collectionConverter.ConvertBlockingCollection(input, expected.GetType());

            Assert.Equal(expected, actual);
        }

        private CollectionConverterFacade GetCollectionConverterFacade() =>
            new CollectionConverterFacade();
    }
}
