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
        #endregion
    }
}