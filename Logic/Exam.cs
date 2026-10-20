using System;

namespace Logic
{
    public class Exam
    {
        private Module module;
        private DateTime date = DateTime.Now;
        private float coef = 1;
        private float score = 0;
        private bool absent = true;
        private string teacher = string.Empty;

        public Module Module
        {
            get => module;
            set => module = value ?? throw new Exception("Le module doit être non nul");
        }

        public DateTime Date
        {
            get => date;
            set => date = value;
        }

        public float Coef
        {
            get => coef;
            set
            {
                if (value <= 0) throw new Exception("Le coefficient doit être > 0");
                coef = value;
            }
        }

        public float Score
        {
            get => score;
            set
            {
                if (value < 0 || value > 20) throw new Exception("La note doit être entre 0 et 20");
                score = value;
            }
        }

        public bool Absent
        {
            get => absent;
            set => absent = value;
        }

        public string Teacher
        {
            get => teacher;
            set => teacher = value ?? string.Empty;
        }
    }
}