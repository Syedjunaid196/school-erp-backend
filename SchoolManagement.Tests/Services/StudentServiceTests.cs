using Moq;
using SchoolManagement.Application.Abstractions.IunitOfWork;
using SchoolManagement.Application.Abstractions.Persistence;
using SchoolManagement.Application.Abstractions.Security;
using SchoolManagement.Application.RR_Models.Student;
using SchoolManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SchoolManagement.Tests.Services
{
    public class StudentServiceTests
    {
        private readonly Mock<IAuthRepository> _authRepositoryMock;
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly Mock<IPasswordHasher> _passwordHasherMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly StudentService _studentService;
        public StudentServiceTests()
        {
            _authRepositoryMock = new Mock<IAuthRepository>();
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _passwordHasherMock = new Mock<IPasswordHasher>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _studentService = new StudentService(
                _authRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _passwordHasherMock.Object,
                _studentRepositoryMock.Object
                );
        }

        [Fact]
        public async Task CreateStudent_ShouldReturnSuccess_WhenStudentIsCreated()
        {
            //arrange


            //var studentRepositoryMock = new Mock<IStudentRepository>();


            //var request = new StudentRequest()
            //{
            //    FirstName = "John",
            //    LastName = "Doe",
            //    Email = "john@gmail.com",
            //    Password = "Password123",
            //    RollNumber = "101",
            //    ParenetId = Guid.CreateVersion7()
            //};
            //act

            //assert
            Assert.NotNull(_studentService);
        }

    }
}
