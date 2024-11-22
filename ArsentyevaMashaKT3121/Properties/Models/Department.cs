namespace ArsentyevaMashaKT3121.Properties.Models
{
    public class Department
    {
        public int DepaetmentId { get; set; } // id кафедры
        public string DepartmentName { get; set; } // название кафедры
        public int DepartmentHeadId { get; set; } // заведуюющий

        // Связь с преподавателями
       //public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>(); // Множество преподавателей для учёной степени
    }
}
