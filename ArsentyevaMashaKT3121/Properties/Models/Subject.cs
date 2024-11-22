namespace ArsentyevaMashaKT3121.Properties.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } // название дисциплины

       // public int department_id { get; set; }

        /*// Связь с преподавателями
       public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>(); // Множество преподавателей для учёной степени*/
    }
}
