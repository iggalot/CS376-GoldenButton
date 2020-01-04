using GoldenButton.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenButton.ViewModels
{
    /// <summary>
    /// A view model for control aspected of the gamemanager.
    /// Includes history and game status
    /// </summary>
    public class GameManagerVM : BaseModel
    {
        /// <summary>
        /// The game manager associated with this view model
        /// </summary>
        private GameManager _gameManager;

        /// <summary>
        /// Public property for our GameManager
        /// </summary>
        public GameManager GameManager { 
            get => _gameManager;
            private set { OnPropertyChanged(ref _gameManager, value); }
        }

        /// <summary>
        /// For storing our history
        /// </summary>
        private ObservableCollection<string> _history;

        /// <summary>
        /// Public property for our gameplay history object
        /// </summary>
        public ObservableCollection<string> History
        {
            get => _history;
            set { OnPropertyChanged(ref _history, value); }
        }

        /// <summary>
        /// Stores the width of the history window
        /// </summary>
        private double _historyWidth;

        public double HistoryWidth
        {
            get => _historyWidth;
            set
            {
                OnPropertyChanged(ref _historyWidth, value);
            }
        }

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="manager"></param>
        public GameManagerVM(GameboardViewModel board, double width)
        {
            // Create the game manager model for a given gameboard
            GameManager = new GameManager(board.GBModel.NumRegions);

            // set properties
            HistoryWidth = width;

            // set game history and status window
            History = new ObservableCollection<string>();
            // Mock history data
            this.History.Add("Item 1");
            this.History.Add("Item 2");
            this.History.Add("Item 3");
            this.History.Add("Item 4");
            this.History.Add("Item 5");
            this.History.Add("Item 6");
            this.History.Add("Item 7");
            this.History.Add("Item 8");
        }
        #endregion

    }
}
