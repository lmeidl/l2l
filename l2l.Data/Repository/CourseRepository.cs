using System;
using l2l.Data.Model;

namespace l2l.Data.Repository
{
    public class CourseRepository
    {
        private readonly L2lDbContext db;

        public CourseRepository()
        {
            //TODO: antipattern
            var factory = new L2lDbContextFactory();
            db = factory.CreateDbContext(new string[] {});
            
        }

        public void Add(Course course)
        {
            //TODO: async
            db.Courses.Add(course);
        }

        public Course GetById(int Id)
        {
            //TODO: async
            return db.Courses.Find(Id);
        }
    }
}