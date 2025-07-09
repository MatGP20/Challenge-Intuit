using BackEnd.DataService.Entities;
using FluentValidation;


namespace Backend_Challenge.WebAPI.Clients
{
    public class ClienteValidator : AbstractValidator<Clientes>
    {
        public ClienteValidator() 
        {
            //validación de nombre y apellido, en valor y tamaño.
            RuleFor(x => x.Nombre)
                .NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("El nombre es obligatorio.")
                .MaximumLength(150);

            RuleFor(x => x.Apellido)
                .NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("El nombre es obligatorio.")
                .MaximumLength(150);

            //se valida que CUIT y teléfono no estén vacíos y cumplan cierto formato
            RuleFor(x => x.CUIT)
                .NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("El CUIT es obligatorio.")
                .Matches(@"^\d{2}-\d{8}-\d{1}$").WithMessage("Formato de CUIT inválido.");

            RuleFor(x => x.Telefono)
                .NotEmpty().Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("El teléfono es obligatorio.")
                .Matches(@"^\+?\d{7,15}$").WithMessage("Formato de teléfono inválido.");

            //Se valida que email no esté vacío y que cumpla con los valores estándar de mail.
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .MaximumLength(150).EmailAddress().WithMessage("Formato de email inválido.");

            //Aunque no sea obligatorio, cuando hay valor se corrobora que no sobrepase cierto tamaño.
            RuleFor(x => x.Domicilio)
                .MaximumLength(200).When(x => !string.IsNullOrWhiteSpace(x.Domicilio));
            
            //Se corrobora que el cliente sea por lo menos mayor de edad.
            RuleFor(x => x.Fecha_Nacimiento)
                .LessThan(DateOnly.FromDateTime(DateTime.Today.AddYears(-18)))
                .WithMessage("Debés tener al menos 18 años.")
                .When(x => x.Fecha_Nacimiento.HasValue);
        }
    }
}
