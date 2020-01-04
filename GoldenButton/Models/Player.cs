
using System.Diagnostics;

namespace GoldenButton.Models
{
    public class Player
    {
        #region Public Methods

        /// <summary>
        /// The name of the player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The position of the player in the game?  Player 1, Player 2, etc.
        /// </summary>
        public int Position { get; set; }

        #endregion

        #region Default Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id"></param>
        public Player(int id)
        {
            Trace.WriteLine("-- Creating Player " + id.ToString());
            Name = "Player " + id.ToString();
            Position = id;

        }
        #endregion
    }
}
