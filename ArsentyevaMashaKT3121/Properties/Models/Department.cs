namespace ArsentyevaMashaKT3121.Properties.Models
{
    public class Department
    {
        public int id_departmet { get; set; } // id кафедры
        public string name { get; set; } // название кафедры
        public int head_id { get; set; } // заведуюющий

        // Связь с преподавателями
       public ICollection<Teachers> Teachers { get; set; } = new List<Teachers>(); // Множество преподавателей для учёной степени
    }
}
