using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenButton.ValueConverters
{
    public class ColorConverterHelpers
    {
        /// <summary>
        /// Converts a System.Drawing.Color color to a System.Windows.Media.Color
        /// </summary>
        /// <param name="color">The System.Drawing.Color to be converted</param>
        /// <returns></returns>
        public System.Windows.Media.Color ConvertColorType(System.Drawing.Color color)
        {
            byte AVal = color.A;
            byte RVal = color.R;
            byte GVal = color.G;
            byte BVal = color.B;

            return System.Windows.Media.Color.FromArgb(AVal, RVal, GVal, BVal);
        }
    }
}
