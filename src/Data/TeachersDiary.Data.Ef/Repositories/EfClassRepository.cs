﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Bytes2you.Validation;
using TeachersDiary.Data.Contracts;
using TeachersDiary.Data.Ef.Contracts;
using TeachersDiary.Data.Ef.Extensions;
using TeachersDiary.Data.Entities;

namespace TeachersDiary.Data.Ef.Repositories
{
    public class EfClassRepository : IClassRepository
    {
        private readonly ITeachersDiaryDbContext _teacherDiaryDbContext;

        public EfClassRepository(ITeachersDiaryDbContext teacherDiaryDbContext)
        {
            _teacherDiaryDbContext = teacherDiaryDbContext;
        }

        public async Task<IEnumerable<Class>> GetAllWithStudentsAsync()
        {
            return await _teacherDiaryDbContext.Classes
                .Include(x => x.Students)
                .ToListAsync();
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _teacherDiaryDbContext.Classes
                .ToListAsync();
        }

        public async Task<Class> GetClassWithStudentsAndAbsencesByClassIdAsync(Guid classId)
        {
            var @class = await _teacherDiaryDbContext.Classes
                .Include(x => x.Students.Select(y => y.Absences))
                .SingleOrDefaultAsync(x => x.Id == classId);

            return @class;
        }

        public async Task<Class> GetByIdAsync(Guid classId)
        {
            return await _teacherDiaryDbContext.Classes.FirstOrDefaultAsync(x => x.Id == classId);
        }

        public void Add(Class @class)
        {
            Guard.WhenArgument(@class, nameof(@class)).IsNull().Throw();

            var entry = _teacherDiaryDbContext.Entry(@class);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                _teacherDiaryDbContext.Classes.Add(@class);
            }
        }

        public void AddRange(List<Class> clases)
        {
            Guard.WhenArgument(clases, nameof(clases)).IsNull().Throw();

            _teacherDiaryDbContext.Classes.AddRange(clases);
        }

        public void Delete(Class @class)
        {
            _teacherDiaryDbContext.Classes.Remove(@class);
        }
    }
}