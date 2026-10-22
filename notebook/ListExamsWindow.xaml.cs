using System.Windows;
using Logic;

namespace NoteBook 
{
    public partial class ListExamsWindow : Window
    {
        private Notebook notebook;

        public ListExamsWindow(Notebook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            DrawExams();
        }

        private void DrawExams()
        {
            exams.Items.Clear();
            foreach (Exam e in notebook.ListExams())
            {
                exams.Items.Add(e);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}