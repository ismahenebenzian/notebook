using System;
using System.Windows;
using Logic;   // Pour EducationalElement

namespace NoteBook
{
    public partial class EditElementWindow : Window
    {
        #region Attributes
        private EducationalElement element;
        #endregion

        #region Constructors
        public EditElementWindow(EducationalElement elt)
        {
            InitializeComponent();
            element = elt;
            name.Text = element.Name;
            coef.Text = element.Coef.ToString();
        }
        #endregion

        #region Operations
        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                element.Name = name.Text;
                element.Coef = (float)Convert.ToDouble(coef.Text);
                DialogResult = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        #endregion
    }
}