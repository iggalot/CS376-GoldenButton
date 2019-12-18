
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
        /// The color for when a tile has been selected as part of a move
        /// </summary>
        public static Color GBTileSelected { get; } = GBTileHoverColor;

        /// <summary>
        /// The associated game manager for this view
        /// </summary>
        public static GameManager Manager { get; set; }

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
        /// Default constructor for our ViewModel
        /// </summary>
        /// <param name="game">The associated GameManager for this view model</param>
        public GameboardViewModel(GameManager game)
        {
            // Save our game manager object
            Manager = game;           

            // Create our gameboard commands
            var cmd1 = new RelayCommand(o => { MessageBox.Show("Command received and clicked"); }, o=> true);
        }

        #endregion

    }
}
