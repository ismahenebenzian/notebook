namespace Logic
{
    public class AvgScore
    {
        public float Average { get; set; }
        public EducationalElement Element { get; set; }

        public AvgScore(float average, EducationalElement element)
        {
            Average = average;
            Element = element;
        }

        public override string ToString()
        {
            return $"{Element?.Name} : {Average:F2}/20";
        }
    }
}