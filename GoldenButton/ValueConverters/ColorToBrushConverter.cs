using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace GoldenButton.ValueConverters
{

    class ColorToBrushConverter : IValueConverter
    {
        /// <summary>
        /// Convertes a System.Drawing.Color color to a System.Windows.Media.Color
        /// </summary>
        /// <param name="color">The System.Drawing.Color to be converted</param>
        /// <returns></returns>
        System.Windows.Media.Color ConvertColorType(System.Drawing.Color color)
        {
            byte AVal = color.A;
            byte RVal = color.R;
            byte GVal = color.G;
            byte BVal = color.B;

            return System.Windows.Media.Color.FromArgb(AVal, RVal, GVal, BVal);
        }

        /// <summary>
        /// Returns a drawing brush from a System.Windows.Media.Color type
        /// </summary>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (new SolidColorBrush(ConvertColorType((System.Drawing.Color)value)));
            //return (new SolidColorBrush((System.Windows.Media.Color)value));


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
