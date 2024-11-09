namespace ArsentyevaMashaKT3121.Properties.Models
{
    public class Positions
    {
        public int id_positions { get; set; }
        public string title { get; set; } // название должности

        // Связь с преподавателями
       public ICollection<Teachers> Teachers { get; set; } = new List<Teachers>(); // Множество преподавателей для учёной степени
    }
}
