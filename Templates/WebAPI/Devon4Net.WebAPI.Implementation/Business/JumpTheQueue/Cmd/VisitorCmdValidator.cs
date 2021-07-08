using FluentValidation;

namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Cmd
{
    public class VisitorCmdValidator : AbstractValidator<VisitorCmd>
    {
        public VisitorCmdValidator()
        {
        }

        public VisitorCmdValidator(VisitorCmd visitor)
        {
            RuleFor(visitor => visitor.UserName).Cascade(CascadeMode.Continue)
                .NotNull().WithMessage("Username can´t be null.")
                .NotEmpty().WithMessage("Username can´t be empty")
                .EmailAddress().WithMessage("Username format <name>@<domain.toplevel>");

            RuleFor(visitor => visitor.Name).Cascade(CascadeMode.Continue)
                .NotNull().WithMessage("Name can´t be null.");

            RuleFor(visitor => visitor.PhoneNumber).Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("PhoneNumber can´t be null.")
               .Matches("^[A-Za-z0-9 ]*$").WithMessage("Phone number don´t match a sequence of numbers and spaces");


            RuleFor(visitor => visitor.Password).Cascade(CascadeMode.Continue)
               .NotNull().WithMessage("Password can´t be null.");

            RuleFor(visitor => visitor.AcceptedCommercial).Cascade(CascadeMode.Continue)
              .NotNull().WithMessage("AcceptedCommercial can´t be null.");

            RuleFor(visitor => visitor.AcceptedTerms).Cascade(CascadeMode.Continue)
             .NotNull().WithMessage("AcceptedTerms can´t be null.");

            RuleFor(visitor => visitor.UserType).Cascade(CascadeMode.Continue)
            .NotNull().WithMessage("UserType can´t be null.");

        }
    }
}
