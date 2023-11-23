using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Animation;

namespace PDF_Creator
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileSelectionLogic FileSelectionLogic;
        public MainWindow()
        {
            FileSelectionLogic = new FileSelectionLogic();
            InitializeComponent();
        }

        private void SelectImages_Click(object sender, RoutedEventArgs e)
        {
            FileSelectionLogic.SelectImages();
        }

        private void SelectOutput_Click(object sender, RoutedEventArgs e)
        {
            FileSelectionLogic.SelectOutputFile();
        }

        private void CreatePDF_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
