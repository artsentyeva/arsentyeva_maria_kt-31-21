namespace ArsentyevaMashaKT3121.Properties.Models
{
    public class Teachers
    {
        public int id_teachers { get; set; }
        public string full_name { get; set; }       //ФИО
        public int department_id { get; set; }      // кафедра на которой работает препод
        public int academic_degree_id { get; set;}  // учёная степень
        public int position_id { get; set; }        // должность

        // Связь с учёными степенями
        public ICollection<AcademicDegrees> AcademicDegrees { get; set; } = new List<AcademicDegrees>();
        // Связь с кафедрой
        public ICollection<Department> Department { get; set; } = new List<Department>();
        // Связь с должностью
        public ICollection<Positions> Positions { get; set; } = new List<Positions>();

        // Связь с дисциплиной
        public ICollection<Subjects> Subjects { get; set; } = new List<Subjects>();

        // Связь с часами
        public ICollection<Workload> Workload { get; set; } = new List<Workload>();
    }
}
