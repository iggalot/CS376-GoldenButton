﻿using GoldenButton.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenButton.Models
{
    public class GameboardModel
    {
        #region Private Members
        /// <summary>
        /// Number of regions on the gameboard.  8 is the default.
        /// </summary>
        public int mRegions = 8;
        #endregion

        #region Public Members

        // our main array of gameboard defined regions
        public ObservableCollection<GBRegionVM> GBRegionsList { get; set; }

        // The number of regions in our gameboard
        public int NumRegions { get => mRegions; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="num"></param>
        public GameboardModel(int num)
        {
            mRegions = num;

            // Create the gameboard
            this.CreateGameboard(num);
            this.DisplayBoard();

            // Now shuffle the contents
            this.ShuffleGameboard(GBRegionsList);
            this.DisplayBoard();
        }

        /// <summary>
        /// Copy constructor, used to duplicate a GBModel and its currenty regions and pieces.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public GameboardModel(GameboardModel board)
        {
            // Store the number of regions
            mRegions = board.NumRegions;

            // Create a new board with the specified number of regions
            this.CreateGameboard(mRegions);

            // Copy the regions (and by default their contents)
            for (int i = 0; i < board.GBRegionsList.Count; i++)
            {
                this.GBRegionsList[i] = board.GBRegionsList[i];
            }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Creates our game board based on the number of regions specified.
        /// </summary>
        /// <param name="num"></param>
        private void CreateGameboard(int num)
        {
            ObservableCollection<GBRegionVM> regions = new ObservableCollection<GBRegionVM>();

            for (int i = 0; i < num; i++)
            {
                // create and add a region to our list of regions
                //TODO:  Fixe this arbitary '30' constant.  Should be a top padding dimensions from the gameboardVM
                regions.Add(new GBRegionVM(30));
            }

            // Assign the newly created region
            GBRegionsList = regions;
        }

        /// <summary>
        /// Routine to shuffle the gameboard
        /// </summary>
        /// <param name="gameboard"></param>
        private void ShuffleGameboard(ObservableCollection<GBRegionVM> gameboard)
        {
            // now shuffle our our non-golden button pieces
            Random rnd = new Random();
            for (int i = 1; i < mRegions; i++)
            {
                // ranbdomly choose a region (other than region 0 which is the GoldenButton)
                int j = rnd.Next(1, mRegions - 1);

                // Now swap the pieces
                SwapPiece(gameboard, i, j);

            }

            // Now make sure the golden button (at index=0) is in the rightmost 25% and swap it
            int k = rnd.Next((int)(0.75 * mRegions), mRegions - 1);
            SwapPiece(gameboard, 0, k);
        }

        /// <summary>
        /// Utility function that swaps two pieces on a game board
        /// </summary>
        /// <param name="gameboard">The gameboard collection</param>
        /// <param name="from">Source index of piece to be moved</param>
        /// <param name="to">Destination index for piece to be moved </param>
        public void SwapPiece(ObservableCollection<GBRegionVM> gameboard, int from, int to)
        {
            GBPiece temp = gameboard[from].GBRegion.Piece;
            gameboard[from].GBRegion.Piece = gameboard[to].GBRegion.Piece;
            gameboard[to].GBRegion.Piece = temp;
        }

        public void RemovePiece(ObservableCollection<GBRegion> gameboard, int index)
        {
            // Create a blank piece
            GBPiece piece = new GBPiece(PieceOwners.OWNER_ALL, PieceTypes.TYPE_NONE);

            // And add it to the region
            gameboard[index].Piece = piece;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Displays the current Gameboard state as a string.
        /// </summary>
        public void DisplayBoard()
        {
            string str = "";
            foreach (GBRegionVM region in GBRegionsList)
            {

                switch (region.GBRegion.Piece.PieceType)
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
    }
}