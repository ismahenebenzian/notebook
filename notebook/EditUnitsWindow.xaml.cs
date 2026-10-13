using Logic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;   

namespace NoteBook
{
    public partial class EditUnitsWindow : Window
    {
        private Notebook notebook;

        public EditUnitsWindow(Notebook nb)
        {
            InitializeComponent();
            this.notebook = nb;
            DrawUnits();
        }

        private void DrawUnits()
        {
            units.Items.Clear();
            foreach (var item in notebook.ListUnits())
                units.Items.Add(item);
        }

        private void EditUnit(object sender, MouseButtonEventArgs e)
        {
            if (units.SelectedItem is Unit u)
            {
                EditElementWindow third = new EditElementWindow(u);
                if (third.ShowDialog() == true)
                {
                    DrawUnits();   
                }
            }
        }

        private void AddUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit newUnit = new Unit();
                EditElementWindow third = new EditElementWindow(newUnit);
                if (third.ShowDialog() == true)
                {
                    notebook.AddUnit(newUnit);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            try
            {       
                if (units.SelectedItem is Unit unit)
                {
                    notebook.RemoveUnit(unit);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void DrawModules()
        {
            if (units.SelectedItem is Unit unit)
            {
                var list = unit.ListModules();
                Modules.Items.Clear();
                foreach (Module m in list)
                    Modules.Items.Add(m);
            }
        }
        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();
        }

        
    }
}