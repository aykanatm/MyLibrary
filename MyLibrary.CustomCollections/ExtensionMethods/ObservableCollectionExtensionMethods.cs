using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyLibrary.CustomCollections.ExtensionMethods
{
    public static class ObservableCollectionExtensionMethods
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> input)
        {
            var output = new ObservableCollection<T>();
            foreach (var item in input)
            {
                output.Add(item);
            }

            return output;
        }

        public static T NextItem<T>(this ObservableCollection<T> collection, T currentItem)
        {
            var currentIndex = collection.IndexOf(currentItem);
            if (currentIndex < collection.Count - 1)
            {
                return collection[currentIndex + 1];
            }
            return collection[0];
        }

        public static T PreviousItem<T>(this ObservableCollection<T> collection, T currentItem)
        {
            var currentIndex = collection.IndexOf(currentItem);
            if (currentIndex > 0)
            {
                return collection[currentIndex - 1];
            }
            return collection[collection.Count - 1];
        }
    }
}
