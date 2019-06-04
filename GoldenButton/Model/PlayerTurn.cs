
namespace GoldenButton
{
    /// <summary>
    /// Enum for storing the states of the current move
    /// </summary>
    public enum TurnResults
    {
        GameStart,
        RoundStart,
        RoundEnd,
        GameOver
    }

    /// <summary>
    /// The players turn
    /// </summary>
    public class PlayerTurn
    {
        #region Public Members
        /// <summary>
        /// The result of the players turn:  Game Over, Turn Complete, Turn Skipped, etc...
        /// </summary>
        TurnResults TurnResult { get; set; }

        /// <summary>
        /// The current number of the round.  For implementing a history commmand
        /// </summary>
        int RoundNumber { get; set; }
        #endregion

        #region Default Constructor
        public PlayerTurn(TurnResults result, int round)
        {
            TurnResult = result;
            RoundNumber = round;
        }
        #endregion
    }
}
