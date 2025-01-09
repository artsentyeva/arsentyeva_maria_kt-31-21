namespace ArsentyevaMashaKT3121.Models
{
    public class AcademicDegree
    {
        public int AcademicDegreeId { get; set; }
        public string AcademicDegreeName { get; set; } // название

        ////Связь с преподавателями
        //public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>(); // Множество преподавателей для учёной степени
    }
}

