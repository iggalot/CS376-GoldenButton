
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace GoldenButton
{
    // Our main Gameboard Object
    public class GBModel
    {
        #region Private Members
        /// <summary>
        /// Number of regions on the gameboard.  8 is the default.
        /// </summary>
        int mRegions = 8;
        #endregion

        #region Public Members

        // our main array of gameboard defined regions
        public ObservableCollection<GBRegion> GBRegionsList { get; set; }

        #endregion


        #region Constructor
        public GBModel(int num)
        {
            mRegions = num;

            // Create the gameboard
            this.CreateGameboard(num);
            this.DisplayBoard();

            // Now shuffle the contents
            this.ShuffleGameboard(GBRegionsList);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Creates our game board based on the number of regions specified.
        /// </summary>
        /// <param name="num"></param>
        private void CreateGameboard(int num)
        {
            ObservableCollection<GBRegion> regions = new ObservableCollection<GBRegion>();

            for (int i = 0; i < num; i++)
            {
                // create and add a region to our list of regions
                regions.Add(new GBRegion(i));
            }

            GBRegionsList = regions;
        }

        /// <summary>
        /// Routine to shuffle the gameboard
        /// </summary>
        /// <param name="gameboard"></param>
        private void ShuffleGameboard(ObservableCollection<GBRegion> gameboard)
        {
            // now shuffle our board
            Random rnd = new Random();
            for (int i = 0; i < mRegions; i++)
            {
                int j = rnd.Next(mRegions - 1 - i);
                GBRegion temp = gameboard[i];
                gameboard[i] = gameboard[j];
                gameboard[j] = temp;
            }

            // Now make sure the golden button is in the rightmost 25%
            for (int i = 0; i < mRegions; i++)
            {
                // swap the gold button with a region in rightmost 25% of board
                if (gameboard[i].RegionPieceType == RegionPieceTypes.REGION_PIECETYPE_GOLDEN)
                {               
                    if ((i < (int)(0.75 * mRegions)))
                    {
                        int j = rnd.Next((int)(0.75 * mRegions), mRegions - 1);  
                        GBRegion temp = gameboard[i];
                        gameboard[i] = gameboard[j];
                        gameboard[j] = temp;
                    }
                    break;
                }
            }
        }

        #endregion


        #region Public Methods
        /// <summary>
        /// Displays the current Gameboard state.
        /// </summary>
        public void DisplayBoard()
        {
            string str = "";
            foreach (GBRegion item in GBRegionsList)
            {

                switch(item.RegionPieceType)
                {
                    case RegionPieceTypes.REGION_PIECETYPE_GOLDEN:
                    {
                        str += " G ";
                        break;
                    }
                    case RegionPieceTypes.REGION_PIECETYPE_NORMAL:
                    {
                        str += " N ";
                        break;
                    }
                    case RegionPieceTypes.REGION_PIECETYPE_NONE:
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
