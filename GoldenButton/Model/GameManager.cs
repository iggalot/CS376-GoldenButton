
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


        /// <summary>
        /// The maximum number of rounds to play.
        /// </summary>
        public static int maxRounds = 5;

        /// <summary>
        /// The current round number.
        /// </summary>
        public static int currentRoundNum = 0;

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


        /// <summary>
        /// Is the game over?  I.e. has someone already one?  
        /// </summary>
        public static bool GameIsOver { get; set; } = false;

        
        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves the next player in the list and updates Current Player
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
            return Players[index];
        }

        public void PlayGame()
        {
            // The main game loop for our game
            // Check if the game is over...
            while(!GameIsOver)
            {
                currentRoundNum++;
                Trace.WriteLine("============ Begin Round " + currentRoundNum.ToString() + " ==============");

                // For each round
                for (int i = 0; i < mNumPlayers; i++)
                {
                    // Play a round for the current player.
                    this.PlayRound(CurrentPlayer);

                    // If the game is over, exit the main game loop
                    if (GameIsOver)
                    {
                        Trace.WriteLine("====== GAME IS OVER!!! " + CurrentPlayer.Name + " has won!! =======");
                        break;
                    }

                    // Move to the next player in the round
                    CurrentPlayer = this.NextPlayer();

                }
            }


        }

        public int getPlayerFirstSelection(int index)
        {
            // Our current selection indiex.
            int selectIndex = index;

            return selectIndex;
        }

        public void PlayRound(Player CurrentPlayer)
        {
            // Play a round
            Trace.WriteLine("-- Playing current round for " + CurrentPlayer.Name);

            // Testing. End the game after ten rounds.
            if (currentRoundNum == 10)
                GameIsOver = true;

            bool firstSelectComplete = false;
            int firstIndex = getPlayerFirstSelection(0);

            bool secondSelectComplete = false;
            int secondIndex = 0;
            string str;


            GameboardModel.DisplayBoard();
            MessageBox.Show("test");

            while (!firstSelectComplete)
            {
                // First selection
                Trace.WriteLine("--- Analyzing first selection ---");
                // A. Does the region contain a gold or normal button?
                RegionPieceTypes piecetype = GameboardModel.GBRegionsList[firstIndex].RegionPieceType;
                if (piecetype != RegionPieceTypes.REGION_PIECETYPE_GOLDEN && piecetype != RegionPieceTypes.REGION_PIECETYPE_NORMAL)
                {
                    // If No... issue warning and return to selection -- target cell must contain a button
                    Trace.WriteLine("----- Region " + firstIndex + " does not contain a valid moveable gamepiece at index " + firstIndex.ToString() + ".");
                    firstIndex++;
                    continue;
                } else
                {
                    if (piecetype == RegionPieceTypes.REGION_PIECETYPE_GOLDEN)
                        str = "Golden";
                    else
                        str = "Normal";

                    Trace.WriteLine("----- Region " + firstIndex + " contains a moveable " + str + " gamepiece.");
                }

                // B. Is the button the leftmost button
                bool isLeftmost = true;

                // check the tiles to the left of our index.  If they contain a tile, then our firstIndex cannot be the leftmost.
                for(int i=0; i < firstIndex - 1; i++)
                {
                    if(GameboardModel.GBRegionsList[i].RegionPieceType == RegionPieceTypes.REGION_PIECETYPE_GOLDEN ||
                        GameboardModel.GBRegionsList[i].RegionPieceType == RegionPieceTypes.REGION_PIECETYPE_NORMAL)
                    {
                        isLeftmost = false;
                    }
                }

                // If the first selection is the leftmost tile, remove it.
                if(isLeftmost)
                {
                    // if it's the leftmost region of the board, we can remove the types.
                    if (firstIndex == 0)
                    {
                        // If the golden button is in the leftmost square, the game is won.
                        if (GameboardModel.GBRegionsList[firstIndex].RegionPieceType == RegionPieceTypes.REGION_PIECETYPE_GOLDEN)
                        {
                            Trace.WriteLine("------- Golden button was taken by " + CurrentPlayer.Name);
                            secondSelectComplete = true;  // no second select required.
                            GameIsOver = true;
                        }
                        // If the leftmost square is a normal button, remove it
                        else if (GameboardModel.GBRegionsList[firstIndex].RegionPieceType == RegionPieceTypes.REGION_PIECETYPE_NORMAL)
                        {
                            Trace.WriteLine("------- Leftmost button was a normal button.  Removing it!");
                            GameboardModel.GBRegionsList[firstIndex].RegionPieceType = RegionPieceTypes.REGION_PIECETYPE_NONE;
                            secondSelectComplete = true;  // no second select required.
                        }
                        else
                        {
                            Trace.WriteLine("------- A golden or normal button was not selected.  Please select again!");
                            continue;
                        }
                    } else
                    {
                        Trace.WriteLine("------- Square 0 was not selected. Cannot remove a piece at this time.  Moving to second selection.");
                    }

                } else
                {
                    Trace.WriteLine("------- The region selected was not the leftmost region.");
                }
                firstSelectComplete = true;
            }

            // Second selection
            while (!secondSelectComplete)
            {
                Trace.WriteLine("--- Analyzing second selection ---");
                // A. Does the region contain a gold or normal button?
                RegionPieceTypes piecetype = GameboardModel.GBRegionsList[secondIndex].RegionPieceType;
                if (piecetype == RegionPieceTypes.REGION_PIECETYPE_GOLDEN || piecetype == RegionPieceTypes.REGION_PIECETYPE_NORMAL)
                {
                    // If YES -- target cell must be empty and not contain a moveable piece already.
                    if (piecetype == RegionPieceTypes.REGION_PIECETYPE_GOLDEN)
                        str = "Golden";
                    else
                        str = "Normal";

                    Trace.WriteLine("----- Invalid Second Selection!  Region " + firstIndex + " contains a moveable " + str + " gamepiece.");
                    continue;
                }
                else
                {
                    Trace.WriteLine("----- Region " + secondIndex + " is empty.  Continuing with checks.");
                }

                // check that the second selection is to the left of the first.  If not, prompt for reselection.
                if (secondIndex > firstIndex)
                {
                    Trace.WriteLine("------- Second selection is not to the left of the first selection.  Make another selection.");
                    continue;
                } else if (secondIndex == firstIndex)
                {
                    Trace.WriteLine("-------- First and second indices are the same.");

                        //TODO :  Resolve the issue where secondIndex and firstIndex are the same.  How do we get past this?



                }
                else
                {
                    Trace.WriteLine("------- Second selection is to the left of the first selection.  Checking for required jumps.");

                }

                // check that there are no other pieces between the first and second index.  We are not permitted to jump pieces.
                bool jumpRequired = false;
                for (int i = secondIndex + 1; i < firstIndex; i++)
                {
                    if(GameboardModel.GBRegionsList[i].RegionPieceType == RegionPieceTypes.REGION_PIECETYPE_GOLDEN ||
                       GameboardModel.GBRegionsList[i].RegionPieceType == RegionPieceTypes.REGION_PIECETYPE_NORMAL)
                    {
                        jumpRequired = true;
                        break;
                    }
                }

                if(jumpRequired)
                {
                    Trace.WriteLine("----------- A jump is required to make this move.  Make a new second selection!");
                    continue;
                } else
                {
                    Trace.WriteLine("----------- No jump required.  Valid move!");
                }

                // complete the second selection
                secondSelectComplete = true;
            }



            // Move the target piece to the destination piece.  (Since all cells techincally have pieces, we simply swap their contents)
            RegionPieceTypes temp = GameboardModel.GBRegionsList[secondIndex].RegionPieceType;
            GameboardModel.GBRegionsList[secondIndex].RegionPieceType = GameboardModel.GBRegionsList[firstIndex].RegionPieceType;
            GameboardModel.GBRegionsList[firstIndex].RegionPieceType = temp;

            // Display the move.
            GameboardModel.DisplayBoard();

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
                if (i == 0)
                    CurrentPlayer = newPlayer;
            }
        }

        #endregion
    }
}
