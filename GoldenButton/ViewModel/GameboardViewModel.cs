
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows;

namespace GoldenButton
{
    public class GameboardViewModel
    {
        #region Public Members
        /// <summary>
        /// The margin surrounding out gameboard
        /// </summary>
        public static Thickness GBMargin { get; set; } = new Thickness(10);

        /// <summary>
        /// The padding amount between the top edge of the gameboard and the edge of the canvas
        /// </summary>
        public static double GBTileTopPadding { get; set; } = (double) 10.0;

        /// <summary>
        /// The padding amount between the left edge of the gameboard and the edge of the canvas
        /// </summary>
        public static double GBTileLeftPadding { get; set; } = GBTileTopPadding;

        /// <summary>
        /// The width of a single gameboard square
        /// </summary>
        public static double GBSquareWidth { get; set; } = 40.0;

        /// <summary>
        /// The height of a single gameboard square
        /// </summary>
        public static double GBSquareHeight { get; set; } = 40.0;

        /// <summary>
        /// The background color of the game squares
        /// </summary>
        public static Color GBSquareBackgroundColor { get; } = Color.LightCyan;

        /// <summary>
        /// The border color of each game square
        /// </summary>
        public static Color GBSquareBorderColor { get; } = Color.Black;

        /// <summary>
        /// The thickness of the border around a game square
        /// </summary>
        public static double GBSquareBorderThickness { get; } = (double)GBSquareWidth / 20.0;

        /// <summary>
        /// The diameter of the game piece, set to 80% of the gamesquare dimensions
        /// </summary>
        public static double GBTileDiameter { get; set; } = (double)0.8 * GBSquareHeight;

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

        /// <summary>
        /// The color for when a gamepiece is hovered over
        /// </summary>
        public static Color GBTileHoverColor { get; } = Color.Orange;

        /// <summary>
        /// The gameboard object associated with this viewmodel
        /// </summary>
        public static GBModel GameboardModel { get; set;}

        #endregion

        #region Public Methods

        /// <summary>
        /// Property used to retrieve the color of a gamepiece based on its gamepiece type
        /// </summary>
        public static Color GetGBTileBackgroundColor
        {
            get
            {
                return GBNormalTileBackgroundColor;
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Test command functionality...
        /// </summary>
        public static RelayCommand cmd1;

        #endregion

        #region Default Constructor
        /// <summary>
        /// Defaukl constructor
        /// </summary>
        /// <param name="num">Parameter that indicates the number of squares to create our gameboard</param>
        public GameboardViewModel(GameManager game)
        {
            // Set our gameboard object
            GameboardModel = game.Gameboard;

            // Create our gameboard commands
            var cmd1 = new RelayCommand(o => { MessageBox.Show("Command received and clicked"); }, o=> true);
        }

        #endregion

    }
}
