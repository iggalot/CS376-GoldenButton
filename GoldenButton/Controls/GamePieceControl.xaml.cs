

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

        private void MyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("I was clicked");

        }
    }
}
