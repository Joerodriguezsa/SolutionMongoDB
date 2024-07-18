using Annarth.Domain.Entities;
using MongoDB.Bson;

namespace Annarth.Test.Domain.Entities
{
    public class EmployeeTests
    {
        [Fact]
        public void Should_Have_Default_Values()
        {
            // Arrange
            var employee = new Employee();

            // Act & Assert
            Assert.Equal(ObjectId.Empty, employee.Id);
            Assert.Equal(default(DateTime), employee.CreatedOn);
            Assert.Null(employee.DeletedOn);
            Assert.Null(employee.Email);
            Assert.Null(employee.Fax);
            Assert.Null(employee.Name);
            Assert.Null(employee.Lastlogin);
            Assert.Null(employee.Password);
            Assert.Equal(default(int), employee.PortalId);
            Assert.Equal(default(int), employee.RoleId);
            Assert.Equal(default(int), employee.StatusId);
            Assert.Null(employee.Telephone);
            Assert.Null(employee.UpdatedOn);
            Assert.Null(employee.Username);
            Assert.Equal(ObjectId.Empty, employee.CompanyId);
            Assert.Null(employee.Company);
        }

        [Fact]
        public void Should_Set_And_Get_Id()
        {
            // Arrange
            var employee = new Employee();
            var objectId = ObjectId.GenerateNewId();

            // Act
            employee.Id = objectId;

            // Assert
            Assert.Equal(objectId, employee.Id);
        }

        [Fact]
        public void Should_Set_And_Get_CreatedOn()
        {
            // Arrange
            var employee = new Employee();
            var createdOn = DateTime.Now;

            // Act
            employee.CreatedOn = createdOn;

            // Assert
            Assert.Equal(createdOn, employee.CreatedOn);
        }

        [Fact]
        public void Should_Set_And_Get_DeletedOn()
        {
            // Arrange
            var employee = new Employee();
            var deletedOn = DateTime.Now;

            // Act
            employee.DeletedOn = deletedOn;

            // Assert
            Assert.Equal(deletedOn, employee.DeletedOn);
        }

        [Fact]
        public void Should_Set_And_Get_Email()
        {
            // Arrange
            var employee = new Employee();
            var email = "test@example.com";

            // Act
            employee.Email = email;

            // Assert
            Assert.Equal(email, employee.Email);
        }

        [Fact]
        public void Should_Set_And_Get_Fax()
        {
            // Arrange
            var employee = new Employee();
            var fax = "123-456-7890";

            // Act
            employee.Fax = fax;

            // Assert
            Assert.Equal(fax, employee.Fax);
        }

        [Fact]
        public void Should_Set_And_Get_Name()
        {
            // Arrange
            var employee = new Employee();
            var name = "John Doe";

            // Act
            employee.Name = name;

            // Assert
            Assert.Equal(name, employee.Name);
        }

        [Fact]
        public void Should_Set_And_Get_Lastlogin()
        {
            // Arrange
            var employee = new Employee();
            var lastLogin = DateTime.Now;

            // Act
            employee.Lastlogin = lastLogin;

            // Assert
            Assert.Equal(lastLogin, employee.Lastlogin);
        }

        [Fact]
        public void Should_Set_And_Get_Password()
        {
            // Arrange
            var employee = new Employee();
            var password = "securepassword";

            // Act
            employee.Password = password;

            // Assert
            Assert.Equal(password, employee.Password);
        }

        [Fact]
        public void Should_Set_And_Get_PortalId()
        {
            // Arrange
            var employee = new Employee();
            var portalId = 123;

            // Act
            employee.PortalId = portalId;

            // Assert
            Assert.Equal(portalId, employee.PortalId);
        }

        [Fact]
        public void Should_Set_And_Get_RoleId()
        {
            // Arrange
            var employee = new Employee();
            var roleId = 456;

            // Act
            employee.RoleId = roleId;

            // Assert
            Assert.Equal(roleId, employee.RoleId);
        }

        [Fact]
        public void Should_Set_And_Get_StatusId()
        {
            // Arrange
            var employee = new Employee();
            var statusId = 789;

            // Act
            employee.StatusId = statusId;

            // Assert
            Assert.Equal(statusId, employee.StatusId);
        }

        [Fact]
        public void Should_Set_And_Get_Telephone()
        {
            // Arrange
            var employee = new Employee();
            var telephone = "555-1234";

            // Act
            employee.Telephone = telephone;

            // Assert
            Assert.Equal(telephone, employee.Telephone);
        }

        [Fact]
        public void Should_Set_And_Get_UpdatedOn()
        {
            // Arrange
            var employee = new Employee();
            var updatedOn = DateTime.Now;

            // Act
            employee.UpdatedOn = updatedOn;

            // Assert
            Assert.Equal(updatedOn, employee.UpdatedOn);
        }

        [Fact]
        public void Should_Set_And_Get_Username()
        {
            // Arrange
            var employee = new Employee();
            var username = "johndoe";

            // Act
            employee.Username = username;

            // Assert
            Assert.Equal(username, employee.Username);
        }

        [Fact]
        public void Should_Set_And_Get_CompanyId()
        {
            // Arrange
            var employee = new Employee();
            var companyId = ObjectId.GenerateNewId();

            // Act
            employee.CompanyId = companyId;

            // Assert
            Assert.Equal(companyId, employee.CompanyId);
        }

        [Fact]
        public void Should_Set_And_Get_Company()
        {
            // Arrange
            var employee = new Employee();
            var company = new Company
            {
                CompanyName = "Test Company"
            };

            // Act
            employee.Company = company;

            // Assert
            Assert.Equal(company, employee.Company);
        }
    }
}
