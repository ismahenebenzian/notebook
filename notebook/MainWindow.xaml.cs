using NoteBook;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Logic;

namespace NoteBook
{
    public partial class MainWindow : Window
    {
        #region Attributes
        private Notebook notebook;
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            this.notebook = new Notebook();
        }
        #endregion

        #region Operations
        private void GoEditUnits(object sender, RoutedEventArgs e)
        {
            EditUnitsWindow second = new EditUnitsWindow(notebook);
            second.Show();
        }
        #endregion
    }
}