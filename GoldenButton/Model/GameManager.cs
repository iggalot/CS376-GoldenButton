
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace GoldenButton
{
    /// <summary>
    /// Holds the information and manages the rules of the game
    /// </summary>
    public class GameManager
    {
        #region Private Members
        /// <summary>
        /// The number of players for this game
        /// </summary>
        public static int mNumPlayers = 4;

        #endregion

        #region Public Members
        /// <summary>
        /// The current player
        /// </summary>
        Player CurrentPlayer { get; set; }

        /// <summary>
        /// THe player information for this game
        /// </summary>
        List<Player> Players { get; set; }

        /// <summary>
        /// Our console based gameboard model object
        /// </summary>
        public static GBModel GameboardModel { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves the next player
        /// </summary>
        /// <returns></returns>
        public Player NextPlayer()
        {
            int index=0;
            bool matchFound = false;
            for(int i=0; i<mNumPlayers; i++)
            {
                if (Players[i].Position == CurrentPlayer.Position)
                {
                    matchFound = true;
                    index = i;
                    break;
                }               
            }

            // If no match was found, something went wrong...
            if (!matchFound)
                throw new NotImplementedException("No matching player found in NextPlayer() function.  Current player turn is Player " + CurrentPlayer.Position.ToString());

            //increment the index to the next player
            index++;

            // if our current player is the last player, reset the index to the beginnning of the list.
            if (index == mNumPlayers)
                index = 0;

            Trace.WriteLine("---- Next Player is Player " + index.ToString());

            // assign the next player as the CurrentPlayer
            return CurrentPlayer = Players[index];

        }






        ///// <summary>
        ///// Play the current players turn
        ///// </summary>
        ///// <returns></returns>
        //public PlayerTurn PlayTurn()
        //{

        //}


        #endregion



        #region Default Constructor
        /// <summary>
        /// The default constructor for our GameManager class
        /// </summary>
        public GameManager()
        {
            // create the gameboard model
            GameboardModel = new GBModel(24);
            GameboardModel.DisplayBoard();

            // create the players
            Players = new List<Player>();

            for(int i = 0; i < mNumPlayers; i++)
            {
                Player newPlayer = new Player(i);
                Players.Add(newPlayer);

                // set the first player as the current player
                if (i==0)
                    CurrentPlayer = newPlayer;
            }
        }

        #endregion
    }
}
