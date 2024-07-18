using Annarth.Domain.DTO;
using FluentValidation;

namespace Annarth.Test.Domain.DTO
{
    public class CompanyActualizarDTOValidator : AbstractValidator<CompanyActualizarDTO>
    {
        public CompanyActualizarDTOValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("El nombre de la compañía es requerido");
        }
    }
}
