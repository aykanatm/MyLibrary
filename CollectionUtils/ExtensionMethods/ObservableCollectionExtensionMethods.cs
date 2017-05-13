using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace CollectionUtils.ExtensionMethods
{
    public static class ObservableCollectionExtensionMethods
    {
        private static readonly Random Rng = new Random();

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

        public static ObservableCollection<T> Shuffle<T>(this ObservableCollection<T> input)
        {
            var provider = new RNGCryptoServiceProvider();
            var n = input.Count;
            while (n > 1)
            {
                var box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                var k = (box[0] % n);
                n--;
                var value = input[k];
                input[k] = input[n];
                input[n] = value;
            }

            return input;
        }

        public static ObservableCollection<T> ShuffleFisherYates<T>(this ObservableCollection<T> input)
        {
            var n = input.Count;
            while (n > 1)
            {
                n--;
                var k = Rng.Next(n + 1);
                var value = input[k];
                input[k] = input[n];
                input[n] = value;
            }

            return input;
        }
    }
}
