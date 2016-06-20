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
    }
}
