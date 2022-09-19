using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace replacingBooksPrototype
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        public void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Makes the window draggable while holding down the mouse
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //User selected Replacing Books
            ReplacingBooks obj = new ReplacingBooks();
            //Open the selected window
            obj.Show();
            //Close the current window
            Close();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            //User selected Identifying areas
            MessageBox.Show("Coming Soon!");
            //IdentifyingAreas obj = new IdentifyingAreas();
            //obj.Show();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            //User selected Finding call numbers
            MessageBox.Show("Coming Soon!");
            //FindingCallNumbers obj = new FindingCallNumbers();
            //obj.Show();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            //User selected Exit
            Close();
        }
    }
}
