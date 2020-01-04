using GoldenButton.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace GoldenButton.ValueConverters
{
    /// <summary>
    /// An IValueConverter for taking a region index number and extracting the color of the piece that is contained within it.
    /// </summary>
    class IndexToPieceColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //GBRegion region = GameboardViewModel.Gameboard.GBRegionsList[(int)value];
            //ColorConverterHelpers helper = new ColorConverterHelpers();

            //if (region != null)
            //{
            //    GBPiece piece = region.Piece;

            //    switch(piece.PieceType)
            //    {
            //        case (PieceTypes.TYPE_NONE):
            //            return new SolidColorBrush(helper.ConvertColorType(GameboardViewModel.GBSquareBackgroundColor));

            //        case (PieceTypes.TYPE_GOLDEN):
            //            return new SolidColorBrush(helper.ConvertColorType(GameboardViewModel.GBGoldenTileBackgroundColor));

            //        case (PieceTypes.TYPE_NORMAL):
            //            return new SolidColorBrush(helper.ConvertColorType(GameboardViewModel.GBNormalTileBackgroundColor));

            //        default:
            //            return new SolidColorBrush(helper.ConvertColorType(GameboardViewModel.GBSquareBackgroundColor));
            //    }       
            //} else
            //{
            //    throw new NotImplementedException("IndexToPieceColorConverter received an invalid PieceType");
            //}
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Invalid request for ConvertBack in PointToCanvasPositionConverter.cs");
        }
    }
}
