using System.Windows;

namespace GoldenButton
{
    #region Enums
    /// <summary>
    /// Region shapes for the gameboard
    /// </summary>
    public enum RegionShapes
    {
        REGION_DEFAULT,
        REGION_RECTANGLE,
        REGION_CIRCLE,
        REGION_TRIANGLE,
        REGION_HEX
    }

    public enum RegionPieceTypes
    {
        REGION_PIECETYPE_NONE,
        REGION_PIECETYPE_NORMAL,
        REGION_PIECETYPE_GOLDEN
    }

    #endregion

    // One of the gameboard regions (square, hex, etc)
    public class GBRegion : BaseModel
    {
        #region Private Members

        // The piece currently stored in the region
        private GBPiece mPiece;

        #endregion

        #region Public Members
        /// <summary>
        /// A descriptor for the name of a region
        /// </summary>
        public string RegionName {get; set;}

        /// <summary>
        /// The shape of our gameplay region on the gameboard
        /// </summary>
        public RegionShapes RegionShape { get; set; }

        ///// <summary>
        ///// Holds the single value for the type of piece contained in the region.  Does not currently used the GBPiece class.
        ///// For console developement only at this point.
        ///// </summary>
        //public RegionPieceTypes RegionPieceType { get; set; }

        /// <summary>
        /// The index of our region number, for referencing in the arrays.
        /// Max = 48, Min = 16;
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The gamepiece contained in this region of the gameboard
        /// </summary>
        public GBPiece Piece 
        {
            get => mPiece;
            set
            {
                mPiece = value;

                // Call OnPropertyChanged whenever their property is updated
                OnPropertyChanged("Piece");
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="index">Index of our region for locating in the gameboard array</param>
        /// <param name="shape">Shape descriptor of the region -- Rectangle by default</param>
        public GBRegion(int index)
        {
            Index = index;
            RegionName = "#" + (index+1).ToString();

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
            
            // Using the class
            Piece = new GBPiece(PieceOwners.OWNER_ALL, type);
        }
        #endregion

        #region Public Methods

        public string DisplayInfo()
        {
            string str = "";

            str = "Index: " + Index + "\n" + 
                  "Region #" + (Index+1) + "\n" +
                  "PieceType: " + Piece.PieceType + "\n";

            return str;
        }

        #endregion
    }
}
