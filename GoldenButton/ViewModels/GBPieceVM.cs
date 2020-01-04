using GoldenButton.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenButton.ViewModels
{
    public class GBPieceVM : BaseModel
    {
        // The piece model associated with this view model
        private GBPiece _gbPiece;

        // Public property for the piece model
        public GBPiece GBPiece
        {
            get => _gbPiece;
            set { OnPropertyChanged(ref _gbPiece, value); }
        }

        /// <summary>
        /// The diameter of the game piece, set to 80% of the gamesquare dimensions
        /// </summary>
        public static double GBTileDiameter { get; set; }

        /// <summary>
        /// The color of a normal gamepiece
        /// </summary>
        public static Color GBNormalTileBackgroundColor { get; } = Color.Blue;

        /// <summary>
        /// The color of the golden button gamepiece
        /// </summary>
        public static Color GBGoldenTileBackgroundColor { get; } = Color.Yellow;

        /// <summary>
        /// The color of the gamepiece border
        /// </summary>
        public static Color GBTileBorderColor { get; } = Color.Black;

        /// <summary>
        /// The thickness of the gamepiece border
        /// </summary>
        public static double GBTileBorderThickness { get; } = (double)GBTileDiameter / 30.0;

        #region Default Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="square_ht">size of the piece</param>
        public GBPieceVM(int index, double size)
        {
            PieceTypes type;
            // create and add a piece to our list of regions
            if (index == 0)
            {
                //RegionPieceType = RegionPieceTypes.REGION_PIECETYPE_GOLDEN;
                type = PieceTypes.TYPE_GOLDEN;
            }
            else if (index < 5)
            {
                //RegionPieceType = RegionPieceTypes.REGION_PIECETYPE_NONE;
                type = PieceTypes.TYPE_NONE;
            }
            else
            {
                //RegionPieceType = RegionPieceTypes.REGION_PIECETYPE_NORMAL;
                type = PieceTypes.TYPE_NORMAL;
            }

            // Create the piece model
            GBPiece = new GBPiece(PieceOwners.OWNER_ALL, type);

            // Set the size of the piece model
            GBTileDiameter = 0.5 * size;
        }
        #endregion

        #region Public Methods

        public Color GetColor 
        {
            get
            {
                if (GBPiece.PieceType == PieceTypes.TYPE_NORMAL)
                {
                    // piece color is blue for normal pieces
                    return Color.FromArgb(255, 0, 0, 255);
                }
                else if (GBPiece.PieceType == PieceTypes.TYPE_GOLDEN)
                {
                    // piece color is gold for the golden button
                    return Color.FromArgb(255, 255, 233, 0);
                }
                else if (GBPiece.PieceType == PieceTypes.TYPE_NONE)
                {
                    // all other "pieces" are white and fully transparent (so that they don't show up)
                    return Color.FromArgb(0, 255, 255, 255);
                }
                else
                {
                    // Return a black color if we have an error
                    return Color.FromArgb(255, 0, 0, 0);
                }
            }
        }
        #endregion
    }




}
