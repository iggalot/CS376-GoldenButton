using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace GoldenButton.ValueConverters
{
    class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GBRegion item = value as GBRegion;
            return (new SolidColorBrush(item.Piece.GetColor));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
