
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace GoldenButton
{
    /// <summary>
    /// Holds the information and manages the rules of the game
    /// </summary>
    public class GameManager : BaseModel
    {
        #region Private Members
        /// <summary>
        /// The number of players for this game
        /// </summary>
        private static int mNumPlayers = 2;

        /// <summary>
        /// The maximum number of rounds to play.
        /// </summary>
        private static int mMaxRounds = 5;

        /// <summary>
        /// The current round number.
        /// </summary>
        private static int mCurrentRoundNum = 0;

        /// <summary>
        /// The current active player
        /// </summary>
        private static Player mCurrentPlayer;

        /// <summary>
        /// The gameboard object
        /// </summary>
        private GBModel mGameboard;

        /// <summary>
        /// The first selection click index.
        /// </summary>
        private int mFirstSelectedIndex = -1;
        #endregion

        /// <summary>
        /// The second selection click index
        /// </summary>
        private int mSecondSelectedIndex = -1;

        #region Public Members

        /// <summary>
        /// The current player
        /// </summary>
        public Player CurrentPlayer { 
            get => mCurrentPlayer;
            set 
            {
                mCurrentPlayer = value;

                // Call OnPropertyChanged whenever ther property is updated
                OnPropertyChanged("CurrentPlayer");
            } 
        }

        /// <summary>
        /// The player information for this game
        /// </summary>
        public static ObservableCollection<Player> Players { get; set; }

        /// <summary>
        /// The gameboard for this game
        /// </summary>
        public GBModel Gameboard 
        {
            get => mGameboard;
            set
            {
                mGameboard = value;

                OnPropertyChanged("Gameboard");
            }
        }

        /// <summary>
        /// Is the game over?  I.e. has someone already one?  
        /// </summary>
        public static bool GameIsOver { get; set; } = false;

        ///// <summary>
        ///// Is the player's turn over?
        ///// </summary>
        //public bool TurnIsOver
        //{
        //    get => mTurnIsOver;
        //    set
        //    {
        //        mTurnIsOver ^= false;

        //        OnPropertyChanged("TurnIsOver");
        //    }
        //}

        // The index of the first selected click
        public int FirstSelectedIndex
        {
            get => mFirstSelectedIndex;
            set
            {
                mFirstSelectedIndex = value;

                OnPropertyChanged("FirstSelectedIndex");
            }
        }

        // The index of the second selection click
        public int SecondSelectedIndex
        { 
            get => mSecondSelectedIndex;
            set
            {
                mSecondSelectedIndex = value;

                OnPropertyChanged("SecondSelectedIndex");
            }
        }

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

        ///// <summary>
        ///// Starts the game play and controls our main game loop
        ///// </summary>
        //public void PlayGame()
        //{
        //    // The main game loop for our game
        //    // Check if the game is over...
        //    while(!GameIsOver)
        //    {
        //        mCurrentRoundNum++;
        //        Trace.WriteLine("============ Begin Round " + mCurrentRoundNum.ToString() + " ==============");

        //        // For each round
        //        for (int i = 0; i < mNumPlayers; i++)
        //        {
        //            // Play a round for the current player.
        //            this.PlayRound(CurrentPlayer);

        //            // If the game is over, exit the main game loop
        //            if (GameIsOver)
        //            {
        //                Trace.WriteLine("====== GAME IS OVER!!! " + CurrentPlayer.Name + " has won!! =======");
        //                break;
        //            }

        //            // Move to the next player in the round
        //            CurrentPlayer = NextPlayer();
        //        }
        //    }


        //}

        //public int getPlayerFirstSelection(int index)
        //{
        //    // Our current selection indiex.
        //    int selectIndex = index;

        //    return selectIndex;
        //}

        // Logic for playing a game round
        public void PlayRound(Player CurrentPlayer)
        {
            // Play a round
            Trace.WriteLine("-- Playing current round for " + CurrentPlayer.Name);

            // Testing. End the game after ten rounds.
            if (mCurrentRoundNum == 10)
                GameIsOver = true;

            bool firstSelectComplete = false;
            bool secondSelectComplete = false;
            string str;


            //int firstIndex = getPlayerFirstSelection(0);
            //int secondIndex = 0;

            /*
                        // Show our current gameboard status.
                        GameboardModel.DisplayBoard();

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

            */

            //// Move the target piece to the destination piece.  (Since all cells techincally have pieces, we simply swap their contents)
            //RegionPieceTypes temp = GameboardModel.GBRegionsList[secondIndex].RegionPieceType;
            //GameboardModel.GBRegionsList[secondIndex].RegionPieceType = GameboardModel.GBRegionsList[firstIndex].RegionPieceType;
            //GameboardModel.GBRegionsList[firstIndex].RegionPieceType = temp;

            //// Display the move.
            //GameboardModel.DisplayBoard();

        }


        #endregion

        #region Default Constructor
        /// <summary>
        /// The default constructor for our GameManager class
        /// </summary>
        /// <param name="num">The number of squares on our gameboard</param>
        public GameManager(int num)
        {
            // Create our gameboard object
            Gameboard = new GBModel(num);

            // create the players
            Players = new ObservableCollection<Player>();
            for(int i = 0; i < mNumPlayers; i++)
            {
                Player newPlayer = new Player(i);
                Players.Add(newPlayer);
            }

            // set the first player as the current player
            CurrentPlayer = Players[0];

            // Clear the selection index variables
            FirstSelectedIndex = -1;
            SecondSelectedIndex = -1;
        }

        #endregion

        public bool ProcessMove(int index)
        {
            // If the first click is an empty cell, do nothing
            if (Gameboard.GBRegionsList[index].Piece.PieceType == PieceTypes.TYPE_NONE && (FirstSelectedIndex == -1))
            {
                //MessageBox.Show("Nonempty cell required");
                return false;
            }

            // No first click yet
            if (FirstSelectedIndex == -1 && index == 0)
            {
                // Remove the piece from the board
                Gameboard.RemovePiece(Gameboard.GBRegionsList, index);
                EndTurn();
                return true;
            } 
            
            if (FirstSelectedIndex == -1)
            { 
                //MessageBox.Show("First click");
                FirstSelectedIndex = index;
                return false;
            }

            // Click is the same as the first, so unselect it
            if (index == FirstSelectedIndex)
            {
                //MessageBox.Show("Unselecting first click");
                FirstSelectedIndex = -1;
                return false;
            }

            // Otherwise, this is the second click.
            // If the second click isnt an empty cell, invalidate the selection
            if(Gameboard.GBRegionsList[index].Piece.PieceType != PieceTypes.TYPE_NONE)
            {
                //MessageBox.Show("Empty cell required");
                return false;
            }

            // First check that the second click is to the left of the first index
            if (index > FirstSelectedIndex)
            {
                //MessageBox.Show("Invalid second click.  Must be to the left of the first selection.");
                return false;
            } else
            {
                //MessageBox.Show("Second click");
                SecondSelectedIndex = index;
            }

            if(!ValidateMove(FirstSelectedIndex, SecondSelectedIndex))
            {
                FirstSelectedIndex = -1;
                SecondSelectedIndex = -1;
                return false;
            }

            // Swap the pieces on the board
            Gameboard.SwapPiece(Gameboard.GBRegionsList, FirstSelectedIndex, SecondSelectedIndex);

            EndTurn();
            return true;
        }

        /// <summary>
        /// Checks that a move between two indices is allowed.  I.e. is there another piece in the way?  Jumping is not 
        /// allowed.
        /// </summary>
        /// <param name="first">Index of the source</param>
        /// <param name="second">Index of the destination</param>
        /// <returns></returns>
        private bool ValidateMove(int first, int second)
        {
            bool valid = true;

            // Check that we are not jumping over a piece.  Starts at index - 1 since the first index must contain a piece
            for (int i = first-1; i > second; i--)
            {
                if(Gameboard.GBRegionsList[i].Piece.PieceType != PieceTypes.TYPE_NONE)
                {
                    valid = false;
                    MessageBox.Show("Cannot move.  There is another piece in the way");
                    break;
                }
            }

            return valid;
        }

        private void EndGame()
        {
            MessageBox.Show(CurrentPlayer.Name + " is the winner");
            
            // TODO:  End the game...update statistics, winner splash screen
        }

        /// <summary>
        /// The routine that ends a players turn.  Cleares selection indices and updates the current player.
        /// </summary>
        private void EndTurn()
        {

            // Duplicate the gameboard to trigger OnPropertyChanged via the assignment operation
            Gameboard = new GBModel(Gameboard);

            // Check that the golden button isn't in the leftmost cell
            if (Gameboard.GBRegionsList[0].Piece.PieceType == PieceTypes.TYPE_GOLDEN)
            {
                EndGame();
            }

            // Otherwise, reset the index selection variables
            FirstSelectedIndex = -1;
            SecondSelectedIndex = -1;

            // Update the Current Player
            CurrentPlayer = NextPlayer();

            // Display the board on the console.
            Gameboard.DisplayBoard();

        }
    }
}
