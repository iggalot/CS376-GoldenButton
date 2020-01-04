
using GoldenButton.Models;
using System.Windows.Media;

namespace GoldenButton
{
    #region ENUMS for piece flags

    // for setting owner status
    public enum PieceOwners
    {
        OWNER_NONE,
        OWNER_PLAYER1,
        OWNER_PLAYER2,
        OWNER_ALL
    }

    // for setting piece shapes
    public enum PieceShapes
    {
        SHAPE_NONE,
        SHAPE_DEFAULT,
        SHAPE_CIRCLE,
        SHAPE_SQUARE
    }

    // for declaring special icons
    public enum PieceIcons
    {
        ICON_NONE,
        ICON_DEFAULT          
    }

    // For determining the type of piece 
    public enum PieceTypes
    {
        TYPE_NONE,
        TYPE_NORMAL,
        TYPE_GOLDEN
    }

    #endregion

    public class GBPiece : BaseModel
    {

        #region Public Members
        /// <summary>
        /// Getter / Setter for the mOwner field.
        /// </summary>
        public PieceOwners PieceOwner { get; set; } = PieceOwners.OWNER_ALL;

        /// <summary>
        /// The shape of our game piece
        /// </summary>
        public PieceShapes PieceShape { get; set; }

        /// <summary>
        /// The icon used for our game piece
        /// </summary>
        public PieceIcons PieceIcon { get; set; }

        /// <summary>
        /// The type of game piece -- normal or golden button
        /// </summary>
        public PieceTypes PieceType { get; set; }
        #endregion

        #region Public Methods

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public GBPiece(PieceOwners owner, PieceTypes type)
        {
            PieceOwner = owner;
            PieceShape = PieceShapes.SHAPE_NONE;
            PieceIcon = PieceIcons.ICON_NONE;
            PieceType = type;
        }
        #endregion
    }
}
