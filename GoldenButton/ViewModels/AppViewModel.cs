using GoldenButton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenButton.ViewModels
{
    /// <summary>
    /// The main view model for the application
    /// </summary>
    public class AppViewModel : BaseModel
    {
        /// <summary>
        /// The view model that controls our gameboard
        /// </summary>
        private GameboardViewModel _gameboardVM;

        /// <summary>
        /// The public property that registers our gameboard
        /// </summary>
        public GameboardViewModel GameboardVM
        {
            get => _gameboardVM;
            set { OnPropertyChanged(ref _gameboardVM, value); }
        }

        /// <summary>
        /// The view model associated with the gamemanager
        /// </summary>
        private GameManagerVM _gameManagerVM;

        /// <summary>
        /// The public property associated with our gamemanager object
        /// </summary>
        public GameManagerVM GameManagerVM
        {
            get => _gameManagerVM;
            set { OnPropertyChanged(ref _gameManagerVM, value); }
        }

        public double MenuBarHeight { get; private set; } = 40;
        public double HistoryWindowHeight { get; private set; } = 150;
        public double HistoryWindowWidth { get; private set; } = 300;

        public double CanvasWidth { get; private set; }
        public double CanvasHeight { get; private set; }

        public double AppWindowHeight { get; private set; }
        public double AppWindowWidth { get; private set; }

        #region Constructor
        /// <summary>
        /// Default constructor our applicatiopn
        /// </summary>
        public AppViewModel()
        {
            // Create our Gameboard
            GameboardVM = new GameboardViewModel(24);

            // Determine the canvas dimensions
            CanvasWidth = GameboardVM.TotalGameboardWidth();

            double temp_ht = GameboardVM.TotalGameboardHeight();
            CanvasHeight = HistoryWindowHeight < temp_ht ? temp_ht : HistoryWindowHeight;
            // Determine the history box dimensions
            HistoryWindowHeight = CanvasHeight;

            // Determine the App Window dimensions
            AppWindowHeight = (CanvasHeight < HistoryWindowHeight ? CanvasHeight : HistoryWindowHeight) + MenuBarHeight;
            AppWindowWidth = CanvasWidth + HistoryWindowWidth;

            // Create our game manager with a default number of squares and then display it
            GameManagerVM = new GameManagerVM(GameboardVM, HistoryWindowWidth);

            // create the gameboard view model fri the gameManager data 
            //           GameboardVM = new GameboardViewModel(GameManagerVM.GameManager.);
            // gameboardViewModel.GameboardModel.DisplayBoard();
        }
        #endregion


    }
}
