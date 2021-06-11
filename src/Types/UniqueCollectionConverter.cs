using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Lncodes.Module.Collecter
{
    internal sealed class UniqueCollectionConverter
    {
        /// <summary>
        /// Method to convert BitArray collection
        /// </summary>
        /// <param name="data"></param>
        /// <returns cref=BitArray></returns>
        internal BitArray ConvertBitArrayCollection(Func<Type, object> createBoolCollection)
        {
            int index = 0;
            var boolCollection = (ICollection)createBoolCollection(typeof(List<bool>));
            var newBitArray = new BitArray(boolCollection.Count);
            foreach (var item in boolCollection) 
                newBitArray.Set(index++, Convert.ToBoolean(item));
            return newBitArray;
        }

        /// <summary>
        /// Method to convert BlockingCollection
        /// </summary>
        /// <param name="createProducerConsumerCollection"></param>
        /// <param name="targetCollectionType"></param>
        /// <returns cref=object></returns>
        internal object ConvertBlockingCollection(Func<Type, object> createProducerConsumerCollection, Type targetCollectionType)
        {
            CheckBlockingTargetCollectionType(targetCollectionType);
            var genericBlockingArgs = targetCollectionType.GetGenericArguments()[0];
            var producerConsumerCollection = createProducerConsumerCollection(typeof(ConcurrentQueue<>).MakeGenericType(genericBlockingArgs));
            return Activator.CreateInstance(typeof(BlockingCollection<>).MakeGenericType(genericBlockingArgs), producerConsumerCollection);
        }

        /// <summary>
        /// Method to check blocking target collection type 
        /// </summary>
        /// <param name="targetCollectionType"></param>
        private void CheckBlockingTargetCollectionType(Type targetCollectionType)
        {
            if (!(targetCollectionType.IsGenericType && targetCollectionType.GetGenericTypeDefinition().Equals(typeof(BlockingCollection<>))))
                throw new NotSupportedException("Can only convert BlockingCollection types");
        }
    }
}
