namespace ArsentyevaMashaKT3121.Properties.Models
{
    public class Workload
    {
        public int id_workload { get; set; }    
        public int teacher_id { get; set; }     // преподаватель
        public int subject_id { get; set; }     // дисципоина
        public int lecture_horus { get; set; }  // лекционные часы
        public int practice_hours { get; set; } // практические часы

       // Связь с преподавателями
       public ICollection<Teachers> Teachers { get; set; } = new List<Teachers>(); 
    }
}
