using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;


namespace ArsentyevaMashaKT3121.Properties.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName{ get; set; }       //ФИО
        public int AcademicDegreeId { get; set;}  // учёная степень
        public int DepartmentId { get; set; }      // кафедра на которой работает препод
        public int PositionId { get; set; }        // должность
        public int SubjectId { get; set; }        // дисциплина

        public virtual AcademicDegree? AcademicDegree { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Position? Position { get; set; }
        public virtual Subject? Subject { get; set; }

    }
}
