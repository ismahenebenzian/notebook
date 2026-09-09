using System;

namespace Logic
{
    public class EducationalElement
    {
        private string name = string.Empty;
        private float coef;

        #region Properties

        /// <summary>
        /// Nom de element ne doit pas être vide
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("The name must not be empty");
                name = value;
            }
        }

        /// <summary>
        /// Coefficient de l'élément > 0
        /// </summary>
        public float Coef
        {
            get => coef;
            set
            {
                if (value <= 0)
                    throw new Exception("The coef must be >0");
                coef = value;
            }
        }

        #endregion

        #region Constructors

        public EducationalElement() { }

        public EducationalElement(string name, float coef)
        {
            Name = name;
            Coef = coef;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Affiche le nom et coefficient
        /// </summary>
        public override string ToString()
        {
            return $"{Name} ({Coef})";
        }

        #endregion
    }
}