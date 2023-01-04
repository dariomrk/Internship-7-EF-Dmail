namespace Internship_7_EF_Dmail.Presentation.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Executes the provided predicate once for each collection element.
        /// </summary>
        /// <typeparam name="T">Contained type in the collection.</typeparam>
        /// <param name="collection">Collection to iterate through.</param>
        /// <param name="predicate">Function that accepts a single item of the collection.</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> predicate) where T : notnull
        {
            foreach (var item in collection)
            {
                predicate(item);
            }
        }
    }
}
