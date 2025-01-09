namespace ArsentyevaMashaKT3121.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; } // название должности

        /* // Связь с преподавателями
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>(); // Множество преподавателей для учёной степени*/
    }
}
