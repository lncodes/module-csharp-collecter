using System;
using System.Collections;
using System.Collections.Generic;

namespace Lncodes.Module.Collecter
{
    public sealed class CollectionConverterFacade
    {
        private readonly UniqueCollectionConverter _uniqueCollectionConverter = new UniqueCollectionConverter();
        private readonly RegulerCollectionConverter _regulerCollectionConverter = new RegulerCollectionConverter();
        private readonly KeyValuePairCollcetionConverter _dictionaryCollectionConverter = new KeyValuePairCollcetionConverter();

        /// <summary>
        /// Function to convert reguler collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="targetCollectionType"></param>
        /// <returns cref=object></returns>
        public object ConvertRegulerCollection<T>(IEnumerable<T> data, Type targetCollectionType) =>
           _regulerCollectionConverter.ConvertCollection(data, targetCollectionType);

        /// <summary>
        /// Method to convert dictionary collection
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="data"></param>
        /// <param name="targetCollectionType"></param>
        /// <returns cref=object></returns>
        public object ConvertDictionaryCollection<TKey, TValue>(IDictionary<TKey, TValue> data, Type targetCollectionType) =>
            _dictionaryCollectionConverter.ConvertDictionaryCollection(data, targetCollectionType);

        /// <summary>
        /// Method to convert to BlockingCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="targetCollectionType"></param>
        /// <returns cref=object></returns>
        public object ConvertBlockingCollection<T>(IEnumerable<T> data, Type targetCollectionType) =>
            _uniqueCollectionConverter.ConvertBlockingCollection((collectionType) => ConvertRegulerCollection(data, collectionType), targetCollectionType);

        /// <summary>
        /// Method to convert to BitArray collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns cref=BitArray></returns>
        public BitArray ConvertBitArrayCollection<T>(IEnumerable<T> data) =>
            _uniqueCollectionConverter.ConvertBitArrayCollection((targetCollectionType) => ConvertRegulerCollection(data, targetCollectionType));
        }
}