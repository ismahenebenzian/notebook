using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Represente un module pédagogique.
    /// </summary>
    public class Module : EducationalElement
    {
        #region Attributes
        private List<Module> modules = new List<Module>();

        public AvgScore ComputeAverage(Exam[] exams)
        {
            if (exams == null) return null;

            Exam[] moduleExams = exams.Where(e => e != null && e.Module == this).ToArray();

            if (moduleExams.Length == 0) return null;

            float totalCoefficient = moduleExams.Sum(e => e.Coef);
            if (totalCoefficient == 0) return null;

            float average = moduleExams.Sum(e => e.Score * e.Coef) / totalCoefficient;

            return new AvgScore(average, this);
        }
        #endregion
    }
}