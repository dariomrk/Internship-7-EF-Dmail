namespace Internship_7_EF_Dmail.Presentation.Extensions
{
    public static class IListExtension
    {
        /// <summary>
        /// Executes the provided predicate once for each collection element.
        /// </summary>
        /// <typeparam name="T">Contained type in the collection.</typeparam>
        /// <param name="collection">Collection to iterate through.</param>
        /// <param name="predicate">Function that accepts a single item of the collection and the item index.</param>
        public static void ForEach<T>(this IList<T> collection, Action<T,int> predicate) where T : notnull
        {
            for (int i = 0; i<collection.Count; i++)
            {
                predicate(collection[i], i);
            }
        }
        /// <summary>
        /// Executes the provided predicate once for each collection element.
        /// </summary>
        /// <typeparam name="T">Contained type in the collection.</typeparam>
        /// <param name="collection">Collection to iterate through.</param>
        /// <param name="predicate">Function that accepts a single item of the collection.</param>
        public static void ForEach<T>(this IList<T> collection, Action<T> predicate) where T : notnull
        {
            for (int i = 0; i<collection.Count; i++)
            {
                predicate(collection[i]);
            }
        }
    }
}
