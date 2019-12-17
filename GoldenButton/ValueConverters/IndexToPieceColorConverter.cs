using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GoldenButton.ValueConverters
{
    class IndexToPieceColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GBRegion region = GameboardViewModel.GameboardModel.GBRegionsList[(int)value];

            if(region != null)
            {
                GBPiece piece = region.Piece;

                switch(piece.PieceType)
                {
                    case (PieceTypes.TYPE_NONE):
                        return GameboardViewModel.GBSquareBackgroundColor;
                        
                    case (PieceTypes.TYPE_GOLDEN):
                        return GameboardViewModel.GBGoldenTileBackgroundColor;
               
                    case (PieceTypes.TYPE_NORMAL):
                        return GameboardViewModel.GBNormalTileBackgroundColor;

                    default:
                        return GameboardViewModel.GBSquareBackgroundColor;
                }       
            } else
            {
                throw new NotImplementedException("IndexToPieceColorConverter received an invalid PieceType in Piece #" + ".");
            }



    

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Invalid request for ConvertBack in PointToCanvasPositionConverter.cs");
        }
    }
}
