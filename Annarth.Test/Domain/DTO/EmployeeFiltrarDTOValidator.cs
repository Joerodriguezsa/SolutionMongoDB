using Annarth.Domain.DTO;
using FluentValidation;

namespace Annarth.Test.Domain.DTO
{
    public class EmployeeFiltrarDTOValidator : AbstractValidator<EmployeeFiltrarDTO>
    {
        public EmployeeFiltrarDTOValidator()
        {
            RuleFor(x => x.CompanyId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).When(x => x.CompanyId.HasValue).WithMessage("CompanyId debe ser mayor que 0");

            RuleFor(x => x.CompanyName)
                .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.CompanyName)).WithMessage("CompanyName no debe exceder los 100 caracteres");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email)).WithMessage("Email debe ser una dirección de correo electrónico válida");

            RuleFor(x => x.Fax)
                .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.Fax)).WithMessage("Fax no debe exceder los 20 caracteres");

            RuleFor(x => x.Name)
                .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Name)).WithMessage("Name no debe exceder los 100 caracteres");

            RuleFor(x => x.Username)
                .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.Username)).WithMessage("Username no debe exceder los 50 caracteres");

            RuleFor(x => x.RoleId)
                .GreaterThan(0).When(x => x.RoleId.HasValue).WithMessage("RoleId debe ser mayor que 0");

            RuleFor(x => x.StatusId)
                .GreaterThan(0).When(x => x.StatusId.HasValue).WithMessage("StatusId debe ser mayor que 0");

            RuleFor(x => x.Telephone)
                .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.Telephone)).WithMessage("Telephone no debe exceder los 20 caracteres");
        }
    }
}
