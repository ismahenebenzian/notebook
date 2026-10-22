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
            // 1. Remplir la liste des examens
            exams.Items.Clear();
            foreach (Exam e in notebook.ListExams())
            {
                exams.Items.Add(e);
            }

            // 2. Remplir la liste des moyennes
            scores.Items.Clear();
            foreach (AvgScore avg in notebook.ComputeScores())
            {
                scores.Items.Add(avg);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}