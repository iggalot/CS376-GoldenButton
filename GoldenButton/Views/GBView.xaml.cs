
using GoldenButton.ViewModels;
using System.Windows.Controls;

namespace GoldenButton.Views
{
    /// <summary>
    /// Interaction logic for GBView.xaml
    /// </summary>
    public partial class GBView : UserControl
    {
        public GBView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Toggle the setting
            //GameboardViewModel.Manager.PieceIsMoved = (false ? true : false);
        }
    }
}
