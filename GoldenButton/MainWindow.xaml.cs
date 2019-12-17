using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace GoldenButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Public Members

        /// <summary>
        /// The gamemanager for this game.
        /// </summary>
        public static GameManager gameManager { get; set; }

        /// <summary>
        /// Our console based gameboard model object
        /// </summary>
        public GameboardViewModel gameboardViewModel { get; set; }

        #endregion

        #region Default Constructor
        // constructor
        public MainWindow()
        {
            InitializeComponent();

            //Trace.WriteLine("================================ Starting Golden Button =========================================");

            // Create our game manager with a default number of squares and then display it
            gameManager = new GameManager(24);

            // create the gameboard view model fri the gameManager data 
            gameboardViewModel = new GameboardViewModel(gameManager);
           // gameboardViewModel.GameboardModel.DisplayBoard();

            // Set the data context for the main window -- our gameboard view model
            this.DataContext = gameboardViewModel;

        }
        #endregion

        #region Private Methods
        private void GBViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Now play the game
           // gameManager.PlayGame();

        }
        #endregion
    }
}
