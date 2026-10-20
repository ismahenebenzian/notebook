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


        #endregion
    }
}