using Logic;
using System;
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
                if (third.ShowDialog() == true) DrawUnits();
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
            catch (Exception x) { MessageBox.Show(x.Message); }
        }

        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                if (units.SelectedItem is Unit unit)
                {
                    notebook.RemoveUnit(unit);
                    DrawUnits();
                    Modules.Items.Clear();
                }
            }
            catch (Exception x) { MessageBox.Show(x.Message); }
        }

        private void DrawModules()
        {
            Modules.Items.Clear();
            if (units.SelectedItem is Unit unit)
            {
                foreach (Module m in unit.ListModules())
                    Modules.Items.Add(m);
            }
        }

        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();
        }

        private void AddModule(object sender, RoutedEventArgs e)
        {
            if (units.SelectedItem is Unit selectedUnit)
            {
                try
                {
                    Module newModule = new Module();
                    EditElementWindow editWindow = new EditElementWindow(newModule);
                    if (editWindow.ShowDialog() == true)
                    {
                        selectedUnit.Add(newModule);
                        DrawModules();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else MessageBox.Show("Sélectionnez d'abord une UE à gauche.");
        }

        private void RemoveModule(object sender, RoutedEventArgs e)
        {
            if (units.SelectedItem is Unit selectedUnit && Modules.SelectedItem is Module selectedModule)
            {
                try
                {
                    selectedUnit.Remove(selectedModule); 
                    DrawModules();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}