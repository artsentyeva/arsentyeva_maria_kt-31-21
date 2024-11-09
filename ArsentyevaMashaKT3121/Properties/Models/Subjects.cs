namespace ArsentyevaMashaKT3121.Properties.Models
{
    public class Subjects
    {
        public int id_subjects { get; set; }
        public string name { get; set; } // название дисциплины
        public int department_id { get; set; }

        // Связь с преподавателями
       public ICollection<Teachers> Teachers { get; set; } = new List<Teachers>(); // Множество преподавателей для учёной степени
    }
}
