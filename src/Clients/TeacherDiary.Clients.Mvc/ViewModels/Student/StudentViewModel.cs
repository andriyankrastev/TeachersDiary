﻿using System;
using System.Collections.Generic;

using TeacherDiary.Clients.Mvc.Infrastructure.Mapping.Contracts;
using TeacherDiary.Data.Entities;
using TeacherDiary.Data.Services;
using TeacherDiary.Data.Services.Contracts;


namespace TeacherDiary.Clients.Mvc.ViewModels.Student
{
    public class StudentViewModel : IMapFrom<Data.Entities.Student>, IMapTo<Data.Entities.Student>, IMapTo<StudentDto>
    {
        public StudentViewModel()
        {
            Absences = new List<AbsenceViewModel>();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public List<AbsenceViewModel> Absences { get; set; }

        public double TotalExcusedAbsences { get; set; }
        
        public double TotalNotExcusedAbsence { get; set; }

        public string TotalNotExcusedAbsenceAsString { get; set; }
    }

    public class AbsenceViewModel : IMapFrom<Absence>, IMapTo<Absence>
    {
        public int Id { get; set; }

        public Guid StudentId { get; set; }

        public int MonthId { get; set; }

        public double Excused { get; set; }

        public double NotExcused { get; set; }
    }
}