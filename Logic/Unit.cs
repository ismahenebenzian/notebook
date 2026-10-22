using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic
{
    /// <summary>
    /// Représente une unité enseignement
    /// </summary>
    public class Unit : EducationalElement
    {
        #region Attributes
        private List<Module> modules = new List<Module>();

        public Module[] ListModules()
        {
            return modules.ToArray();
        }

        public void Add(Module m)
        {
            modules.Add(m);
        }

        #endregion

        #region Operations
        public Unit()
        {

        }
        public void Remove(Module m)
        {
            modules.Remove(m);
        }

        public AvgScore[] ComputeAverages(Exam[] exams)
        {
            var result = new List<AvgScore>();

            foreach (Module m in modules)
            {
                AvgScore moy = m.ComputeAverage(exams);
                if (moy != null)
                {
                    result.Add(moy);
                }
            }
            return result.ToArray();
        }
        #endregion
    }
}