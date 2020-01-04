
using GoldenButton.Commands;
using GoldenButton.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows;

namespace GoldenButton.ViewModels
{
    public class GameboardViewModel : BaseModel
    {
        #region Private Members
        /// <summary>
        /// Our gameboard object associated with this view model
        /// </summary>
        private GameboardModel _gbModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The margin surrounding out gameboard
        /// </summary>
        public Thickness GBMargin { get; set; } = new Thickness(10);

        /// <summary>
        /// The padding amount between the top edge of the gameboard and the edge of the canvas
        /// </summary>
        public double GBTileTopPadding { get; set; } = (double)10.0;

        /// <summary>
        /// The padding amount between the left edge of the gameboard and the edge of the canvas
        /// </summary>
        public double GBTileLeftPadding { get => GBTileTopPadding; }

        /// <summary>
        /// The color for when a gamepiece is hovered over
        /// </summary>
        public Color GBTileHoverColor { get; } = Color.Orange;

        /// <summary>
        /// The color for when a tile has been selected as part of a move
        /// </summary>
        public Color GBTileSelected { get => GBTileHoverColor; }

        // our main array of gameboard defined regions
        public ObservableCollection<GBRegionVM> GBRegionsList { get; set; }

        // The associated gameboard model
        public GameboardModel GBModel 
        { 
            get=>_gbModel;
            private set { OnPropertyChanged(ref _gbModel, value); } 
        }
        #endregion


        #region Public Methods
        /// <summary>
        /// Computes the total width needed for the gameboard object window, accounting for the height of the regions
        /// and the padding on the top and the bottom.
        /// </summary>
        public double TotalGameboardWidth()
        {
            // Determnine necessary canvas dimensions
            double width = 2.0 * GBTileLeftPadding;
            foreach (GBRegionVM region in GBRegionsList)
            {
                width += region.GBSquareWidth;
            }

            return width;
        }

        /// <summary>
        /// Computes the total height needed for the gameboard canvas, accounting for the height of the regions
        /// and the padding on the top and the bottom.
        /// </summary>
        /// <returns></returns>
        public double TotalGameboardHeight()
        {
            // Determnine necessary canvas dimensions
            double padding = 2.0 * GBTileTopPadding;
            double req_ht = 0;
            foreach (GBRegionVM region in GBRegionsList)
            {
                double temp = region.GBSquareHeight + padding;
                req_ht = Math.Max(req_ht, region.GBSquareHeight);
            }

            return req_ht;
        }

        /// <summary>
        /// Utility function that swaps two pieces on a game board
        /// </summary>
        /// <param name="gameboard">The gameboard collection</param>
        /// <param name="from">Source index of piece to be moved</param>
        /// <param name="to">Destination index for piece to be moved </param>
        public void SwapPiece(int from, int to)
        {
            GBPieceVM temp = GBRegionsList[from].GBPieceVM;
            GBRegionsList[from].GBPieceVM = GBRegionsList[to].GBPieceVM;
            GBRegionsList[to].GBPieceVM = temp;
        }

        public void RemovePiece(int index)
        {
            // Add a blank piece to the region
            GBRegionsList[index].GBPieceVM.GBPiece.PieceOwner = PieceOwners.OWNER_ALL;
            GBRegionsList[index].GBPieceVM.GBPiece.PieceType = PieceTypes.TYPE_NONE;
        }

        /// <summary>
        /// Displays the current Gameboard state as a string.
        /// </summary>
        public void DisplayBoard()
        {
            string str = "";
            foreach (GBRegionVM region in GBRegionsList)
            {

                switch (region.GBPieceVM.GBPiece.PieceType)
                {
                    case PieceTypes.TYPE_GOLDEN:
                        {
                            str += " G ";
                            break;
                        }
                    case PieceTypes.TYPE_NORMAL:
                        {
                            str += " N ";
                            break;
                        }
                    case PieceTypes.TYPE_NONE:
                        {
                            str += " - ";
                            break;
                        }
                    default:
                        break;
                }
            }
            str += "\n";
            Trace.WriteLine(str);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates our game board based on the number of regions specified.
        /// </summary>
        /// <param name="num"></param>
        private void CreateGameboard()
        {
            //GBRegionsList = new ObservableCollection<GBRegionVM>();

            for (int i = 0; i < GBModel.NumRegions; i++)
            {
                // create and add a region to our list of regions
                //TODO:  Fixe this arbitary '30' constant.  Should be a top padding dimensions from the gameboardVM
                GBRegionsList.Add(new GBRegionVM(30));
            }
        }



        /// <summary>
        /// Routine to shuffle the gameboard
        /// </summary>
        private void ShuffleGameboard()
        {
            // now shuffle our our non-golden button pieces
            Random rnd = new Random();
            for (int i = 1; i < GBModel.NumRegions; i++)
            {
                // randomly choose a region (other than region 0 which is the GoldenButton)
                int j = rnd.Next(1, GBModel.NumRegions - 1);

                // Now swap the pieces
                SwapPiece(i, j);

            }

            // Now make sure the golden button (at index=0) is in the rightmost 25% and swap it
            int k = rnd.Next((int)(0.75 * GBModel.NumRegions), GBModel.NumRegions - 1);
            SwapPiece(0, k);
        }

        #endregion

        #region Default Constructor

        /// <summary>
        /// Default constructor for our view model
        /// </summary>
        /// <param name="num">Number of gameboard square or regions</param>
        public GameboardViewModel(int num)
        {
            // initialize our array
            GBRegionsList = new ObservableCollection<GBRegionVM>();

            GBModel = new GameboardModel(num);

            // Create the gameboard
            CreateGameboard();
            //DisplayBoard();

            // Now shuffle the contents
            ShuffleGameboard();
            DisplayBoard();

        }

        #endregion

    }
}
