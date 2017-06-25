using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace WPFUtils.ExtensionMethods
{
    public static class DependencyObjectExtensionMethods
    {
        public static IEnumerable<DependencyObject> GetChildren<T>(this DependencyObject parent) where T : DependencyObject
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in GetChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static IEnumerable<T> GetVisualChildren<T>(this Visual parent) where T : Visual
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i) as Visual;

                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in GetVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static T GetVisualChild<T>(this Visual parent) where T : Visual
        {
            Visual child = null;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                child = VisualTreeHelper.GetChild(parent, i) as Visual;

                if (child != null && (child.GetType() == typeof(T)))
                {
                    break;
                }

                else if (child != null)
                {
                    child = GetVisualChild<T>(child);

                    if (child != null && (child.GetType() == typeof(T)))
                    {
                        break;
                    }
                }
            }
            return child as T;
        }
    }
}
