using Logic;
using System;
using System.Windows;

namespace NoteBook
{
    public partial class EditExamWindow : Window
    {
        // On utilise Logic.Notebook pour éviter l'erreur avec le namespace NoteBook
        private Logic.Notebook notebook;
        private Logic.Exam exam;

        public EditExamWindow(Logic.Notebook nb)
        {
            InitializeComponent();

            this.notebook = nb;
            this.exam = new Logic.Exam();

            DrawModules();
            InitControls();
        }

        private void DrawModules()
        {
            modules.Items.Clear();

            // Appel de ListModules() sur l'objet notebook
            foreach (var m in notebook.ListModules())
            {
                modules.Items.Add(m);
            }
        }

        private void InitControls()
        {
            datePicker.SelectedDate = exam.Date;
            absentCheckBox.IsChecked = exam.Absent;
            teacherTextBox.Text = exam.Teacher;
            scoreTextBox.Text = exam.Score.ToString();
        }

        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // On précise Logic.Module pour éviter l'ambiguïté avec System.Reflection.Module
                exam.Module = modules.SelectedItem as Logic.Module;

                exam.Date = datePicker.SelectedDate ?? DateTime.Now;
                exam.Absent = absentCheckBox.IsChecked == true;
                exam.Teacher = teacherTextBox.Text;

                if (exam.Absent)
                {
                    exam.Score = 0;
                }
                else
                {
                    if (!float.TryParse(scoreTextBox.Text, out float parsedScore))
                    {
                        throw new Exception("La note doit être un nombre valide.");
                    }
                    exam.Score = parsedScore;
                }

                // Appel de AddExam sur le notebook
                notebook.AddExam(exam);

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}