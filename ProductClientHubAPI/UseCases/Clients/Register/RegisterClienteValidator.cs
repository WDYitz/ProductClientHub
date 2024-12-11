using FluentValidation;
using ProductClientHubAPI.Http.Requests;

namespace ProductClientHubAPI.UseCases.Clients.Register;

public class RegisterClientValidator : AbstractValidator<RequestClientJson>
{
  public RegisterClientValidator()
  {
    RuleFor(client => client.Name).NotEmpty().WithMessage("O nome não pode ser vazio");
    RuleFor(client => client.Email).NotEmpty().WithMessage("O e-mail não é valido");
  }
}