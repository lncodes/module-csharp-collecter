using System;
using System.Collections;
using System.Collections.Generic;

namespace Lncodes.Module.Collecter
{
    internal sealed class KeyValuePairCollcetionConverter
    {
        /// <summary>
        /// Method to convert dictionary collection
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="data"></param>
        /// <param name="targetCollectionType"></param>
        /// <returns cref=object></returns>
        internal object ConvertDictionaryCollection<TKey, TValue>(IDictionary<TKey, TValue> data, Type targetCollectionType)
        {
            CheckTargetCollectionType(targetCollectionType);
            var valueType = GetCollectionValueTypes(targetCollectionType);
            var newDictionary = (IDictionary)Activator.CreateInstance(targetCollectionType);
            foreach (var item in data)
                newDictionary.Add(Convert.ChangeType(item.Key, valueType[0]), Convert.ChangeType(item.Value, valueType[1]));
            return Activator.CreateInstance(targetCollectionType, newDictionary);
        }

        /// <summary>
        /// Method to get collection value types
        /// </summary>
        /// <param name="targetCollectionType"></param>
        /// <returns cref=Type[]></returns>
        private Type[] GetCollectionValueTypes(Type targetCollectionType)
        {
            if (targetCollectionType.IsGenericType)
                return targetCollectionType.GetGenericArguments();
            return new[] { typeof(object), typeof(object) };
        }

        /// <summary>
        /// Method to check target collection type
        /// </summary>
        /// <param name="targetCollectionType"></param>
        private void CheckTargetCollectionType(Type targetCollectionType)
        {
            if (targetCollectionType.GetInterface(nameof(IDictionary)) is null)
                throw new NotSupportedException("Can only convert key-value pair types");
        }
    }
}
