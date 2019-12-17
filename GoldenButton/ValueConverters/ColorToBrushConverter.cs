using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace GoldenButton.ValueConverters
{

    class ColorToBrushConverter : IValueConverter
    {
        /// <summary>
        /// Returns a drawing brush from a System.Windows.Media.Color type
        /// </summary>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ColorConverterHelpers helper = new ColorConverterHelpers();

            return (new SolidColorBrush(helper.ConvertColorType((System.Drawing.Color)value)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
