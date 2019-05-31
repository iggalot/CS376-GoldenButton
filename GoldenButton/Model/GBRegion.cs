using System.Windows;

namespace GoldenButton
{
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


    // One of the gameboard regions (square, hex, etc)
    public class GBRegion
    {
        #region Private Members

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

        /// <summary>
        /// The width of our region / or primary dimension for non rectangle
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// The height of our region / or secondary dimension for non rectangle
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// The index of our region number, for referencing in the arrays.
        /// Max = 48, Min = 16;
        /// </summary>
        public int  Index { get; set; }

        /// <summary>
        /// The insertion point of our region into the gameboard. 
        /// For rectangles, will be the upper left corner of the rectangle.
        /// </summary>
        public Point InsertPoint { get; set; }

        /// <summary>
        /// The gamepiece contained in this region of the gameboard
        /// </summary>
        public GBPiece Piece { get; set; }

        #endregion

        #region Public Methods
        public Point CenterPoint()
        {
            Point temppoint = new Point((InsertPoint.X + this.Width / 2), -(InsertPoint.Y + this.Height / 2));
            return temppoint;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="index">Index of our region for locating in the gameboard array</param>
        /// <param name="width">Primary dimension of the region (width for rectangle)</param>
        /// <param name="height">Secondary dimension of the region (height for rectangle)</param>
        /// <param name="shape">Shape descriptor of the region -- Rectangle by default</param>
        public GBRegion(int index, double width = 40, double height = 40, RegionShapes shape = RegionShapes.REGION_RECTANGLE)
        {
            Index = index;
            InsertPoint = new System.Windows.Point(index * width, -height);
            Width = width;
            Height = height;
            RegionShape = shape;
            RegionName = "#" + (index+1).ToString();

            PieceTypes type;
            // create and add a piece to our list of regions
            if (index == 0)
                type = PieceTypes.TYPE_GOLDEN;
            else if (index == 1)
                type = PieceTypes.TYPE_NONE;
            else
                type = PieceTypes.TYPE_NORMAL;
            
            Piece = new GBPiece(PieceOwners.OWNER_ALL, type);
        }
        #endregion
    }
}
