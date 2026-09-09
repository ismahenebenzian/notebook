using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Représente une unité enseignement
    /// </summary>
    public class Unit : EducationalElement
    {
        #region Attributes
        private List<Module> modules = new List<Module>();
        #endregion

        #region Operations
        /// <summary>
        /// Retourne la liste des modules de unité
        /// </summary>
        /// <returns>Tableau de modules</returns>
        public Module[] ListModules()
        {
            return modules.ToArray();
        }
        #endregion
    }
}