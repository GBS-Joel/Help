using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Help.Library
{
  public static class WPFHelper
  {
    public static T FindAncestor<T>(this FrameworkElement start) where T : FrameworkElement
    {
      if (start == null) return null;
      FrameworkElement current = start;
      T found = null;
      FrameworkElement parent = current.Parent as FrameworkElement;
      if (parent == null) parent = current.TemplatedParent as FrameworkElement;
      while (found == null && current != null && parent != null)
      {
        current = parent;
        found = current as T;
        parent = current.Parent as FrameworkElement;
        if (parent == null) parent = current.TemplatedParent as FrameworkElement;
      }
      return found;
    }

    public static T FindLogicalAncestor<T>(FrameworkElement start) where T : FrameworkElement
    {
      if (start == null) return null;
      FrameworkElement current = start;
      T found = null;
      FrameworkElement parent = LogicalTreeHelper.GetParent(current) as FrameworkElement;
      while (found == null && current != null && parent != null)
      {
        current = parent;
        found = current as T;
        parent = LogicalTreeHelper.GetParent(current) as FrameworkElement;
      }
      return found;
    }

    public static FrameworkElement FindAncestor(this FrameworkElement start, Predicate<FrameworkElement> predicate)
    {
      if (start == null) return null;

      FrameworkElement current = start;
      FrameworkElement found = null;

      FrameworkElement parent = current.Parent as FrameworkElement;
      if (parent == null) parent = current.TemplatedParent as FrameworkElement;
      if (parent == null) parent = VisualTreeHelper.GetParent(current) as FrameworkElement;

      while (found == null && current != null && parent != null)
      {
        current = parent;
        if (predicate(current))
          found = current;
        parent = current.Parent as FrameworkElement;
        if (parent == null) parent = current.TemplatedParent as FrameworkElement;
        if (parent == null) parent = VisualTreeHelper.GetParent(current) as FrameworkElement;
      }
      return found;
    }

    public static FrameworkElement FindParent(this FrameworkElement start)
    {
      return FindAncestor(start, x => x != start);
    }

    public static T FindFirstChild<T>(UIElement currentElement) where T : FrameworkElement
    {
      foreach (object o in LogicalTreeHelper.GetChildren(currentElement))
      {
        UIElement elem = o as UIElement;
        if (elem == null) continue;

        T result = elem as T;
        if (result != null) return result;

        result = FindFirstChild<T>(elem);
        if (result != null) return result;
      }
      return null;
    }

    public static T FindFirstChild<T>(UIElement currentElement, Predicate<T> predicate) where T : FrameworkElement
    {
      foreach (UIElement childElement in LogicalTreeHelper.GetChildren(currentElement).OfType<UIElement>())
      {
        T result = childElement as T;
        if (result != null && predicate(result))
        {
          return result;
        }

        result = FindFirstChild<T>(childElement, predicate);
        if (result != null)
        {
          return result;
        }
      }
      return null;
    }

    public static T FindLogicalChildByName<T>(UIElement currentElement, string name) where T : FrameworkElement
    {
      object o = LogicalTreeHelper.FindLogicalNode(currentElement, name);

      UIElement elem = o as UIElement;
      if (elem == null)
        return null;
      else
        return elem as T;
    }

    public static IEnumerable<T> FindChildren<T>(UIElement currentElement) where T : FrameworkElement
    {
      if (currentElement != null)
      {
        var childs = GetChildObjects(currentElement);

        foreach (UIElement child in childs)
        {
          if (child != null && child is T)
          {
            yield return (T)child;
          }
          foreach (T descendant in FindChildren<T>(child))
          {
            yield return descendant;
          }
        }
      }
    }

    public static IEnumerable<UIElement> GetChildObjects(this UIElement parent)
    {
      if (parent == null) yield break;

      foreach (object obj in LogicalTreeHelper.GetChildren(parent))
      {
        if (obj is UIElement) yield return (UIElement)obj;
      }
    }

    public static PropertyInfo[ ] GetPropertyInfos(object info)
    {
      if (info != null)
        return info.GetType().GetProperties();
      else
        return null;
    }
  }
}