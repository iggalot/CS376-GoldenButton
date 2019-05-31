
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GoldenButton
{
    public class GameboardViewModel
    {
        #region Public Members
        // our main array of gameboard defined regions
        public ObservableCollection<GBRegion> GBRegionsList { get; set; }
        #endregion

        #region Public Methods
        // create gameboard
        public void CreateGameboard(int num)
        {
            ObservableCollection<GBRegion> regions = new ObservableCollection<GBRegion>();

            for (int i = 0; i < num; i++)
            {
                // create and add a region to our list of regions
                regions.Add(new GBRegion(i));
            }

            GBRegionsList = regions;
        }
        #endregion

    }
}
