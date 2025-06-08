using FluentValidation;

namespace UserManagement.Application.User.Commands.AddUser
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(dto => dto.Name)
                .Length(3, 100);

            RuleFor(dto => dto.Surname)
                .Length(3, 100);

            RuleFor(dto => dto.ContactNumber)
                .Length(10, 12);

            RuleFor(dto => dto.Email)
                .EmailAddress()
                .WithMessage("Please provide a valid email address");
        }
    }
}
