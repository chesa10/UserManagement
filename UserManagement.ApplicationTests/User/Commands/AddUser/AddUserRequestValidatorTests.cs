using FluentValidation.TestHelper;
using Xunit;

namespace UserManagement.Application.User.Commands.AddUser.Tests
{
    public class AddUserRequestValidatorTests
    {
        [Fact()]
        public void Validate_ForValidUserRequest_ShouldNotHaveValidationErrors()
        {
            // arrange
            var request = new AddUserRequest
            {
                Name = "name",
                Surname = "Mmako",
                Email = "email@gmail.com",
                ContactNumber = "0799610258"
            };

            var validator = new AddUserRequestValidator();

            // act
            var result = validator.TestValidate(request);

            // assest
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void Validate_ForInvalidUserRequest_ShouldHaveValidationErrors()
        {
            // arrange
            var request = new AddUserRequest
            {
                Name = "na",
                Surname = "Mm",
                Email = "emailgmail.com",
                ContactNumber = "07996102"
            };

            var validator = new AddUserRequestValidator();

            // act
            var result = validator.TestValidate(request);

            // assest
            result.ShouldHaveValidationErrorFor(u => u.Name);
            result.ShouldHaveValidationErrorFor(u => u.Surname);
            result.ShouldHaveValidationErrorFor(u => u.Email);
            result.ShouldHaveValidationErrorFor(u => u.ContactNumber);
        }
    }
}