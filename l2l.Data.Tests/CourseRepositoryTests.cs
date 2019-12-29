using System;
using Xunit;
using l2l.Data.Model;
using l2l.Data.Repository;
using FluentAssertions;

namespace l2l.Data.Tests
{
    /// <summary>
    /// CRUD and list tests
    /// </summary>
    public class CourseRepositoryTests
    {
        public CourseRepositoryTests()
        {
            var factory = new L2lDbContextFactory();
            var db = factory.CreateDbContext(new string[] {});
            db.Database.EnsureCreated();
        }
        [Fact]
        public void CourseRepositoryTests_AddedCoursesShouldAppearInRepository()
        {
            //Arrange
            var sut = new CourseRepository();
            var course = new Course { Id = 1, Name = "Test Course"};
            
            //Act
            sut.Add(course);
            var result = sut.GetById(course.Id);
            
            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(course);

        }
        [Fact]
        public void CourseRepositoryTests_ExistingCoursesShouldAppearInRepository()
        {
            //Arrange
            var sut = new CourseRepository();
            var course = new Course { Id = 1, Name = "Test Course"};
            sut.Add(course);

            //Act
            var result = sut.GetById(course.Id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(course);
        }

        [Fact]
        public void CourseRepositoryTests_ExistingCoursesShouldChange()
        {
            //Arrange  
            var sut = new CourseRepository();
            var course = new Course { Id = 1, Name = "Test Course"};
            sut.Add(course);

            //Act    
            var toUpdate = sut.GetById(course.Id);
            toUpdate.Name = "Modified Test Course";
            sut.Update(toUpdate);
            var afterUpdate = sut.GetById(course.Id);

            //Assert     
            afterUpdate.Should().BeEquivalentTo(toUpdate);
        }

        [Fact]
        public void CourseRepositoryTests_ExistingCoursesShouldBeDeleted()
        {
            //Arrange  
            var sut = new CourseRepository();
            var course = new Course { Id = 1, Name = "Test Course"};
            sut.Add(course);

            //Act    
            var toDelete = sut.GetById(course.Id);
            sut.Remove(toDelete);
            var afterDelete = sut.GetById(course.Id);

            //Assert     
            afterDelete.Should().BeNull();
        }


    }
}
