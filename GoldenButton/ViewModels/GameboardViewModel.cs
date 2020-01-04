
using GoldenButton.Commands;
using GoldenButton.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private GameboardModel _gameboard;

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


        /// <summary>
        /// Our public gameboard propertiuyt
        /// </summary>
        public GameboardModel Gameboard
        {
            get => _gameboard;
            set { OnPropertyChanged(ref _gameboard, value); }       
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
            foreach (GBRegionVM region in Gameboard.GBRegionsList)
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
            foreach (GBRegionVM region in Gameboard.GBRegionsList)
            {
                double temp = region.GBSquareHeight + padding;
                req_ht = Math.Max(req_ht, region.GBSquareHeight);
            }

            return req_ht;
        }

        #endregion

        #region Default Constructor

        /// <summary>
        /// Default constructor for our view model
        /// </summary>
        /// <param name="num">Number of gameboard square or regions</param>
        public GameboardViewModel(int num)
        {
            // Create our gameboard model
            Gameboard = new GameboardModel(num);
            
        }

        #endregion

    }
}
