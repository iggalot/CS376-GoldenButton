using GoldenButton.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenButton.ViewModels
{
    public class GBRegionVM : BaseModel
    {
        private static int index_count = 0;

        /// <summary>
        /// The region associated with this view model
        /// </summary>
        private GBRegion _gbRegion;
        public GBRegion GBRegion
        {
            get => _gbRegion;
            set { OnPropertyChanged(ref _gbRegion, value); }
        }

        /// <summary>
        /// The piece contained in the region of this view model
        /// </summary>
        private GBPieceVM _gbPieceVM;
        public GBPieceVM GBPieceVM
        {
            get => _gbPieceVM;
            set { OnPropertyChanged(ref _gbPieceVM, value); }
        }


        #region Public Properties

        /// <summary>
        /// The width of a single gameboard square
        /// </summary>
        public double GBSquareWidth { get; set; } = 30.0;

        /// <summary>
        /// The height of a single gameboard square
        /// </summary>
        public double GBSquareHeight { get; set; } = 30.0;

        /// <summary>
        /// The background color of the game squares
        /// </summary>
        public Color GBSquareBackgroundColor { get; } = Color.LightCyan;

        /// <summary>
        /// The border color of each game square
        /// </summary>
        public Color GBSquareBorderColor { get; } = Color.Black;

        /// <summary>
        /// The thickness of the border around a game square
        /// </summary>
        public double GBSquareBorderThickness { get; } = 1;

        #endregion

        #region Constructor
        public GBRegionVM(double top_margin)
        {
            // Create our region
            GBRegion = new GBRegion(index_count);

            // Create the associated game piece with this region
            GBPieceVM = new GBPieceVM(GBRegion.Index, GBSquareHeight < GBSquareWidth ? GBSquareHeight : GBSquareWidth);

            //// Add the newly created piece model from the GBPieceVM to the GBRegion
            //GBRegion.Piece = GBPieceVM.GBPiece;

            // Determine the insert coordinates for drawing on the canvas
            LeftCoord = index_count * GBSquareWidth;
            TopCoord = top_margin;

            // increment our counter for the next time.
            index_count++;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// The left canvas insert coordinate for the region shape
        /// </summary>
        public double LeftCoord { get; private set; }

        /// <summary>
        /// The top canvas insert coortdinate for the region shape
        /// </summary>
        public double TopCoord { get; private set; }

        #endregion
    }
}
