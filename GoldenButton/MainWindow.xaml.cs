﻿using System;
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
        #region Private Members

        #endregion

        #region Public Members
        ///// <summary>
        ///// Our console based gameboard model object
        ///// </summary>
        //public static GBModel GameboardModel { get; set; }
        
        /// <summary>
        /// The gamemanager for this game.
        /// </summary>
        public static GameManager gameManager { get; set; }

        /// <summary>
        /// Our gameboard viewmodel object
        /// </summary>
        public static GameboardViewModel GBViewModelObject { get; set; }
        #endregion


        #region Default Constructor
        // constructor
        public MainWindow()
        {
            InitializeComponent();

            Trace.WriteLine("================================ Starting Golden Button =========================================");
        }
        #endregion

        #region Private Methods
        private void GBViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            gameManager = new GameManager();
            gameManager.PlayGame();

            //for(int i = 0; i < 10; i++)
            //{
            //    gameManager.NextPlayer();
            //}




            // create our gameboard view model object
            GBViewModelObject = new GameboardViewModel();

            // now create the gameboard to be used by the object.
            GBViewModelObject.CreateGameboard(16);

            GBViewControl.DataContext = GBViewModelObject;
        }
        #endregion
    }
}
