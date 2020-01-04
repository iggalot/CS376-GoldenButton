

using GoldenButton.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GoldenButton.Controls
{
    /// <summary>
    /// Interaction logic for GamePieceControl.xaml
    /// </summary>
    public partial class GamePieceControl : UserControl
    {
        public GamePieceControl()
        {
            InitializeComponent();
        }

        private void TileSelect_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = e.OriginalSource as Button;
            var context = button.DataContext as GBRegion;

            //// Navigate up to find our GameboardViewModel context
            //var gbview = VisualTreeHelperExtensions.FindAncestor<GoldenButton.Views.GBView>(button);
            //var newcontext = gbview.DataContext as GameboardViewModel;

            //MessageBox.Show("BEFORE:\n" + context.DisplayInfo());

            // Now process the move.
            //GameboardViewModel.Manager.ProcessMove(context.Index);

            //MessageBox.Show("AFTER:\n" + context.DisplayInfo());
        }

        /// <summary>
        /// Climb up the visual tree to retrieve until we reach the a specified dependen object
        /// USAGE: var gbview = VisualTreeHelperExtensions.FindAncestor<GoldenButton.Views.GBView>(button);
        /// </summary>
        public static class VisualTreeHelperExtensions
        {
            public static T FindAncestor<T>(DependencyObject dependencyObject)
                where T : class
            {
                DependencyObject target = dependencyObject;

                while(target != null && !(target is T))
                {
                    target = VisualTreeHelper.GetParent(target);
                }

                return target as T;
            }
        }


    }
}
