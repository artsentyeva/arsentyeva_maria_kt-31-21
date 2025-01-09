namespace ArsentyevaMashaKT3121.Properties.Models
{
    public class Department
    {
        public int DepartmentId { get; set; } // id кафедры
        public string DepartmentName { get; set; } // название кафедры
        public int DepartmentHeadId { get; set; } // заведующий кафедрой

        //public Teacher Head { get; set; } // Навигационное свойство для заведующего
        /*        public List<Teacher> Teacher { get; set; } = new(); // Список преподавателей*/

        public virtual Teacher DepartmentHead { get; set; } // Навигационное свойство
        public virtual ICollection<Teacher> Teachers { get; set; }

    }

}
