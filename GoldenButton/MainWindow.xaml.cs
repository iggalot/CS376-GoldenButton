using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GoldenButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        #endregion

        #region Public Members
        /// <summary>
        /// Our gameboard viewmodel object
        /// </summary>
        public static GameboardViewModel GBViewModelObject { get; set; }
        #endregion


        #region Constructor
        // constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void GBViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            // create our gameboard view model object
            GBViewModelObject = new GameboardViewModel();

            // now create the gameboard to be used by the object.
            GBViewModelObject.CreateGameboard(16);

            GBViewControl.DataContext = GBViewModelObject;
        }
        #endregion
    }
}
