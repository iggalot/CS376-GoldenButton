using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace GoldenButton
{
    public class AnimationAttachedProperties
    {
        #region ShouldAnimate Attached Property

        /// <summary>
        /// Identifies the ShouldAnunmate attached property.  This enables animation
        /// </summary>
        public static readonly DependencyProperty ShouldAnimateProperty =
            DependencyProperty.RegisterAttached("ShouldAnimate",
                typeof(bool),
                typeof(AnimationAttachedProperties),
                new PropertyMetadata(false, OnShouldAnimateChanged));

        /// <summary>
        /// ShouldAnimate changed handler
        /// </summary>
        /// <param name="d">FrameworkElement that chabnged its ShouldAnimate attached property</param>
        /// <param name="e">DependencyPropertyChangedEventArgs with the new and old value.</param>
        private static void OnShouldAnimateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var source = d as Storyboard;
            if (source != null)
            {
                var value = (bool)e.NewValue;
                if (value)
                {
                    source.Begin();
                } else
                {
                    source.Stop();
                }
            }

        }

        /// <summary>
        /// Gets the value of the ShouldAnimate attached property from the specified FrameworkElement
        /// </summary>
        /// <param name="obj">The specified Framework element</param>
        /// <returns></returns>
        public static bool GetShouldAnimate(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShouldAnimateProperty);
        }

        /// <summary>
        /// Sets the value of the ShouldAnunate attached property rto the specified Framework Element
        /// </summary>
        /// <param name="obj">The object on which to set the ShouldAnuimate attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetShouldAnimate(DependencyObject obj, bool value)
        {
            obj.SetValue(ShouldAnimateProperty, value);
        }
        #endregion
    }
}
