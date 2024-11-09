namespace ArsentyevaMashaKT3121.Properties.Models
{
    public class AcademicDegrees
    {
        public int id_academicdegrees {  get; set; }
        public string Title { get; set; } // название

        //Связь с преподавателями
        public ICollection<Teachers> Teachers { get; set; } = new List<Teachers>(); // Множество преподавателей для учёной степени
    }
}

