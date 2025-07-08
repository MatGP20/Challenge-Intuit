using FluentValidation;

namespace Backend_Challenge.Clients
{
    public class ClienteValidator : AbstractValidator<ClientesModel>
    {
        public ClienteValidator() 
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(150);


            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(150);

            RuleFor(x => x.CUIT)
                .NotEmpty().WithMessage("El CUIT es obligatorio.")
                .Matches(@"^\d{2}-\d{8}-\d{1}$").WithMessage("Formato de CUIT inválido.");

            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .Matches(@"^\+?\d{7,15}$").WithMessage("Formato de teléfono inválido.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .MaximumLength(150).EmailAddress().WithMessage("Formato de email inválido.");

            RuleFor(x => x.Domicilio)
                .MaximumLength(200).When(x => !string.IsNullOrWhiteSpace(x.Domicilio));
            
            RuleFor(x => x.Fecha_Nacimiento)
                .LessThan(DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("La fecha de nacimiento debe ser anterior a hoy.")
                .When(x => x.Fecha_Nacimiento.HasValue);
        }
    }
}
