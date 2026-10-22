using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Représente le carnet de notes contenant toutes les unites
    /// </summary>
    public class Notebook
    {
        #region Attributes
        private List<Unit> units = new List<Unit>();
        private List<Exam> exams = new List<Exam>();
        #endregion

        #region Operations
        /// <summary>
        /// Retourne toutes les unites du carnet
        /// </summary>
        /// <returns>Tableau d'unites</returns>
        public Unit[] ListUnits()
        {
            return units.ToArray();
        }


        public void AddUnit(Unit unit)
        {
            if (units.Find(u => u.Name == unit.Name) != null)
                    throw new Exception("Une unité avec le même nom existe déjà");
            units.Add(unit);
        }

        public void RemoveUnit(Unit unit)
        {
            units.Remove(unit);
        }

        /// <summary>
        /// Liste tous les modules de toutes les unités (section 8 du TP)
        /// </summary>
        public Module[] ListModules()
        {
            List<Module> result = new List<Module>();
            foreach (Unit u in units)
            {
                result.AddRange(u.ListModules());
            }
            return result.ToArray();
        }

        /// <summary>
        /// Ajoute un examen à la liste (section 8 du TP)
        /// </summary>
        public void AddExam(Exam exam)
        {
            if (exam == null) throw new ArgumentNullException(nameof(exam));
            exams.Add(exam);
        }

        public Exam[] ListExams()
        {
            return exams.ToArray();
        }

        public AvgScore[] ComputeScores()
        {
            Exam[] tousLesExamens = ListExams();
            var result = new List<AvgScore>();
            var moyennesUE = new List<AvgScore>();

            foreach (Unit ue in units)
            {
                AvgScore[] moyennesModules = ue.ComputeAverages(tousLesExamens);

                // 1. Ajouter les moyennes des modules
                result.AddRange(moyennesModules);

                // 2. Calculer et ajouter la moyenne de l'UE
                if (moyennesModules.Length > 0)
                {
                    float totalCoef = moyennesModules.Sum(m => m.Element.Coef);
                    if (totalCoef > 0)
                    {
                        float moyUE = moyennesModules.Sum(m => m.Average * m.Element.Coef) / totalCoef;
                        var avgUE = new AvgScore(moyUE, ue);
                        moyennesUE.Add(avgUE);
                        result.Add(avgUE);
                    }
                }
            }

            // 3. Calculer et ajouter la moyenne générale
            if (moyennesUE.Count > 0)
            {
                float totalCoef = moyennesUE.Sum(u => u.Element.Coef);
                if (totalCoef > 0)
                {
                    float moyGenerale = moyennesUE.Sum(u => u.Average * u.Element.Coef) / totalCoef;
                    var elementGeneral = new EducationalElement("Moyenne Générale", 1);
                    result.Add(new AvgScore(moyGenerale, elementGeneral));
                }
            }

            return result.ToArray();
        }
        #endregion
    }
}