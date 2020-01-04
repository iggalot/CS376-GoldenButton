using GoldenButton.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenButton.Models
{
    public class GameboardModel : BaseModel
    {
        #region Private Members
        /// <summary>
        /// Number of regions on the gameboard.  8 is the default.
        /// </summary>
        public int _numRegions = 8;
        #endregion

        #region Public Members

        // The number of regions in our gameboard
        public int NumRegions 
        { 
            get => _numRegions; 
       
            set { OnPropertyChanged(ref _numRegions, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="num"></param>
        public GameboardModel(int num)
        {
            NumRegions = num;
        }

        #endregion

    }
}
