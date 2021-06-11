using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Lncodes.Module.Collecter
{
    internal sealed class RegulerCollectionConverter
    {
        /// <summary>
        /// Method to convert an collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="targetCollectionType"></param>
        /// <returns cref=object></returns>
        internal object ConvertCollection<T>(IEnumerable<T> data, Type targetCollectionType)
        {
            var collectionIndex = 0;
            var valueType = GetCollectionValueTypes(targetCollectionType);
            var newCollection = Array.CreateInstance(valueType, data.Count());
            foreach (var item in data)
                newCollection.SetValue(Convert.ChangeType(item, valueType), collectionIndex++);
            if (targetCollectionType.IsArray) return newCollection;
            return Activator.CreateInstance(targetCollectionType, newCollection);
        }

        /// <summary>
        /// Method to get collection value types
        /// </summary>
        /// <param name="targetCollectionType"></param>
        /// <returns cref=Type></returns>
        private Type GetCollectionValueTypes(Type targetCollectionType)
        {
            if (targetCollectionType.IsArray)
                return targetCollectionType.GetElementType();
            if (targetCollectionType.IsGenericType)
                return targetCollectionType.GetGenericArguments()[0];
            return typeof(object);
        }
    }
}
