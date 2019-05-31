using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GoldenButton.ValueConverters
{
    class PointToCanvasPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String canvasParameter = parameter as string;

            if(canvasParameter == "LEFT")
            {
                GBRegion item = value as GBRegion;
                return item.CenterPoint().X;

            } else if (canvasParameter == "TOP")
            {
                GBRegion item = value as GBRegion;
                return (item.CenterPoint().Y);
            } else
            {
                throw new NotImplementedException("Invalid parameter " + canvasParameter + " passed to PointToCAnvasPositionConverter!");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Invalid request for ConvertBack in PointToCanvasPositionConverter.cs");
        }
    }
}
