using Annarth.Domain.DTO;
using FluentValidation;

namespace Annarth.Test.Domain.DTO
{
    public class CompanyCrearDTOValidator : AbstractValidator<CompanyCrearDTO>
    {
        public CompanyCrearDTOValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("El nombre de la compañía es requerido");
        }
    }
}
