using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GoldenButton.Utilities
{
    /// <summary>
    /// Climb up the visual tree to retrieve until we reach the a specified dependen object
    /// USAGE: var gbview = VisualTreeHelperExtensions.FindAncestor<GoldenButton.Views.GBView>(button);
    /// </summary>
    public static class VisualTreeHelperExtensions
    {
        public static T FindAncestor<T>(DependencyObject dependencyObject)
            where T : class
        {
            DependencyObject target = dependencyObject;

            while (target != null && !(target is T))
            {
                target = VisualTreeHelper.GetParent(target);
            }

            return target as T;
        }
    }
}
