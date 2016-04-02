using System.Linq;

namespace MyLibrary.CustomCollections.ExtensionMethods
{
    public static class CircularListExtensionMethods
    {
        public static CircularList<T> ToCircularList<T>(this IOrderedEnumerable<T> value)
        {
            var circularList = new CircularList<T>(value.Count());
            foreach (var val in value)
            {
                circularList.Add(val);
            }
            return circularList;
        }

        public static void Initialize<T>(this CircularList<T> value)
        {
            if (value.Any())
            {
                value.CurrentItem = value[0];
            }
        }
    }
}
